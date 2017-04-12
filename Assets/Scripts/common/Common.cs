using UnityEngine;
using UnityEngine.UI;

namespace Cariacity.game
{
    public class Common
    {
        public static GridCell[,] Matrix;
        public static City CurrentCity = new City();

        public static Material RightProject;
        public static Material WrongProject;

        public static GameObject Info;
        public static GameObject Logger;
        public static GameObject Money;
        public static GameObject Happyness;

        public static GridCell GetNearbyCell(Vector3 center)
        {
            Vector3 tmp;

            for (int i = 0; i < Constants.GridSize; i++)
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    tmp = Matrix[i, j].center - center;

                    if (tmp.magnitude < Constants.HalfHypotenuse) // maybe check down line
                        return Matrix[i, j];
                }

            return null;
        }

        public static void Log(string text)
        {
            Logger.GetComponent<Text>().text = text;
        }

        public static void ShowInfo(string text)
        {
            Info.GetComponentInChildren<Text>().text = text;
            Info.SetActive(true);
        }

        public static void UpdateMoney()
        {
            Money.GetComponent<Text>().text = "$ " + CurrentCity.Money;
        }

        public static void UpdatePopulation()
        {
            Happyness.GetComponent<Text>().text = "pop: " + CurrentCity.Population;
        }
    }
}
