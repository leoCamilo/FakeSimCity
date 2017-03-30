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
            UiController.EnableNormalMode();
        }
    }
}
