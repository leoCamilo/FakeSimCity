using UnityEngine;

namespace Cariacity.game
{
    public class SubOption1 : MonoBehaviour
    {
        public void BtnStreet()
        {
            UiController.EnableEditionMode();

            GameplayController.SetInsertionModel(Constants.StreetTag);
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnHome()
        {
            UiController.EnableEditionMode();

            GameplayController.SetInsertionModel(Constants.HomeTag);
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }
    }
}
