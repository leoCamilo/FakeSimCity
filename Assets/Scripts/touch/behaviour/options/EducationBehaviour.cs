using UnityEngine;

namespace Cariacity.game
{
    public enum EducationBuilding { School, University, DayCarePost }

    public class EducationBehaviour : BuildingBehaviour
    {
        private EducationBuilding _type;
        private GameObject _currentProject;

        public override void CtrlZ() { }
        public override void OnBegan(GridCell cell) { }
        public override void OnEnded(GridCell cell) { }
        public override void OnCanceled(GridCell cell) { }
        public override void OnStationary(GridCell cell) { }

        public EducationBehaviour(EducationBuilding educationBuilding)
        {
            BuildingData data;
            _type = educationBuilding;

            switch (_type)
            {
                case EducationBuilding.School: data = HighSchool.Data; break;
                case EducationBuilding.University: data = University.Data; break;
                case EducationBuilding.DayCarePost: data = DayCarePost.Data; break;
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
                case EducationBuilding.School: Building.SetRenderer(_currentProject, HighSchool.IsBuildable(cell)); break;
                case EducationBuilding.University: Building.SetRenderer(_currentProject, University.IsBuildable(cell)); break;
                case EducationBuilding.DayCarePost: Building.SetRenderer(_currentProject, DayCarePost.IsBuildable(cell)); break;
            }
        }

        public override void Apply()
        {
            var pos = _currentProject.transform.position;

            switch (_type)
            {
                case EducationBuilding.School: HighSchool.SetOnMap(pos); break;
                case EducationBuilding.University: University.SetOnMap(pos); break;
                case EducationBuilding.DayCarePost: DayCarePost.SetOnMap(pos); break;
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
