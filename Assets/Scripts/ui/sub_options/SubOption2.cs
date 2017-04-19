using UnityEngine;

namespace Cariacity.game
{
    public class SubOption2 : MonoBehaviour
    {
        public void BtnHospital()
        {
            UiController.EnableEditionMode();

            GameplayController.SetInsertionModel(Constants.HospitalTag);
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnPolice()
        {
            UiController.EnableEditionMode();

            GameplayController.SetInsertionModel(Constants.PoliceTag);
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnSchool()
        {
            UiController.EnableEditionMode();

            GameplayController.SetInsertionModel(Constants.SchoolTag);
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }
    }
}