using System;
using UnityEngine;

namespace Cariacity.game
{
    public class School : Building
    {
        // private static float value = 500;

        public static GameObject Project;
        public static GameObject Model;

        // private static int _influenceBound = 5;

        public static bool IsBuildable(GridCell cell)
        {
            return IsBuildable(cell, new Rectangle(0, 1, 1, 0));
        }

        public static void SetOnMap(Vector3 pos)
        {
        }
    }
}
