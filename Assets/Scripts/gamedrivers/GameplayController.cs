using UnityEngine;

namespace Cariacity.game
{
    public class GameplayController : MonoBehaviour
    {
        private static TouchController _touchControl;
        private static TouchBehavior _currentMode;

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

                    var _cell = Common.GetNearbyCell(new Vector3(cameraPoint.x, 0, cameraPoint.z + cameraPoint.y));
                    if (_cell != null)
                    {
                        var boolflag = School.IsBuildable(_cell);

                        if (boolflag)
                            _cell.obj = Instantiate(School.Data.Project, _cell.center, Quaternion.Euler(0, 45, 0));

                        // if (_cell.obj == null)
                        //     _cell.obj = Instantiate(School.Project, _cell.center, Quaternion.Euler(0, 45, 0));
                        // else
                        // Destroy(_cell.obj);
                    }

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
