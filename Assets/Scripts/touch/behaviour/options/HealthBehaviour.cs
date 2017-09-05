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
            BuildingData data;
            _type = healthBuilding;

            switch (_type)
            {
                case HealthBuilding.Clinic: data = Clinic.Data;  break;
                case HealthBuilding.Hospital: data = Hospital.Data; break;
                case HealthBuilding.FirstAidPost: data = FirstAidPost.Data; break;
                default: return;
            }

            var pos = new Vector3(0, -10, 0);
            var influenceArea = CommonModels.InfluenceObj;
            var bound = data.InfluenceBound * 2;

            _currentProject = GameController.InitObj(data.Project, pos);

            influenceArea.SetActive(true);
            influenceArea.transform.localScale = new Vector3(bound, 0.01f, bound);
            influenceArea.transform.position = pos;
        }

        public override void OnMoved(GridCell cell)
        {
            _currentProject.transform.position = cell.center;
            CommonModels.InfluenceObj.transform.position = cell.center;

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

            Clean();
        }

        public override void Clean()
        {
            Object.Destroy(_currentProject);
            CommonModels.InfluenceObj.SetActive(false);
        }
    }
}
