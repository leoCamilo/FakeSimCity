using UnityEngine;

namespace Cariacity.game
{
    public class MenuController : MonoBehaviour
    {
        public void ExitGame()
        {
            JsonSerializer.Save(SerializaCity.GetSave());
            Application.Quit();
        }

        public void BackToGame()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }
            UiController.EnableNormalMode();
        }
    }
}
