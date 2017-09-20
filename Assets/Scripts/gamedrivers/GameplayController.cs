using UnityEngine;

namespace Cariacity.game
{
    public class GameplayController : MonoBehaviour
    {
        private static TouchController _touchControl;
        private static TouchBehavior _currentMode;

        private void Start ()
        {
            _touchControl = new TouchController();
        }

        public static void SetInsertionModel (string type) { _touchControl.SetInsertionType(type); }
        public static void SetCurrentMode (TouchBehavior mode) { _currentMode = mode; }
        public static void CtrlZInsertion () { _touchControl.CtrlZ(); }

        public static void CancelInsertion()
        {
            _touchControl.Clean();
            _currentMode = TouchBehavior.Movment;
        }

        public static void AcceptInsertion()
        {
            _touchControl.Apply();
            _currentMode = TouchBehavior.Movment;
        }

        void LateUpdate()   // TODO: see best Update function
        {
            switch (_currentMode)
            {
                case TouchBehavior.Movment: _touchControl.MovmentMode(); break;
                case TouchBehavior.Building: _touchControl.StartInsertionMode(); break;
            }
        }
    }
}
