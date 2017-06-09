using System.Collections;
using UnityEngine;

namespace Cariacity.game
{
    public class GameController : MonoBehaviour
    {
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
            SetCommonData();
            StartCoroutine(_mainService = _service(Constants.BackgroundTimer));

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
                }

                _0idxPos += new Vector2(-Constants.HalfHypotenuse, -Constants.HalfHypotenuse);
            }

            InitObj(Car.Models[0], matrix[24, 24].center);  // highway position

            Common.Matrix = matrix;
            Common.UpdateMoney();

            if (!JsonSerializer.HasSave())
                ConfigureNewGame();
            else
                SerializaCity.OpenSave((SerializableCity)JsonSerializer.Get<SerializableCity>());
        }

        private static void ConfigureNewGame()
        {
            var matrix = Common.Matrix;

            for (int i = 0; i < Constants.GridSize; i++)
                for (int j = 0; j < Constants.GridSize; j++)
                    if (Random.Range(0, 100) < Constants.TreeProbability)
                    {
                        matrix[i, j].obj = InitObj(Tree.Model, matrix[i, j].center, Quaternion.Euler(-90, Random.Range(0, 360), 0));
                        matrix[i, j].type = GameModel.Get(Tree.Model);
                    }

            Destroy(matrix[22, 20].obj);    matrix[22, 20].type = GameModel.Get(Street.EndModel);      matrix[22, 20].obj = InitObj(Street.EndModel, matrix[22, 20].center, Quaternion.Euler(0, 135, 0));
            Destroy(matrix[22, 21].obj);    matrix[22, 21].type = GameModel.Get(Street.LineModel);     matrix[22, 21].obj = InitObj(Street.LineModel, matrix[22, 21].center, Quaternion.Euler(0, 135, 0));
            Destroy(matrix[22, 22].obj);    matrix[22, 22].type = GameModel.Get(Street.LineModel);     matrix[22, 22].obj = InitObj(Street.LineModel, matrix[22, 22].center, Quaternion.Euler(0, 135, 0));
            Destroy(matrix[22, 23].obj);    matrix[22, 23].type = GameModel.Get(Street.LineModel);     matrix[22, 23].obj = InitObj(Street.LineModel, matrix[22, 23].center, Quaternion.Euler(0, 135, 0));
            Destroy(matrix[22, 24].obj);    matrix[22, 24].type = GameModel.Get(Street.CornerModel);   matrix[22, 24].obj = InitObj(Street.CornerModel, matrix[22, 24].center);
            Destroy(matrix[23, 24].obj);    matrix[23, 24].type = GameModel.Get(Street.LineModel);     matrix[23, 24].obj = InitObj(Street.LineModel, matrix[23, 24].center);
            Destroy(matrix[24, 24].obj);    matrix[24, 24].type = GameModel.Get(Street.TModel);        matrix[24, 24].obj = InitObj(Street.TModel, matrix[24, 24].center, Quaternion.Euler(0, -135, 0));
            Destroy(matrix[25, 24].obj);    matrix[25, 24].type = GameModel.Get(Street.LineModel);     matrix[25, 24].obj = InitObj(Street.LineModel, matrix[25, 24].center);
            Destroy(matrix[26, 24].obj);    matrix[26, 24].type = GameModel.Get(Street.LineModel);     matrix[26, 24].obj = InitObj(Street.LineModel, matrix[26, 24].center);
            Destroy(matrix[27, 24].obj);    matrix[27, 24].type = GameModel.Get(Street.LineModel);     matrix[27, 24].obj = InitObj(Street.LineModel, matrix[27, 24].center);
            Destroy(matrix[28, 24].obj);    matrix[28, 24].type = GameModel.Get(Street.LineModel);     matrix[28, 24].obj = InitObj(Street.LineModel, matrix[28, 24].center);
            Destroy(matrix[29, 24].obj);    matrix[29, 24].type = GameModel.Get(Street.EndModel);      matrix[29, 24].obj = InitObj(Street.EndModel, matrix[29, 24].center);
            Destroy(matrix[24, 25].obj);    matrix[24, 25].type = GameModel.Get(Street.LineModel);     matrix[24, 25].obj = InitObj(Street.LineModel, matrix[24, 25].center, Quaternion.Euler(0, 135, 0));
            Destroy(matrix[24, 26].obj);    matrix[24, 26].type = GameModel.Get(Street.EndModel);      matrix[24, 26].obj = InitObj(Street.EndModel, matrix[24, 26].center, Quaternion.Euler(0, -45, 0));
        }

        public static GameObject InitObj(GameObject model, Vector3 pos)
        {
            return Instantiate(model, pos, Quaternion.Euler(0, 45, 0));
        }

        public static GameObject InitObj(GameObject model, Vector3 pos, Quaternion rotation)
        {
            return Instantiate(model, pos, rotation);
        }

        private void SetCommonData()
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