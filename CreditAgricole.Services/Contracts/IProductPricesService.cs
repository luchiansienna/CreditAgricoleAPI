using CreditAgricole.Domain;

namespace CreditAgricole.Services.Contracts
{
    public interface IProductPricesService
    {
        IEnumerable<ProductPrice> GetProducts();
    }
}
