using UnityEngine;

namespace Cariacity.game
{
    public class ModelsInit : MonoBehaviour
    {
        public GameObject ClinicModel;
        public GameObject HospitalModel;
        public GameObject FirsAidPostModel;

        public GameObject SchoolModel;
        public GameObject UniversityModel;
        public GameObject DayCarePostModel;

        public GameObject SecurityCabinModel;
        public GameObject PoliceStationModel;
        public GameObject PoliceHeadquartesModel;

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

        public GameObject TreeModel;
        public GameObject Highlight;

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

            Clinic.Data.Model = ClinicModel;
            Hospital.Model = HospitalModel;
            FirstAidPost.Data.Model = FirsAidPostModel;

            School.Data.Model = SchoolModel;
            University.Data.Model = UniversityModel;
            DayCarePost.Data.Model = DayCarePostModel;

            SecurityCabin.Data.Model = SecurityCabinModel;
            PoliceStation.Data.Model = PoliceStationModel;
            PoliceHeadquarters.Data.Model = PoliceHeadquartesModel;

            Tree.Model = TreeModel;

            CommonModels.HighLightObj = Highlight;
        }
    }
}