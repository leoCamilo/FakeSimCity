using UnityEngine;

namespace Cariacity.game
{
    public class CameraController : MonoBehaviour
    {
        private static TouchBehaviour _touchBehaviour;
        private static TouchBehavior  _currentMode;

        private void Start() {
            _touchBehaviour = new TouchBehaviour(gameObject);
        }

        public static void SetZoom(float zoom)
        {
            var currentSize = Camera.main.orthographicSize;
            Camera.main.orthographicSize = Mathf.Clamp(currentSize + zoom, 2, 10);
        }

        public static void SetInsertionModel(string type) {
            _touchBehaviour.SetInsertionType(type);
        }

        public static void SetCurrentMode(TouchBehavior _mode) {
            _currentMode = _mode;
        }

        public static void CancelInsertion()
        {
            _touchBehaviour.Clean();
            _currentMode = TouchBehavior.Movment;
        }

        public static void CtrlZInsertion()
        {
            _touchBehaviour.CtrlZ();
        }

        public static void AcceptInsertion()
        {
            _touchBehaviour.Apply();
            _currentMode = TouchBehavior.Movment;
        }

        void LateUpdate()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                switch (_currentMode)
                {
                    case TouchBehavior.Movment:
                        _touchBehaviour.MovmentMode();
                        break;

                    case TouchBehavior.Building:
                        _touchBehaviour.StartInsertionMode();
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
                            _cell.obj = Instantiate(School.Project, _cell.center, Quaternion.Euler(0, 45, 0));

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
