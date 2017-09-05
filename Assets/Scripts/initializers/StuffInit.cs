using UnityEngine;

namespace Cariacity.game
{
    public class StuffInit : MonoBehaviour
    {
        public GameObject TreeModel;
        public GameObject CarModel;
        public GameObject Highlight;
        public GameObject InfluenceArea;

        private void Awake()
        {
            GameModel.Add(Car.Models[0] = CarModel);
            GameModel.Add(Tree.Model = TreeModel);

            CommonModels.HighLightObj = Highlight;
            CommonModels.InfluenceObj = InfluenceArea;
        }
    }
}