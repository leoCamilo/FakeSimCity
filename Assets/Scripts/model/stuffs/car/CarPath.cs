using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public class CarPath
    {
        private static float up = -45;
        private static float right = 45;
        private static float down = 135;
        private static float left = -135;

        public static CarAnimationDirection Get (GameObject car)
        {
            var list = new List<CarAnimationDirection>();
            var cell = Common.GetNearbyCell(car.transform.position);

            if (HasAhead(car, cell))
                list.Add(CarAnimationDirection.Forward);

            if (HasRight(cell))
                list.Add(CarAnimationDirection.Right);

            if (HasLeft(cell))
                list.Add(CarAnimationDirection.Left);

            if (list.Count == 0)
                list.Add(CarAnimationDirection.Return);

            return list[Random.Range(0, list.Count)];
        }

        private static bool HasAhead(GameObject car, GridCell cell)
        {
            if (cell.i - 1 >= 0)
            {
                return true;
            }

            var carRotation = car.transform.rotation.y;

            if (carRotation == up)
            {
                if (cell.i - 1 >= 0)
                {
                    return true;
                }
            }

            /*
            if (carRotation == right)
            {
                if (cell.i - 1 >= 0)
                {
                    return true;
                }
            }

            if (carRotation == down)
            {
                if (cell.i - 1 >= 0)
                {
                    return true;
                }
            }

            if (carRotation == left)
            {
                if (cell.i - 1 >= 0)
                {
                    return true;
                }
            }
            */

            return false;
        }

        private static bool HasRight(GridCell cell)
        {
            return false;
        }

        private static bool HasLeft(GridCell cell)
        {
            return false;
        }
    }
}
