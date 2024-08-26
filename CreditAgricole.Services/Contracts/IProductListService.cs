using CreditAgricole.Domain;

namespace CreditAgricole.Services.Contracts;

public interface IProductListService
{
    IEnumerable<Product> GetAllProducts();
}