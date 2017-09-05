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
                case Tags.Home              : _behaviour = new HomeBehaviour(); break;
                case Tags.Clean             : _behaviour = new CleanBehaviour(); break;
                case Tags.Store             : _behaviour = new StoreBehaviour(); break;
                case Tags.Street            : _behaviour = new StreetBehaviour(); break;
                case Tags.Clinic            : _behaviour = new HealthBehaviour(HealthBuilding.Clinic); break;
                case Tags.Hospital          : _behaviour = new HealthBehaviour(HealthBuilding.Hospital); break;
                case Tags.HighSchool        : _behaviour = new EducationBehaviour(EducationBuilding.School); break;
                case Tags.University        : _behaviour = new EducationBehaviour(EducationBuilding.University); break;
                case Tags.DayCarePost       : _behaviour = new EducationBehaviour(EducationBuilding.DayCarePost); break;
                case Tags.FirstAidPost      : _behaviour = new HealthBehaviour(HealthBuilding.FirstAidPost); break;
                case Tags.SecurityCabin     : _behaviour = new SecurityBehaviour(SecurityBuilding.SecurityCabin); break;
                case Tags.PoliceStation     : _behaviour = new SecurityBehaviour(SecurityBuilding.PoliceStation); break;
                case Tags.PoliceHeadquartes : _behaviour = new SecurityBehaviour(SecurityBuilding.PoliceHeadquarters); break;
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
            if (Input.touchCount > 0)
            {
                var myTouch = Input.GetTouch(0);
                var touchPoint = myTouch.position;
                var cameraPoint = Camera.main.ScreenToWorldPoint(new Vector3(touchPoint.x, touchPoint.y, 0));
                var cell = Common.GetNearbyCell(new Vector3(cameraPoint.x, 0, cameraPoint.z + cameraPoint.y));

                switch (myTouch.phase)
                {
                    case TouchPhase.Began: _behaviour.OnBegan(cell); break;
                    case TouchPhase.Moved: _behaviour.OnMoved(cell); break;
                    case TouchPhase.Ended: _behaviour.OnEnded(cell); break;
                    case TouchPhase.Stationary: _behaviour.OnMoved(cell); break;
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

                        case TouchPhase.Ended:
                            lock (UiController.TouchOnUILock)
                            {
                                if (!UiController.TouchOnUI && Time.time - _timer < 0.3 && _showStatus)
                                {
                                    var touchPoint = touch.position;
                                    var cameraPoint = Camera.main.ScreenToWorldPoint(new Vector3(touchPoint.x, touchPoint.y, 0));
                                    var cell = Common.GetNearbyCell(new Vector3(cameraPoint.x, 0, cameraPoint.z + cameraPoint.y));

                                    if (cell.obj.tag == Tags.Home)
                                        _movement.HighLight(cell);
                                }

                                UiController.TouchOnUI = false;
                            }

                            break;
                    }

                    break;

                case 2: _movement.Zoom(Input.GetTouch(0), Input.GetTouch(1)); break;
            }
        }
    }
}