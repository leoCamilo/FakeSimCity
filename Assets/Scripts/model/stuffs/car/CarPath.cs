using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public class CarPath
    {
        public static CarAnimationDirection Get (GameObject car)
        {
            var list = new List<CarAnimationDirection>();
            var cell = Common.GetNearbyCell(car.transform.position);

            if (HasAhead(car, cell)) list.Add(CarAnimationDirection.Forward);
            if (HasRight(car, cell)) list.Add(CarAnimationDirection.Right);
            if (HasLeft(car, cell)) list.Add(CarAnimationDirection.Left);
            if (list.Count == 0)
            {
                list.Add(CarAnimationDirection.Return);
            }

            Debug.Log(car.transform.eulerAngles);

            return list[Random.Range(0, list.Count)];
        }

        private static bool IsStreet(int i, int j)
        {
            if (i >= 0 && i < Constants.GridSize && j >= 0 && j < Constants.GridSize)
            {
                var obj = Common.Matrix[i, j].obj;

                if (obj != null && obj.tag == Tags.Street)
                    return true;
            }

            return false;
        }

        private static bool HasAhead(GameObject car, GridCell cell)
        {
            var carRotation = (int) car.transform.eulerAngles.y;

            switch (carRotation)
            {
                case 345: return IsStreet(cell.i - 1, cell.j); // up
                case 45:  return IsStreet(cell.i, cell.j + 1); // right
                case 135: return IsStreet(cell.i + 1, cell.j); // down
                case 225: return IsStreet(cell.i, cell.j - 1); // left
            }

            return false;
        }

        private static bool HasRight(GameObject car, GridCell cell)
        {
            var carRotation = (int) car.transform.eulerAngles.y;

            switch (carRotation)
            {
                case 345: return IsStreet(cell.i - 1, cell.j) && IsStreet(cell.i - 1, cell.j + 1);
                case 45:  return IsStreet(cell.i, cell.j + 1) && IsStreet(cell.i + 1, cell.j + 1);
                case 135: return IsStreet(cell.i + 1, cell.j) && IsStreet(cell.i + 1, cell.j - 1);
                case 225: return IsStreet(cell.i, cell.j - 1) && IsStreet(cell.i - 1, cell.j - 1);
            }

            return false;
        }

        private static bool HasLeft(GameObject car, GridCell cell)
        {
            var carRotation = (int)car.transform.eulerAngles.y;

            switch (carRotation)
            {
                case 345: return IsStreet(cell.i - 1, cell.j) && IsStreet(cell.i - 1, cell.j - 1);
                case 45:  return IsStreet(cell.i, cell.j + 1) && IsStreet(cell.i - 1, cell.j + 1);
                case 135: return IsStreet(cell.i + 1, cell.j) && IsStreet(cell.i + 1, cell.j + 1);
                case 225: return IsStreet(cell.i, cell.j - 1) && IsStreet(cell.i + 1, cell.j - 1);
            }

            return false;
        }
    }
}
