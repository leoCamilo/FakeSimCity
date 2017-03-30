using System;
using UnityEngine;

namespace Cariacity.game
{
    public class Police : Building
    {
        private static float value = 200;

        public static GameObject Project;
        public static GameObject Model;

        private static int _influenceBound = 5;

        public static bool IsBuildable(GridCell cell)
        {
            return IsBuildable(cell, new Rectangle(1, 1, 1, 1));
        }

        public static void SetOnMap(Vector3 pos)
        {
            var cell = Common.GetNearbyCell(pos);

            if (IsBuildable(cell))
            {
                var _mat = Common.Matrix;
                var line = cell.i;
                var column = cell.j;

                cell.obj = GameController.InitObj(Model, pos);

                for (int i = line - 1; i < line + 2; i++)
                    for (int j = column - 1; j < column + 2; j++)
                        _mat[i, j].obj = cell.obj;

                var start_line = Mathf.Clamp(line - _influenceBound, 0, Constants.GridSize - 1);
                var end_line = Mathf.Clamp(line + _influenceBound, 0, Constants.GridSize - 1);
                var start_column = Mathf.Clamp(column - _influenceBound, 0, Constants.GridSize - 1);
                var end_column = Mathf.Clamp(column + _influenceBound, 0, Constants.GridSize - 1);

                for (int i = start_line; i <= end_line; i++)
                    for (int j = start_column; j <= end_column; j++)
                    {
                        var tmp = _mat[i, j].center;
                        _mat[i, j].status[(int)Status.Security] += _influenceBound / (new Vector3(tmp.x, 0, tmp.y) - pos).magnitude;
                    }
            }

            DebitFromMoney(value);
        }

        public static void RemoveFromMap(Vector3 pos)
        {
            var cell = Common.GetNearbyCell(pos);
            var mat = Common.Matrix;

            var line = cell.i;
            var column = cell.j;

            for (int i = line - 1; i < line + 2; i++)
                for (int j = column - 1; j < column + 2; j++)
                    mat[i, j].obj = null;

            var start_line = Mathf.Clamp(line - _influenceBound, 0, Constants.GridSize - 1);
            var end_line = Mathf.Clamp(line + _influenceBound, 0, Constants.GridSize - 1);
            var start_column = Mathf.Clamp(column - _influenceBound, 0, Constants.GridSize - 1);
            var end_column = Mathf.Clamp(column + _influenceBound, 0, Constants.GridSize - 1);

            for (int i = start_line; i <= end_line; i++)
                for (int j = start_column; j <= end_column; j++)
                {
                    var tmp = mat[i, j].center;
                    mat[i, j].status[(int)Status.Security] -= _influenceBound / (new Vector3(tmp.x, 0, tmp.y) - pos).magnitude;
                }
        }
    }
}
