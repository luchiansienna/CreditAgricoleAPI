using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CreditAgricole.Domain;
public class Price
{
    public decimal Amount { get; }

    [JsonConverter(typeof(StringEnumConverter))]
    public Currency Currency { get; }

    public Price(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }
}

