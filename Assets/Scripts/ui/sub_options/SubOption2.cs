using UnityEngine;

namespace Cariacity.game
{
    public class SubOption2 : MonoBehaviour
    {
        private const int SMALL = 0;
        private const int MEDIUM = 1;
        private const int BIG = 2;

        public void BtnHospital(int healthType)
        {
            switch (healthType)
            {
                case BIG: GameplayController.SetInsertionModel(Tags.Hospital); break;
                case SMALL: GameplayController.SetInsertionModel(Tags.FirstAidPost); break;
                case MEDIUM: GameplayController.SetInsertionModel(Tags.Clinic); break;
            }

            UiController.EnableEditionMode();
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnPolice(int securityType)
        {
            switch (securityType)
            {
                case BIG: GameplayController.SetInsertionModel(Tags.PoliceHeadquartes); break;
                case SMALL: GameplayController.SetInsertionModel(Tags.SecurityCabin); break;
                case MEDIUM: GameplayController.SetInsertionModel(Tags.PoliceStation); break;
            }

            UiController.EnableEditionMode();
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnSchool(int educationType)
        {
            switch (educationType)
            {
                case BIG: GameplayController.SetInsertionModel(Tags.University); break;
                case SMALL: GameplayController.SetInsertionModel(Tags.DayCarePost); break;
                case MEDIUM: GameplayController.SetInsertionModel(Tags.HighSchool); break;
            }

            UiController.EnableEditionMode();
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }
    }
}