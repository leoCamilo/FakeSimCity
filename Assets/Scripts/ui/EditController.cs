using UnityEngine;

namespace Cariacity.game
{
    public class EditController : MonoBehaviour
    {
        public void BtnCancel()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }
            UiController.EnableNormalMode();
            GameplayController.CancelInsertion();
        }

        public void BtnGiveup()
        {
            GameplayController.CtrlZInsertion();
        }

        public void BtnAccept()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }
            UiController.EnableNormalMode();
            GameplayController.AcceptInsertion();
        }
    }
}
