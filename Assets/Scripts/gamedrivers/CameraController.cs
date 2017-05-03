using UnityEngine;

namespace Cariacity.game
{
    public class CameraController : MonoBehaviour
    {
        private static GameObject _mainCamera;

        private void Start()
        {
            _mainCamera = gameObject;
        }

        public static void Move(float deltaX, float deltaY)
        {
            var camPos = _mainCamera.transform.position;

            var x = camPos.x + deltaX;
            var z = camPos.z + deltaY;

            camPos += new Vector3(
                ((x > -65 && x < 65) && ((Mathf.Abs(x) + Mathf.Abs(z)) < 80) ? deltaX : 0), 0,
                ((z > -75 && z < 55) && ((Mathf.Abs(x) + Mathf.Abs(z)) < 80) ? deltaY : 0)
            );

            _mainCamera.transform.position = camPos;
        }

        public static void SetZoom(float deltaZoom)
        {
            var currentSize = Camera.main.orthographicSize;
            Camera.main.orthographicSize = Mathf.Clamp(currentSize + deltaZoom, Constants.MinCameraZoom, Constants.MaxCameraZoom);
        }

        public static float GetZoom()
        {
            return Camera.main.orthographicSize;
        }
    }
}