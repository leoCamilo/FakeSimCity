using System;
using UnityEngine;

namespace Cariacity.game
{
    public class SchoolBehaviour : BuildingBehaviour
    {
        private GameObject _currentProject;

        public SchoolBehaviour()
        {
            _currentProject = GameController.InitObj(School.Project, new Vector3(0, -10, 0));
        }

        public override void OnBegan(GridCell cell) { }

        public override void OnMoved(GridCell cell)
        {
            var c = cell.center;
            _currentProject.transform.position = new Vector3(c.x + Constants.HalfHypotenuse, c.y, c.z);
            Building.SetRenderer(_currentProject, School.IsBuildable(cell));
        }

        public override void OnEnded(GridCell cell) { throw new NotImplementedException(); }
        public override void OnCanceled(GridCell cell) { throw new NotImplementedException(); }
        public override void OnStationary(GridCell cell) { throw new NotImplementedException(); }

        public override void Apply()
        {
            School.SetOnMap(_currentProject.transform.position);
            UnityEngine.Object.Destroy(_currentProject);
        }

        public override void Clean()
        {
            UnityEngine.Object.Destroy(_currentProject);
        }

        public override void CtrlZ() { throw new NotImplementedException(); }
    }
}
