using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public class StreetBehaviour : BuildingBehaviour
    {
        private float _timer;
        private GridCell _firstCell;
        private IList<GameObject> _project;
        private Stack<IList<GameObject>> _projects;

        public override void OnCanceled (GridCell cell) { }
        public override void OnStationary (GridCell cell) { }

        public StreetBehaviour()
        {
            _projects = new Stack<IList<GameObject>>();
        }

        public override void OnBegan(GridCell cell)
        {
            _timer = Time.time;
            _firstCell = cell;
            _project = new List<GameObject>();
        }

        public override void OnMoved(GridCell cell)     // TODO: slow, make it faster
        {
            if (Street.IsBuildable(cell))
            {
                foreach (var item in _project)
                    UnityEngine.Object.Destroy(item);

                _project.Clear();   // not remove all | verify if is the same path

                var deltaI = cell.i - _firstCell.i;
                var deltaJ = cell.j - _firstCell.j;

                var limitI = _firstCell.i + deltaI;
                var limitJ = _firstCell.j + deltaJ;

                if (Mathf.Abs(deltaI) > Mathf.Abs(deltaJ))
                {
                    var i = _firstCell.i;
                    var increase = deltaI > 0 ? 1 : -1;

                    while (i != limitI)
                    {
                        var tmpCell = Common.Matrix[i, _firstCell.j];
                        _project.Add(GameController.InitObj(Street.Project, tmpCell.center));
                        i += increase;
                    }
                }
                else
                {
                    var j = _firstCell.j;
                    var increase = deltaJ > 0 ? 1 : -1;

                    while (j != limitJ)
                    {
                        var tmpCell = Common.Matrix[_firstCell.i, j];
                        _project.Add(GameController.InitObj(Street.Project, tmpCell.center));
                        j += increase;
                    }
                }
            }
        }

        public override void OnEnded(GridCell cell)
        {
            if (Time.time - _timer < 0.2)
            {
                for (int i = 0; i < _project.Count; i++)
                    if (_project[i].transform.position == cell.center)
                    {
                        UnityEngine.Object.Destroy(_project[i]);
                        _project.RemoveAt(i);
                    }
            }
            else
                _projects.Push(_project);
        }

        public override void Apply()
        {
            foreach (var list in _projects)
                foreach (var item in list)
                    Street.SetOnMap(item);

            foreach (var list in _projects)
                foreach (var item in list)
                    Street.SetOrientation(item.transform.position, true);
        }

        public override void Clean()
        {
            foreach (var list in _projects)
                foreach (var item in list)
                    UnityEngine.Object.Destroy(item);
        }

        public override void CtrlZ()
        {
            var list = _projects.Pop();

            foreach (var item in list)
                UnityEngine.Object.Destroy(item);
        }
    }
}
