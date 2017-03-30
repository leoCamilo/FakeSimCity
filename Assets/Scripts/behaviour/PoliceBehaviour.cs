using System;
using UnityEngine;

namespace Cariacity.game
{
    class PoliceBehaviour : BuildingBehaviour
    {
        private GameObject _currentProject;

        public PoliceBehaviour()
        {
            _currentProject = GameController.InitObj(Police.Project, new Vector3(0, -10, 0));
        }

        public override void OnBegan(GridCell cell) {}

        public override void OnMoved(GridCell cell)
        {
            _currentProject.transform.position = cell.center;
            Building.SetRenderer(_currentProject, Hospital.IsBuildable(cell));
        }

        public override void OnEnded(GridCell cell) { throw new NotImplementedException(); }
        public override void OnCanceled(GridCell cell) { throw new NotImplementedException(); }
        public override void OnStationary(GridCell cell) { throw new NotImplementedException(); }

        public override void Apply()
        {
            Police.SetOnMap(_currentProject.transform.position);
            UnityEngine.Object.Destroy(_currentProject);
        }

        public override void Clean()
        {
            UnityEngine.Object.Destroy(_currentProject);
        }

        public override void CtrlZ()
        {
            throw new NotImplementedException();
        }
    }
}