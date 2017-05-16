using UnityEngine;

namespace Cariacity.game
{
    public class MovementBehaviour
    {
        private float _lastZoom;

        private const int X = 0;
        private const int Y = 1;

        public void Movment(Touch myTouch)
        {
            var speed = Constants.AngleCoefficient * CameraController.GetZoom() + Constants.DisplacementCoefficient;
            var pos = myTouch.deltaPosition / speed;

            CameraController.Move(-pos[X], -pos[Y]);
        }

        public void Zoom(Touch finger1, Touch finger2)
        {
            var finger1Pos = finger1.position;
            var finger2Pos = finger2.position;

            var dis = (finger1Pos - finger2Pos).magnitude;
            
            CameraController.SetZoom(Mathf.Clamp(_lastZoom - dis, -0.2f, 0.2f));

            _lastZoom = dis;
        }

        public void HighLight(GridCell cell)
        {
            if (cell.obj != null)
            {
                Common.ShowInfo(cell.ToString());
                CommonModels.HighLightObj.transform.position = cell.center;
                CommonModels.HighLightObj.SetActive(true);
            }
        }
    }
}
