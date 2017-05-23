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
            _type = educationBuilding;

            var pos = new Vector3(0, -10, 0);

            switch (_type)
            {
                case EducationBuilding.School: _currentProject = GameController.InitObj(HighSchool.Data.Project, pos); break;
                case EducationBuilding.University: _currentProject = GameController.InitObj(University.Data.Project, pos); break;
                case EducationBuilding.DayCarePost: _currentProject = GameController.InitObj(DayCarePost.Data.Project, pos); break;
            }
        }        

        public override void OnMoved(GridCell cell)
        {
            _currentProject.transform.position = cell.center;

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

            Object.Destroy(_currentProject);
        }

        public override void Clean()
        {
            Object.Destroy(_currentProject);
        }
    }
}
