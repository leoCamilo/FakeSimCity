using UnityEngine;

namespace Cariacity.game
{
    public enum TouchBehavior { Movment, Building }

    public class TouchController : MonoBehaviour
    {
        private bool _showStatus;
        private float _timer;

        private MovementBehaviour _movement;
        private BuildingBehaviour _behaviour;

        public TouchController()
        {
            _movement = new MovementBehaviour();
        }

        public void SetInsertionType(string type)
        {
            switch (type)
            {
                case Constants.HomeTag: _behaviour = new HomeBehaviour(); break;
                case Constants.CleanTag: _behaviour = new CleanBehaviour(); break;
                case Constants.StreetTag: _behaviour = new StreetBehaviour(); break;
                case Constants.PoliceTag: _behaviour = new PoliceBehaviour(); break;
                case Constants.SchoolTag: _behaviour = new SchoolBehaviour(); break;
                case Constants.HospitalTag: _behaviour = new HospitalBehaviour(); break;
            }
        }

        public void Apply()
        {
            _behaviour.Apply();
            Common.UpdateMoney();
        }

        public void Clean() { _behaviour.Clean(); }
        public void CtrlZ() { _behaviour.CtrlZ(); }

        public void StartInsertionMode()
        {
            if (Input.touchCount > 0) {

                var myTouch = Input.GetTouch(0);
                var touchPoint = myTouch.position;
                var cameraPoint = Camera.main.ScreenToWorldPoint(new Vector3(touchPoint.x, touchPoint.y, 0));
                var cell = Common.GetNearbyCell(new Vector3(cameraPoint.x, 0, cameraPoint.z + cameraPoint.y));

                switch (myTouch.phase)
                {
                    case TouchPhase.Began: _behaviour.OnBegan(cell); break;
                    case TouchPhase.Moved: _behaviour.OnMoved(cell); break; // stationary
                    case TouchPhase.Ended: _behaviour.OnEnded(cell); break;
                }
            }
        }

        public void MovmentMode()
        {
            switch (Input.touchCount)
            {
                case 1:
                    var touch = Input.GetTouch(0);

                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            _timer = Time.time;
                            _showStatus = true;
                            break;

                        case TouchPhase.Moved:
                            _showStatus = false;
                            _movement.Movment(Input.GetTouch(0));
                            break;

                        case TouchPhase.Stationary:
                            if (Time.time - _timer > 1 && _showStatus)
                            {
                                var touchPoint = touch.position;
                                var cameraPoint = Camera.main.ScreenToWorldPoint(new Vector3(touchPoint.x, touchPoint.y, 0));
                                var _cell = Common.GetNearbyCell(new Vector3(cameraPoint.x, 0, cameraPoint.z + cameraPoint.y));

                                // Common.Log(_cell.ToString());
                                Common.ShowInfo(_cell.ToString());
                            }

                            break;

                        case TouchPhase.Ended: _showStatus = false; break;
                    }

                    break;

                case 2: _movement.Zoom(Input.GetTouch(0), Input.GetTouch(1)); break;
            }
        }
    }
}