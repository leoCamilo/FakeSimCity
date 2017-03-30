using UnityEngine;

namespace Cariacity.game
{
    public class SubOption2 : MonoBehaviour
    {
        public void BtnHospital()
        {
            UiController.EnableEditionMode();

            CameraController.SetInsertionModel(Constants.HospitalTag);
            CameraController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnPolice()
        {
            UiController.EnableEditionMode();

            CameraController.SetInsertionModel(Constants.PoliceTag);
            CameraController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnSchool()
        {
            UiController.EnableEditionMode();

            CameraController.SetInsertionModel(Constants.SchoolTag);
            CameraController.SetCurrentMode(TouchBehavior.Building);
        }
    }
}