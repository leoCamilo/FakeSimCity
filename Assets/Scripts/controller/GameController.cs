using System.Collections;
using UnityEngine;

namespace Cariacity.game
{
    public class GameController : MonoBehaviour
    {
        public GameObject Test;

        public Material RightProject;
        public Material WrongProject;

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

            _mat[49, 49].obj = InitObj(Street.Project, _mat[49, 49].center);
            _mat[49, 50].obj = InitObj(Street.Project, _mat[49, 50].center);
            _mat[50, 50].obj = InitObj(Street.Project, _mat[50, 50].center);

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
            Common.RightProject = RightProject;
            Common.WrongProject = WrongProject;
        }

        private static IEnumerator _service(float timer)
        {
            while (true)
            {
                yield return new WaitForSeconds(timer);

                Debug.Log("working");
                int population = 0;
                var city = Common.CurrentCity;

                foreach (var home in city.HomeList)
                {
                    var progress = City.CalculateCellProgress(home);
                    population += (int) progress;
                }

                city.Population = population;
                Common.UpdatePopulation();
            }
        }
    }
}