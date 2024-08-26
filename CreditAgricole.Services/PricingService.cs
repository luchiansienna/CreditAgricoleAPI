using CreditAgricole.Domain;
using CreditAgricole.Services.Contracts;
using CreditAgricole.Services.Utils;

namespace CreditAgricole.Services
{
    public class PricingService : IPricingService
    {
        public Price GetPrice() => new Price( Math.Round(RandomNumbersGenerator.RandomNumberBetween(1, 100), 2), Currency.GBP);
    }
}
