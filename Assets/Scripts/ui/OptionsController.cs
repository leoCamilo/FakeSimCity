using UnityEngine;

namespace Cariacity.game
{
    public class OptionsController : MonoBehaviour
    {
        private Transform _UI;
        private bool _isActive;

        private static int _lastOption = 0;

        public void Start()
        {
            _UI = transform.parent.parent;
            _isActive = false;
        }

        public void BtnOption1()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }

            if (_lastOption == 1)
            {
                _isActive = !_isActive;
                _UI.GetChild(3).gameObject.SetActive(_isActive);
            }
            else
            {
                _isActive = true;
                _UI.GetChild(3).gameObject.SetActive(true);
            }

            _lastOption = 1;

            _UI.GetChild(4).gameObject.SetActive(false);
            _UI.GetChild(5).gameObject.SetActive(false);
        }

        public void BtnOption2()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }

            if (_lastOption == 2)
            {
                _isActive = !_isActive;
                _UI.GetChild(4).gameObject.SetActive(_isActive);
            }
            else
            {
                _isActive = true;
                _UI.GetChild(4).gameObject.SetActive(true);
            }

            _lastOption = 2;

            _UI.GetChild(3).gameObject.SetActive(false);
            _UI.GetChild(5).gameObject.SetActive(false);
        }

        public void BtnOption3()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }

            if (_lastOption == 3)
            {
                _isActive = !_isActive;
                _UI.GetChild(5).gameObject.SetActive(_isActive);
            }
            else
            {
                _isActive = true;
                _UI.GetChild(5).gameObject.SetActive(true);
            }

            _lastOption = 3;

            _UI.GetChild(3).gameObject.SetActive(false);
            _UI.GetChild(4).gameObject.SetActive(false);
        }

        public void BtnOption4()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }
            UiController.EnableEditionMode();

            GameplayController.SetInsertionModel(Tags.Clean);
            GameplayController.SetCurrentMode(TouchBehavior.Building);
        }

        public void BackBtn()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }
            UiController.EnableNormalMode();
        }
    }
}
