using UnityEngine;

namespace Cariacity.game
{
    public class ProjectsInit : MonoBehaviour
    {
        public GameObject HomeProject;
        public GameObject HospitalProject;
        public GameObject PoliceProject;
        public GameObject SchoolProject;
        public GameObject StreetProject;

        private void Awake()
        {
            Hospital.Project = HospitalProject;
            Police.Project = PoliceProject;
            School.Project = SchoolProject;
            Street.Project = StreetProject;
            Home.Project = HomeProject;
        }
    }
}
