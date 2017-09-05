using UnityEngine;

namespace Cariacity.game
{
    public class Hospital : Building
    {
        public static BuildingData Data = new BuildingData
        {
            Bounds = new Rectangle(1, 1, 1, 1),
            InfuenceType = (int)Status.Health,
            InfluenceBound = 7,
            Value = 500
        };

        public static bool IsBuildable(GridCell cell)
        {
            return IsBuildable(cell, Data.Bounds);
        }

        public static void SetOnMap(Vector3 pos)
        {
            if (IsBuildable(Common.GetNearbyCell(pos)))
            {
                SetOnMap(pos, Data);
                DebitFromMoney(Data.Value);
            }
        }

        public static void RemoveFromMap(Vector3 pos)
        {
            RemoveFromMap(pos, Data);
        }
    }
}
