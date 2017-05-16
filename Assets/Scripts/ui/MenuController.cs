using UnityEngine;

namespace Cariacity.game
{
    public class MenuController : MonoBehaviour
    {
        public void ExitGame()
        {
            Application.Quit();
        }

        public void BackToGame()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }
            UiController.EnableNormalMode();
        }
    }
}
