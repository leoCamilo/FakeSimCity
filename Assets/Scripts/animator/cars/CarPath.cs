using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public class CarPath
    {
        public static List<int> Get (GameObject car)
        {
            var list = new List<int>();
            var cell = Common.GetNearbyCell(car.transform.position);
            
            for (int i = 0; i < 10; i++)
            {
                list.Add(Random.Range(0, 4));
            }

            return list;
        }
    }
}
