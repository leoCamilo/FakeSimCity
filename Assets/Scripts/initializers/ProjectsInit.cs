using UnityEngine;

namespace Cariacity.game
{
    public class ProjectsInit : MonoBehaviour
    {
        public GameObject HospitalProject;
        public GameObject ClinicProject;
        public GameObject FirstAidProject;

        public GameObject SchoolProject;
        public GameObject UniversityProject;
        public GameObject DayCarePostProject;

        public GameObject SecurityCabinProject;
        public GameObject PoliceStationProject;
        public GameObject PoliceHeadquartesProject;

        public GameObject HomeProject;
        public GameObject StoreProject;
        public GameObject StreetProject;

        private void Awake()
        {
            Home.Project = HomeProject;
            Store.Project = StoreProject;
            Street.Project = StreetProject;

            Clinic.Data.Project = ClinicProject;
            Hospital.Data.Project = HospitalProject;
            FirstAidPost.Data.Project = FirstAidProject;

            HighSchool.Data.Project = SchoolProject;
            University.Data.Project = UniversityProject;
            DayCarePost.Data.Project = DayCarePostProject;

            SecurityCabin.Data.Project = SecurityCabinProject;
            PoliceStation.Data.Project = PoliceStationProject;
            PoliceHeadquarters.Data.Project = PoliceHeadquartesProject;
        }
    }
}
