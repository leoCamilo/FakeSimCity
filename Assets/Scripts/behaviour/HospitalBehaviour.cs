using System;
using UnityEngine;

namespace Cariacity.game
{
    public class HospitalBehaviour : BuildingBehaviour
    {
        private GameObject _currentProject;

        public HospitalBehaviour()
        {
            _currentProject = GameController.InitObj(Hospital.Project, new Vector3(0, -10, 0));
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
            Hospital.SetOnMap(_currentProject.transform.position);
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
