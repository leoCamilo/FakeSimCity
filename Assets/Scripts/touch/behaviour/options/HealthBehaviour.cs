using UnityEngine;

namespace Cariacity.game
{
    public enum HealthBuilding { Clinic, Hospital, FirstAidPost }

    public class HealthBehaviour : BuildingBehaviour
    {
        private HealthBuilding _type;
        private GameObject _currentProject;

        public override void CtrlZ() { }
        public override void OnBegan(GridCell cell) { }
        public override void OnEnded(GridCell cell) { }
        public override void OnCanceled(GridCell cell) { }
        public override void OnStationary(GridCell cell) { }

        public HealthBehaviour(HealthBuilding healthBuilding)
        {
            _type = healthBuilding;

            var pos = new Vector3(0, -10, 0);

            switch (_type)
            {
                case HealthBuilding.Clinic: _currentProject = GameController.InitObj(Clinic.Data.Project, pos); break;
                case HealthBuilding.Hospital: _currentProject = GameController.InitObj(Hospital.Data.Project, pos); break;
                case HealthBuilding.FirstAidPost: _currentProject = GameController.InitObj(FirstAidPost.Data.Project, pos); break;
            }
        }

        public override void OnMoved(GridCell cell)
        {
            _currentProject.transform.position = cell.center;

            switch (_type)
            {
                case HealthBuilding.Clinic: Building.SetRenderer(_currentProject, Clinic.IsBuildable(cell)); break;
                case HealthBuilding.Hospital: Building.SetRenderer(_currentProject, Hospital.IsBuildable(cell)); break;
                case HealthBuilding.FirstAidPost: Building.SetRenderer(_currentProject, FirstAidPost.IsBuildable(cell)); break;
            }
        }

        public override void Apply()
        {
            var pos = _currentProject.transform.position;

            switch (_type)
            {
                case HealthBuilding.Clinic: Clinic.SetOnMap(pos); break;
                case HealthBuilding.Hospital: Hospital.SetOnMap(pos); break;
                case HealthBuilding.FirstAidPost: FirstAidPost.SetOnMap(pos); break;
            }

            Object.Destroy(_currentProject);
        }

        public override void Clean()
        {
            Object.Destroy(_currentProject);
        }
    }
}
