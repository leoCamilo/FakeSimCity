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

        public GameObject StoreModel1;

        private void Awake()
        {
            GameModel.Add(Home.Model[0] = HomeModel1);
            GameModel.Add(Home.Model[1] = HomeModel2);
            GameModel.Add(Home.Model[2] = HomeModel3);
            GameModel.Add(Home.Model[3] = HomeModel4);
            GameModel.Add(Home.Model[4] = HomeModel5);
            GameModel.Add(Store.Model = StoreModel1);
            GameModel.Add(Street.TModel = StreetTModel);
            GameModel.Add(Street.EndModel= StreetEndModel);
            GameModel.Add(Street.LineModel = StreetLineModel);
            GameModel.Add(Street.CornerModel = StreetCornerModel);
            GameModel.Add(Street.CrossingModel = StreetCrossingModel);
            GameModel.Add(Clinic.Data.Model = ClinicModel);
            GameModel.Add(Hospital.Data.Model = HospitalModel);
            GameModel.Add(FirstAidPost.Data.Model = FirsAidPostModel);
            GameModel.Add(HighSchool.Data.Model = SchoolModel);
            GameModel.Add(University.Data.Model = UniversityModel);
            GameModel.Add(DayCarePost.Data.Model = DayCarePostModel);
            GameModel.Add(SecurityCabin.Data.Model = SecurityCabinModel);
            GameModel.Add(PoliceStation.Data.Model = PoliceStationModel);
            GameModel.Add(PoliceHeadquarters.Data.Model = PoliceHeadquartesModel);
        }
    }
}