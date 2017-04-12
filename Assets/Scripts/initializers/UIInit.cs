using UnityEngine;

namespace Cariacity.game
{
    public class UIInit : MonoBehaviour
    {
        public GameObject Logger;
        public GameObject Info;
        public GameObject Money;
        public GameObject Happyness;

        private void Awake()
        {
            Common.Logger = Logger;
            Common.Info = Info;
            Common.Money = Money;
            Common.Happyness = Happyness;
        }
    }
}
