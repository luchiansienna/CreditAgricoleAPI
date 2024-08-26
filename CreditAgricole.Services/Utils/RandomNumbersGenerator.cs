namespace CreditAgricole.Services.Utils
{
    public class RandomNumbersGenerator
    {
        private static readonly Random random = new Random();

        public static decimal RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return (decimal)(minValue + (next * (maxValue - minValue)));
        }
    }
}
