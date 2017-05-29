using UnityEngine;

namespace Cariacity.game
{
    public class GameplayController : MonoBehaviour
    {
        private static TouchController _touchControl;
        private static TouchBehavior _currentMode;

        public GameObject Cube;

        private void Start()
        {
            _touchControl = new TouchController();
        }

        public static void SetInsertionModel(string type)
        {
            _touchControl.SetInsertionType(type);
        }

        public static void SetCurrentMode(TouchBehavior mode)
        {
            _currentMode = mode;
        }

        public static void CancelInsertion()
        {
            _touchControl.Clean();
            _currentMode = TouchBehavior.Movment;
        }

        public static void CtrlZInsertion()
        {
            _touchControl.CtrlZ();
        }

        public static void AcceptInsertion()
        {
            _touchControl.Apply();
            _currentMode = TouchBehavior.Movment;
        }

        void LateUpdate()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                switch (_currentMode)
                {
                    case TouchBehavior.Movment:
                        _touchControl.MovmentMode();
                        break;

                    case TouchBehavior.Building:
                        _touchControl.StartInsertionMode();
                        break;
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    var touchPoint = Input.mousePosition;
                    var cameraPoint = Camera.main.ScreenToWorldPoint(new Vector3(touchPoint.x, touchPoint.y, 0));
                    var cameraPoint2 = Camera.main.ScreenToViewportPoint(new Vector3(touchPoint.x, touchPoint.y, 0));
                    var cameraPoint3 = Camera.main.ScreenPointToRay(new Vector3(touchPoint.x, touchPoint.y, 0));

                    //Instantiate(Cube, cameraPoint, Quaternion.Euler(0, 0, 0));
                    //Instantiate(Cube, cameraPoint2, Quaternion.Euler(0, 0, 0));

                    Debug.DrawRay(cameraPoint3.origin, cameraPoint3.direction, Color.red);
                    // Instantiate(Cube, cameraPoint3., Quaternion.Euler(0, 0, 0));

                    //var _cell = Common.GetNearbyCell(new Vector3(cameraPoint.x, 0, cameraPoint.z + cameraPoint.y));

                    /*
                    if (_cell != null)
                    {
                        lock (UiController.TouchOnUILock)
                        {
                            if (!UiController.TouchOnUI)
                            {
                                Common.ShowInfo(_cell.ToString());
                                CommonModels.HighLightObj.transform.position = _cell.center;
                                CommonModels.HighLightObj.SetActive(true);
                            }

                            UiController.TouchOnUI = false;
                        }
                    }
                    */

                    //Instantiate(Model2, cameraPoint, Quaternion.Euler(-45, 0, 0));    // touch direction, !important

                    // NearbyObjectLocation(worldPoint);
                    // Debug.Log(cameraPoint);
                    // Debug.Log(worldPoint);

                    // var pos = touchPos / 100000;
                    // transform.position += new Vector3(pos[1], 0, pos[0]);
                }
            }
        }
    }
}
