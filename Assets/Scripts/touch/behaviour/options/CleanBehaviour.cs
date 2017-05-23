using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public class CleanBehaviour : BuildingBehaviour
    {
        private Stack<GameObject> _cleaned;

        public override void OnEnded(GridCell cell) { }
        public override void OnMoved(GridCell cell) { }
        public override void OnCanceled(GridCell cell) { }
        public override void OnStationary(GridCell cell) { }

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

        public override void Apply()
        {
            foreach (var item in _cleaned)
            {
                var pos = item.transform.position;

                switch (item.tag)
                {
                    case Tags.Tree: Tree.RemoveFromMap(pos); break;
                    case Tags.Home: Home.RemoveFromMap(pos); break;
                    case Tags.Street: Street.RemoveFromMap(pos); break;
                    case Tags.Clinic: Clinic.RemoveFromMap(pos); break;
                    case Tags.Hospital: Hospital.RemoveFromMap(pos); break;
                    case Tags.HighSchool: HighSchool.RemoveFromMap(pos); break;
                    case Tags.FirstAidPost: FirstAidPost.RemoveFromMap(pos); break;
                    case Tags.PoliceStation:PoliceStation.RemoveFromMap(pos); break;
                    case Tags.SecurityCabin: SecurityCabin.RemoveFromMap(pos); break;
                }

                Object.Destroy(item);
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
