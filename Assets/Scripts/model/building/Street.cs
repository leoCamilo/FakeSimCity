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

        public static void SetOrientation(Vector3 position)
        {
            GameObject obj;

            var mat = Common.Matrix;
            var cell = Common.GetNearbyCell(position);
            var conections = 0;
            bool[] directions = { false, false, false, false };

            if (cell.j + 1 < Constants.GridSize)
            {
                obj = mat[cell.i, cell.j + 1].obj;

                if (obj != null && obj.tag == Constants.StreetTag)
                {
                    conections++;
                    directions[0] = true;
                }
            }

            if (cell.i + 1 < Constants.GridSize)
            {
                obj = mat[cell.i + 1, cell.j].obj;

                if (obj != null && obj.tag == Constants.StreetTag)
                {
                    conections++;
                    directions[1] = true;
                }
            }

            if (cell.j - 1 >= 0)
            {
                obj = mat[cell.i, cell.j - 1].obj;

                if (obj != null && obj.tag == Constants.StreetTag)
                {
                    conections++;
                    directions[2] = true;
                }
            }

            if (cell.i - 1 >= 0)
            {
                obj = Common.Matrix[cell.i - 1, cell.j].obj;

                if (obj != null && obj.tag == Constants.StreetTag)
                {
                    conections++;
                    directions[3] = true;
                }
            }

            Object.Destroy(cell.obj);

            var tmp = StreetOrientation.GetOrientation(conections, directions);
            cell.obj = GameController.InitObj(tmp.Model, cell.center, tmp.Rotation);
        }

        public static void SetOnMap(GameObject item)
        {
            var pos = item.transform.position;
            var cell = Common.GetNearbyCell(pos);

            if (IsBuildable(cell))
                cell.obj = item;
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
    }
}
