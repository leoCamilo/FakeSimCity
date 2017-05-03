using System.Collections.Generic;

namespace Cariacity.game
{
    public class City
    {
        public int Population { get; set; }
        public float Money { get; set; }
        public float Happyness { get; set; }

        public IList<GridCell> HomeList { get; set; }
        public IList<GridCell> StreetList { get; set; }

        public City()
        {
            HomeList = new List<GridCell>();
            StreetList = new List<GridCell>();
            Population = 0;
            Money = 10000;
        }

        public static float CalculateCellProgress(GridCell cell)
        {
            return 1;
        }

        public void CalculateHappyness()
        {
            // do something
        }

        public float CalculateTaxes()
        {
            return Population * Happyness;
        }
    }
}
