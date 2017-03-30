using UnityEngine;

namespace Cariacity.game
{
    public class Street : Building
    {
        private const float value = 5;
        public static GameObject Model;

        public static bool IsBuildable(GridCell _cell)
        {
            return _cell.obj == null;
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
