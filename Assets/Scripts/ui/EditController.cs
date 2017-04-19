using UnityEngine;

namespace Cariacity.game
{
    public class EditController : MonoBehaviour
    {
        public void BtnCancel()
        {
            UiController.EnableNormalMode();
            GameplayController.CancelInsertion();
        }

        public void BtnGiveup()
        {
            GameplayController.CtrlZInsertion();
        }

        public void BtnAccept()
        {
            UiController.EnableNormalMode();
            GameplayController.AcceptInsertion();
        }
    }
}
