using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public static class GameModel
    {
        private static IList<GameObject> hashList = new List<GameObject>();

        public static void Add(GameObject model)
        {
            hashList.Add(model);
        }

        public static GameObject Get(int id)
        {
            return hashList[id];
        }

        public static int Get(GameObject model)
        {
            return hashList.IndexOf(model);
        }
    }
}