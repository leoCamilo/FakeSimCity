using UnityEngine;

namespace Cariacity.game
{
    public class Street : Building
    {
        private const float value = 5;

        public static GameObject TModel;
        public static GameObject EndModel;
        public static GameObject LineModel;
        public static GameObject CornerModel;
        public static GameObject CrossingModel;
        public static GameObject Project;

        public static bool IsBuildable(GridCell _cell)
        {
            return _cell.obj == null;
        }

        public static void SetOnMap(GameObject item)
        {
            var pos = item.transform.position;
            var cell = Common.GetNearbyCell(pos);

            if (IsBuildable(cell))
            {
                cell.obj = item;
                Common.CurrentCity.StreetList.Add(cell);
            }
            else
                Object.Destroy(item);

            DebitFromMoney(value);
        }

        public static void RemoveFromMap(Vector3 pos)
        {
            var cell = Common.GetNearbyCell(pos);
            Object.Destroy(cell.obj);
            cell.obj = null;
        }

        public static void SetOrientation(Vector3 position, bool recursive)
        {
            var cell = Common.GetNearbyCell(position);

            if (cell.obj.tag == Tags.StreetProj || cell.obj.tag == Tags.Street)
            {
                var conections = 0;

                bool[] directions = { false, false, false, false };

                _compareSideCell(cell.i, cell.j + 1, 0, ref conections, directions, recursive);
                _compareSideCell(cell.i, cell.j - 1, 2, ref conections, directions, recursive);
                _compareSideCell(cell.i + 1, cell.j, 1, ref conections, directions, recursive);
                _compareSideCell(cell.i - 1, cell.j, 3, ref conections, directions, recursive);

                Object.Destroy(cell.obj);

                var tmp = StreetOrientation.GetOrientation(conections, directions);
                cell.obj = GameController.InitObj(tmp.Model, cell.center, tmp.Rotation);
                cell.type = GameModel.Get(tmp.Model);
            }
        }

        private static void _compareSideCell(int i, int j, int idx, ref int conections, bool[] directions, bool isRecursive)
        {
            GameObject obj;

            if (i >= 0 && i < Constants.GridSize && j >= 0 && j < Constants.GridSize)
            {
                obj = Common.Matrix[i, j].obj;

                if (obj == null) return;

                if (obj.tag == Tags.StreetProj)
                {
                    conections++;
                    directions[idx] = true;
                    return;
                }

                if (obj.tag == Tags.Street)
                {
                    if (isRecursive) SetOrientation(Common.Matrix[i, j].center, false);
                    conections++;
                    directions[idx] = true;
                }
            }
        }
    }
}
