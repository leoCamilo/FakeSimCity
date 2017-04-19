using UnityEngine;

namespace Cariacity.game
{
    public class MovementBehaviour
    {
        private float _lastZoom;

        public void Movment(Touch myTouch)
        {
            var pos = myTouch.deltaPosition / Constants.CameraSpeed;
            CameraController.Move(-pos[0], -pos[1]);
        }

        public void Zoom(Touch finger1, Touch finger2)
        {
            var finger1Pos = finger1.position;
            var finger2Pos = finger2.position;

            var dis = (finger1Pos - finger2Pos).magnitude;
            
            CameraController.SetZoom(Mathf.Clamp(_lastZoom - dis, -0.2f, 0.2f));

            _lastZoom = dis;
        }
    }
}
