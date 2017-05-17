using UnityEngine;

namespace Cariacity.game
{
    class Store : Building
    {
        private static float value = 20;

        public static GameObject Project;
        public static GameObject Model;

        private static int _isBuildable(GridCell _cell)
        {
            GameObject _obj;

            if (_cell.obj != null)
                return 0;

            if (_cell.j + 1 < Constants.GridSize)
            {
                _obj = Common.Matrix[_cell.i, _cell.j + 1].obj;
                if (_obj != null && _obj.tag == Tags.Street) return 1;
            }

            if (_cell.i + 1 < Constants.GridSize)
            {
                _obj = Common.Matrix[_cell.i + 1, _cell.j].obj;
                if (_obj != null && _obj.tag == Tags.Street) return 2;
            }

            if (_cell.j - 1 >= 0)
            {
                _obj = Common.Matrix[_cell.i, _cell.j - 1].obj;
                if (_obj != null && _obj.tag == Tags.Street) return 3;
            }

            if (_cell.i - 1 >= 0)
            {
                _obj = Common.Matrix[_cell.i - 1, _cell.j].obj;
                if (_obj != null && _obj.tag == Tags.Street) return 4;
            }

            return 0;
        }

        public static bool IsBuildable(GridCell _cell)
        {
            return _isBuildable(_cell) != 0;
        }

        public static void SetOnMap(Vector3 pos)
        {
            var cell = Common.GetNearbyCell(pos);
            var rotation = _isBuildable(cell);

            switch (rotation)
            {
                case 1: cell.obj = GameController.InitObj(Model, pos, Quaternion.Euler(0, 135, 0)); break;
                case 2: cell.obj = GameController.InitObj(Model, pos, Quaternion.Euler(0, 225, 0)); break;
                case 3: cell.obj = GameController.InitObj(Model, pos, Quaternion.Euler(0, 315, 0)); break;
                case 4: cell.obj = GameController.InitObj(Model, pos, Quaternion.Euler(0, 45, 0)); break;
            }

            DebitFromMoney(value);
            Common.CurrentCity.HomeList.Add(cell);
        }

        public static void RemoveFromMap(Vector3 pos)
        {
            var cell = Common.GetNearbyCell(pos);
            Object.Destroy(cell.obj);
            cell.obj = null;
        }
    }
}
