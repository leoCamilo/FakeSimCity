using System;
using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    class HomeBehaviour : BuildingBehaviour
    {
        private float _timer;
        private IList<GameObject> _projects;

        public HomeBehaviour()
        {
            _projects = new List<GameObject>();
        }

        public override void OnBegan(GridCell cell)
        {
            _timer = Time.time;
        }

        public override void OnMoved(GridCell cell)
        {
            if (Home.IsBuildable(cell))
            {
                foreach (var item in _projects)
                    if (item.transform.position == cell.center)
                        return;

                _projects.Add(GameController.InitObj(Home.Project, cell.center));
            };
        }

        public override void OnEnded(GridCell cell)
        {
            if (Time.time - _timer < 0.2)
                for (int i = 0; i < _projects.Count; i++)
                    if (_projects[i].transform.position == cell.center)
                    {
                        UnityEngine.Object.Destroy(_projects[i]);
                        _projects.RemoveAt(i);
                    }
        }

        public override void OnCanceled(GridCell cell) { throw new NotImplementedException(); }
        public override void OnStationary(GridCell cell) { throw new NotImplementedException(); }

        public override void Apply()
        {
            foreach (var item in _projects)
            {
                Home.SetOnMap(item.transform.position);
                UnityEngine.Object.Destroy(item);
            }
        }

        public override void Clean()
        {
            foreach (var item in _projects)
                UnityEngine.Object.Destroy(item);
        }

        public override void CtrlZ()
        {
            throw new NotImplementedException();
        }
    }
}
