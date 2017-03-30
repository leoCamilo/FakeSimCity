namespace Cariacity.game
{
    public class City
    {
        public int Population { get; set; }
        public float Money { get; set; }
        public float Happyness { get; set; }

        public City()
        {
            Population = 0;
            Money = 10000;
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
