using UnityEngine;

namespace Cariacity.game
{
    public class Tree : Building
    {
        public static GameObject Model;

        public static void RemoveFromMap(Vector3 pos)
        {
            var cell = Common.GetNearbyCell(pos);
            Object.Destroy(cell.obj);
            Common.Matrix[cell.i, cell.j].obj = null;
        }
    }
}