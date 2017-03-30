using UnityEngine;

namespace Cariacity.game
{
    public class EditController : MonoBehaviour
    {
        public void BtnCancel()
        {
            UiController.EnableNormalMode();
            CameraController.CancelInsertion();
        }

        public void BtnGiveup()
        {
            CameraController.CtrlZInsertion();
        }

        public void BtnAccept()
        {
            UiController.EnableNormalMode();
            CameraController.AcceptInsertion();
        }
    }
}
