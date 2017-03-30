using UnityEngine;

namespace Cariacity.game
{
    public class SubOption1 : MonoBehaviour
    {
        public void BtnStreet()
        {
            UiController.EnableEditionMode();

            CameraController.SetInsertionModel(Constants.StreetTag);
            CameraController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnHome()
        {
            UiController.EnableEditionMode();

            CameraController.SetInsertionModel(Constants.HomeTag);
            CameraController.SetCurrentMode(TouchBehavior.Building);
        }
    }
}
