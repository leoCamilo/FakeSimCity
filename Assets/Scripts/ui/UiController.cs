using UnityEngine;

namespace Cariacity.game
{
    public class UiController : MonoBehaviour {
        public static bool TouchOnUI;
        public static Object TouchOnUILock;
        private static Transform _UI;

        public void Start() {
            _UI = transform.parent.parent;
            TouchOnUILock = new Object();
        }

        public void BtnShowOptions()
        {
            lock (TouchOnUILock) { TouchOnUI = true; }

            _UI.GetChild(0).gameObject.SetActive(false);
            _UI.GetChild(1).gameObject.SetActive(true);
        }

        public void BtnShowMenu()
        {
            lock (TouchOnUILock) { TouchOnUI = true; }

            _UI.GetChild(0).gameObject.SetActive(false);
            _UI.GetChild(6).gameObject.SetActive(true);
        }

        public void LockUI()
        {
            lock (TouchOnUILock) { TouchOnUI = true; }
        }

        public static void EnableEditionMode()
        {
            _UI.GetChild(2).gameObject.SetActive(true);
            _UI.GetChild(0).gameObject.SetActive(false);
            _UI.GetChild(1).gameObject.SetActive(false);
            _UI.GetChild(3).gameObject.SetActive(false);
            _UI.GetChild(4).gameObject.SetActive(false);
            _UI.GetChild(5).gameObject.SetActive(false);
            _UI.GetChild(6).gameObject.SetActive(false);
        }

        public static void EnableNormalMode()
        {
            _UI.GetChild(0).gameObject.SetActive(true);
            _UI.GetChild(1).gameObject.SetActive(false);
            _UI.GetChild(2).gameObject.SetActive(false);
            _UI.GetChild(3).gameObject.SetActive(false);
            _UI.GetChild(4).gameObject.SetActive(false);
            _UI.GetChild(5).gameObject.SetActive(false);
            _UI.GetChild(6).gameObject.SetActive(false);
        }
    }
}