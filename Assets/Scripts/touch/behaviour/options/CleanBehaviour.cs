using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public class CleanBehaviour : BuildingBehaviour
    {
        private Stack<GameObject> _cleaned;

        public CleanBehaviour()
        {
            _cleaned = new Stack<GameObject>();
        }

        public override void OnBegan(GridCell cell)
        {
            var building = cell.obj;

            if (!_cleaned.Contains(building))
            {
                building.SetActive(false);
                _cleaned.Push(building);
            }
        }

        public override void OnEnded(GridCell cell) {}
        public override void OnMoved(GridCell cell) {}
        public override void OnCanceled(GridCell cell) {}
        public override void OnStationary(GridCell cell) {}

        public override void Apply()
        {
            foreach (var item in _cleaned)
            {
                var pos = item.transform.position;
                // var cell = Common.GetNearbyCell(item.transform.position);

                switch (item.tag)
                {
                    case Constants.HomeTag: Home.RemoveFromMap(pos); break;
                    case Constants.StreetTag: Street.RemoveFromMap(pos); break;
                    case Constants.SchoolTag:
                    case Constants.PoliceTag: Police.RemoveFromMap(pos); break;
                    case Constants.HospitalTag: Hospital.RemoveFromMap(pos); break;
                }
            }
        }

        public override void Clean()
        {
            foreach (var item in _cleaned)
                item.SetActive(true);

            _cleaned.Clear();
        }

        public override void CtrlZ()
        {
            if (_cleaned.Count > 0)
            {
                var lastBuilding = _cleaned.Pop();
                lastBuilding.SetActive(true);
            }
        }
    }
}
