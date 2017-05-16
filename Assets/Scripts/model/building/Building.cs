using System;
using UnityEngine;

namespace Cariacity.game
{
    public enum BuildType { Street, Home, Police, Hospital }

    public class Building
    {
        public static void SetRenderer(GameObject _obj, bool isOk)
        {
            var _currentRenderer = _obj.GetComponent<Renderer>();

            if (_currentRenderer == null)
            {
                _currentRenderer = _obj.GetComponentInChildren<Renderer>();
                var _mat = isOk ? Common.RightProject : Common.WrongProject;

                _currentRenderer.material = _mat;

                for (int i = 0; i < _currentRenderer.materials.Length; i++)
                    _currentRenderer.materials[i] = _mat;

                return;
            }

            _currentRenderer.material = isOk ? Common.RightProject : Common.WrongProject;
        }

        public static void DebitFromMoney(float value)
        {
            Common.CurrentCity.Money -= value;
        }

        protected static bool IsBuildable(GridCell cell, Rectangle bounds)
        {
            var x0 = cell.i - bounds.top;
            var x1 = cell.i + bounds.bottom;
            var y0 = cell.j - bounds.left;
            var y1 = cell.j + bounds.right;

            if (x0 < 0 || x1 > (Constants.GridSize - 1) || y0 < 0 || y1 > (Constants.GridSize - 1))
                return false;

            for (int i = x0; i <= x1; i++)
                for (int j = y0; j <= y1; j++)
                    if (Common.Matrix[i, j].obj != null)
                        return false;

            GameObject _obj;

            for (int i = x0 - 1; i < x1 + 2; i++)
            {
                try { _obj = Common.Matrix[i, y0 - 1].obj; } catch (IndexOutOfRangeException) { _obj = null; }

                if (_obj != null && _obj.tag == Tags.Street)
                    return true;

                try { _obj = Common.Matrix[i, y1 + 1].obj; } catch (IndexOutOfRangeException) { _obj = null; }

                if (_obj != null && _obj.tag == Tags.Street)
                    return true;
            }

            for (int j = y0 - 1; j < y1 + 2; j++)
            {
                try { _obj = Common.Matrix[x0 - 1, j].obj; } catch (IndexOutOfRangeException) { _obj = null; }

                if (_obj != null && _obj.tag == Tags.Street)
                    return true;

                try { _obj = Common.Matrix[x1 + 1, j].obj; } catch (IndexOutOfRangeException) { _obj = null; }

                if (_obj != null && _obj.tag == Tags.Street)
                    return true;
            }

            return false;
        }
    }
}