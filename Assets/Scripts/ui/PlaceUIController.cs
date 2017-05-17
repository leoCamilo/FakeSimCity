using UnityEngine;

namespace Cariacity.game
{
    public class PlaceUIController : MonoBehaviour
    {
        public void LockUI()
        {
            lock (UiController.TouchOnUILock) { UiController.TouchOnUI = true; }
        }
    }
}
