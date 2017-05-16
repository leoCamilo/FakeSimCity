using UnityEngine;

namespace Cariacity.game
{
    public enum SecurityBuilding { SecurityCabin, PoliceStation, PoliceHeadquarters }

    public class SecurityBehaviour : BuildingBehaviour
    {
        private SecurityBuilding _type;
        private GameObject _currentProject;

        public override void CtrlZ() { }
        public override void OnBegan(GridCell cell) { }
        public override void OnEnded(GridCell cell) { }
        public override void OnCanceled(GridCell cell) { }
        public override void OnStationary(GridCell cell) { }

        public SecurityBehaviour(SecurityBuilding securityBuilding)
        {
            _type = securityBuilding;

            var pos = new Vector3(0, -10, 0);

            switch (_type)
            {
                case SecurityBuilding.SecurityCabin: _currentProject = GameController.InitObj(SecurityCabin.Data.Project, pos); break;
                case SecurityBuilding.PoliceStation: _currentProject = GameController.InitObj(PoliceStation.Data.Project, pos); break;
                case SecurityBuilding.PoliceHeadquarters: _currentProject = GameController.InitObj(PoliceHeadquarters.Data.Project, pos); break;
            }
        }

        public override void OnMoved(GridCell cell)
        {
            _currentProject.transform.position = cell.center;

            switch (_type)
            {
                case SecurityBuilding.SecurityCabin: Building.SetRenderer(_currentProject, SecurityCabin.IsBuildable(cell)); break;
                case SecurityBuilding.PoliceStation: Building.SetRenderer(_currentProject, PoliceStation.IsBuildable(cell)); break;
                case SecurityBuilding.PoliceHeadquarters: Building.SetRenderer(_currentProject, PoliceHeadquarters.IsBuildable(cell)); break;
            }
        }

        public override void Apply()
        {
            var pos = _currentProject.transform.position;

            switch (_type)
            {
                case SecurityBuilding.SecurityCabin: SecurityCabin.SetOnMap(pos); break;
                case SecurityBuilding.PoliceStation: PoliceStation.SetOnMap(pos); break;
                case SecurityBuilding.PoliceHeadquarters: PoliceHeadquarters.SetOnMap(pos); break;
            }

            Object.Destroy(_currentProject);
        }

        public override void Clean()
        {
            Object.Destroy(_currentProject);
        }
    }
}