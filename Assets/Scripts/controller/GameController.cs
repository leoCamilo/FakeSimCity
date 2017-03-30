using System.Collections;
using UnityEngine;

namespace Cariacity.game
{
    public class GameController : MonoBehaviour
    {
        public GameObject Test;

        public GameObject HomeProject;
        public GameObject HomeModel1;
        public GameObject HomeModel2;
        public GameObject HomeModel3;
        public GameObject HomeModel4;
        public GameObject HomeModel5;

        public GameObject HospitalProject;
        public GameObject HospitalModel;
        public GameObject PoliceProject;
        public GameObject PoliceModel;
        public GameObject StreetModel;
        public GameObject SchoolProject;

        public Material RightProject;
        public Material WrongProject;

        public GameObject Logger;
        public GameObject Info;
        public GameObject Money;

        private IEnumerator _mainService;

        // -------------------------- fps counter
        int m_frameCounter = 0;
        float m_timeCounter = 0.0f;
        float m_lastFramerate = 0.0f;
        public float m_refreshTime = 0.5f;

        void Update()
        {
            if (m_timeCounter < m_refreshTime)
            {
                m_timeCounter += Time.deltaTime;
                m_frameCounter++;
            }
            else
            {
                //This code will break if you set your m_refreshTime to 0, which makes no sense.
                m_lastFramerate = (float)m_frameCounter / m_timeCounter;
                m_frameCounter = 0;
                m_timeCounter = 0.0f;
                Common.Log("FPS: " + m_lastFramerate);
            }
        }

        void Start()
        {
            _setCommonData();
            _mainService = _service(Constants.BackgroundTimer);
            StartCoroutine(_mainService);

            /* for show the grid
            for (int i = 0; i < Common.GridSize; i++)
            {
                var tmpVec3 = new Vector3(i * Common.Hypotenuse, 0, 0);
                Instantiate(LineModel, tmpVec3, Quaternion.Euler(90, 45, 0));
                Instantiate(LineModel, tmpVec3, Quaternion.Euler(90, -45, 0));
                tmpVec3 = -tmpVec3;
                Instantiate(LineModel, tmpVec3, Quaternion.Euler(90, 45, 0));
                Instantiate(LineModel, tmpVec3, Quaternion.Euler(90, -45, 0));
            } */

            var _mat = new GridCell[Constants.GridSize, Constants.GridSize];
            var _0idxPos = new Vector2(0, (Constants.GridSize / 2) * Constants.Hypotenuse - Constants.HalfHypotenuse);

            for (int i = 0; i < Constants.GridSize; i++)
            {
                var _currentPos = _0idxPos;

                for (int j = 0; j < Constants.GridSize; j++)
                {
                    _mat[i, j] = new GridCell();
                    _mat[i, j].i = i;
                    _mat[i, j].j = j;
                    _mat[i, j].center = new Vector3(_currentPos.x, 0, _currentPos.y);
                    _currentPos += new Vector2(Constants.HalfHypotenuse, -Constants.HalfHypotenuse);

                    // InitObj(Test, _mat[i, j].center);
                }

                _0idxPos += new Vector2(-Constants.HalfHypotenuse, -Constants.HalfHypotenuse);
            }

            // _mat[0, 50].obj = InitObj(StreetModel, _mat[0, 50].center); // Initial road

            _mat[49, 49].obj = InitObj(StreetModel, _mat[49, 49].center);
            _mat[49, 50].obj = InitObj(StreetModel, _mat[49, 50].center);
            _mat[50, 50].obj = InitObj(StreetModel, _mat[50, 50].center);

            Common.Matrix = _mat;
            Common.UpdateMoney();
        }

        public static GameObject InitObj(GameObject model, Vector3 pos)
        {
            return Instantiate(model, pos, Quaternion.Euler(0, 45, 0));
        }

        public static GameObject InitObj(GameObject model, Vector3 pos, Quaternion rotation)
        {
            return Instantiate(model, pos, rotation);
        }

        private void _setCommonData()
        {
            Hospital.Project = HospitalProject;
            Hospital.Model = HospitalModel;

            Police.Project = PoliceProject;
            Police.Model = PoliceModel;

            Street.Model = StreetModel;

            School.Model = SchoolProject;
            School.Project = SchoolProject;

            Home.Project = HomeProject;
            Home.Model[0] = HomeModel1;
            Home.Model[1] = HomeModel2;
            Home.Model[2] = HomeModel3;
            Home.Model[3] = HomeModel4;
            Home.Model[4] = HomeModel5;

            Common.RightProject = RightProject;
            Common.WrongProject = WrongProject;

            Common.Logger = Logger;
            Common.Info = Info;
            Common.Money = Money;
        }

        private static IEnumerator _service(float timer)
        {
            while (true)
            {
                yield return new WaitForSeconds(timer);
                // Debug.Log("tempo: " + Time.time);
                // do action here
            }
        }
    }
}