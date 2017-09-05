using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cariacity.game
{
    public class GameLoader : MonoBehaviour
    {
        public Texture ProgressBar;
        public GameObject Buttons;

        private const string sceneName = "MainScene";
        private float progress;

        public void LoadGame()
        {
            Buttons.SetActive(false);
            StartCoroutine(LoadScene());
        }

        IEnumerator LoadScene()
        {
            var loading = SceneManager.LoadSceneAsync(sceneName);

            while (!loading.isDone)
            {
                progress = loading.progress;
                yield return null;
            }
                
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        private void OnGUI()
        {
            GUI.DrawTexture(new Rect(100, 350, progress * 600, 30), ProgressBar);
        }
    }
}
