using System.Collections.Generic;
using UnityEngine;

namespace Cariacity.game
{
    public class CarPath
    {

        private const int upAngle = 315;
        private const int downAngle = 135;
        private const int leftAngle = 225;
        private const int rightAngle = 45;

        public static CarAnimationDirection Get (GameObject car)
        {
            var list = new List<CarAnimationDirection>();
            var cell = Common.GetNearbyCell(car.transform.position);
            var yAngle = NearbyCorrespondent(car.transform.eulerAngles.y);

            car.transform.eulerAngles = new Vector3(0, yAngle, 0);
            car.transform.position = cell.center;

            if (HasAhead(yAngle, cell)) list.Add(CarAnimationDirection.Forward);
            if (HasRight(yAngle, cell)) list.Add(CarAnimationDirection.Right);
            if (HasLeft(yAngle, cell)) list.Add(CarAnimationDirection.Left);
            if (list.Count == 0) { list.Add(CarAnimationDirection.Return); }

            return list[Random.Range(0, list.Count)];
        }

        private static int NearbyCorrespondent(float val)
        {
            if (Mathf.Abs(Mathf.Abs(val) - leftAngle) < 5)  return leftAngle;
            if (Mathf.Abs(Mathf.Abs(val) - downAngle) < 5)  return downAngle;
            if (Mathf.Abs(Mathf.Abs(val) - upAngle) < 5)    return upAngle;

            return rightAngle;
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

        private static bool HasAhead(int carAngle, GridCell cell)
        {
            switch (carAngle)
            {
                case upAngle:       return IsStreet(cell.i - 1, cell.j) && IsStreet(cell.i - 2, cell.j); // up
                case rightAngle:    return IsStreet(cell.i, cell.j + 1) && IsStreet(cell.i, cell.j + 2); // right
                case downAngle:     return IsStreet(cell.i + 1, cell.j) && IsStreet(cell.i + 2, cell.j); // down
                case leftAngle:     return IsStreet(cell.i, cell.j - 1) && IsStreet(cell.i, cell.j - 2); // left
            }

            return false;
        }

        private static bool HasRight(int carAngle, GridCell cell)
        {
            switch (carAngle)
            {
                case upAngle:       return IsStreet(cell.i - 1, cell.j) && IsStreet(cell.i - 1, cell.j + 1);
                case rightAngle:    return IsStreet(cell.i, cell.j + 1) && IsStreet(cell.i + 1, cell.j + 1);
                case downAngle:     return IsStreet(cell.i + 1, cell.j) && IsStreet(cell.i + 1, cell.j - 1);
                case leftAngle:     return IsStreet(cell.i, cell.j - 1) && IsStreet(cell.i - 1, cell.j - 1);
            }

            return false;
        }

        private static bool HasLeft(int carAngle, GridCell cell)
        {
            switch (carAngle)
            {
                case upAngle:       return IsStreet(cell.i - 1, cell.j) && IsStreet(cell.i - 1, cell.j - 1);
                case rightAngle:    return IsStreet(cell.i, cell.j + 1) && IsStreet(cell.i - 1, cell.j + 1);
                case downAngle:     return IsStreet(cell.i + 1, cell.j) && IsStreet(cell.i + 1, cell.j + 1);
                case leftAngle:     return IsStreet(cell.i, cell.j - 1) && IsStreet(cell.i + 1, cell.j - 1);
            }

            return false;
        }
    }
}
