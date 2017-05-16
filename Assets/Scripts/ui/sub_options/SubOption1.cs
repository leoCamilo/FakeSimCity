using UnityEngine;

namespace Cariacity.game
{
    public class SubOption1 : MonoBehaviour
    {
        public void BtnStreet()
        {
            UiController.EnableEditionMode();

            GameplayController.SetInsertionModel(Tags.Street);
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BtnHome()
        {
            UiController.EnableEditionMode();

            GameplayController.SetInsertionModel(Tags.Home);
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }
    }
}
