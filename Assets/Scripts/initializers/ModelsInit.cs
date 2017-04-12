using UnityEngine;

namespace Cariacity.game
{
    public class ModelsInit : MonoBehaviour
    {
        public GameObject HospitalModel;
        public GameObject PoliceModel;

        public GameObject StreetTModel;
        public GameObject StreetEndModel;
        public GameObject StreetLineModel;
        public GameObject StreetCornerModel;
        public GameObject StreetCrossingModel;

        public GameObject HomeModel1;
        public GameObject HomeModel2;
        public GameObject HomeModel3;
        public GameObject HomeModel4;
        public GameObject HomeModel5;

        private void Awake()
        {
            Home.Model[0] = HomeModel1;
            Home.Model[1] = HomeModel2;
            Home.Model[2] = HomeModel3;
            Home.Model[3] = HomeModel4;
            Home.Model[4] = HomeModel5;

            Street.TModel = StreetTModel;
            Street.EndModel= StreetEndModel;
            Street.LineModel = StreetLineModel;
            Street.CornerModel = StreetCornerModel;
            Street.CrossingModel = StreetCrossingModel;

            Police.Model = PoliceModel;
            Hospital.Model = HospitalModel;
        }
    }
}