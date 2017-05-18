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
                // Common.Log("FPS: " + m_lastFramerate);
            }
        }

        void Start()
        {
            _setCommonData();
            _mainService = _service(Constants.BackgroundTimer);

            StartCoroutine(_mainService);

            var matrix = new GridCell[Constants.GridSize, Constants.GridSize];
            var _0idxPos = new Vector2(0, (Constants.GridSize / 2) * Constants.Hypotenuse - Constants.HalfHypotenuse);

            for (int i = 0; i < Constants.GridSize; i++)
            {
                var _currentPos = _0idxPos;

                for (int j = 0; j < Constants.GridSize; j++)
                {
                    matrix[i, j] = new GridCell
                    {
                        i = i,
                        j = j,
                        center = new Vector3(_currentPos.x, 0, _currentPos.y)
                    };

                    _currentPos += new Vector2(Constants.HalfHypotenuse, -Constants.HalfHypotenuse);

                    if (Random.Range(0, 100) < Constants.TreeProbability)
                        matrix[i, j].obj = InitObj(Tree.Model, matrix[i, j].center, Quaternion.Euler(-90, Random.Range(0, 360), 0));
                }

                _0idxPos += new Vector2(-Constants.HalfHypotenuse, -Constants.HalfHypotenuse);
            }

            // _mat[0, 50].obj = InitObj(StreetModel, _mat[0, 50].center); // Initial road

            matrix[23, 24].obj = InitObj(Street.Project, matrix[23, 24].center);
            matrix[24, 24].obj = InitObj(Street.Project, matrix[24, 24].center);
            matrix[25, 24].obj = InitObj(Street.Project, matrix[25, 24].center);
            matrix[26, 24].obj = InitObj(Street.Project, matrix[26, 24].center);
            matrix[27, 24].obj = InitObj(Street.Project, matrix[27, 24].center);
            matrix[28, 24].obj = InitObj(Street.Project, matrix[28, 24].center);
            matrix[29, 24].obj = InitObj(Street.Project, matrix[29, 24].center);
            matrix[24, 25].obj = InitObj(Street.Project, matrix[24, 25].center);
            matrix[24, 26].obj = InitObj(Street.Project, matrix[24, 26].center);

            InitObj(Car.Models[0], matrix[24, 24].center);

            // matrix[49, 50].obj = InitObj(Street.Project, matrix[24, 25].center);
            // matrix[50, 50].obj = InitObj(Street.Project, matrix[25, 25].center);

            Common.Matrix = matrix;
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