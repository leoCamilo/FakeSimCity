using UnityEngine;

namespace Cariacity.game
{
    public class StuffInit : MonoBehaviour
    {
        public GameObject TreeModel;
        public GameObject Highlight;
        public GameObject CarModel;

        private void Awake()
        {
            Car.Models[0] = CarModel;
            Tree.Model = TreeModel;
            CommonModels.HighLightObj = Highlight;
        }
    }
}