

using UnityEngine;

namespace Cariacity.game
{
    public class TouchController
    {
        private GameObject _camera;
        private float _lastZoom;

        public TouchController(GameObject camera)
        {
            _camera = camera;
        }

        public void Movment(Touch myTouch)
        {
            var pos = myTouch.deltaPosition / Constants.CameraSpeed;
            var xMovement = -pos[0];
            var yMovement = -pos[1];

            var camPos = _camera.transform.position;

            var x = camPos.x + xMovement;
            var z = camPos.z + yMovement;

            camPos += new Vector3(
                ((x > -65 && x < 65) && ((Mathf.Abs(x) + Mathf.Abs(z)) < 80) ? xMovement : 0), 0,
                ((z > -75 && z < 55) && ((Mathf.Abs(x) + Mathf.Abs(z)) < 80) ? yMovement : 0)
            );

            _camera.transform.position = camPos;
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
