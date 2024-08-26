using CreditAgricole.Domain;
using CreditAgricole.Services.Contracts;

namespace CreditAgricole.Services;
public class ProductListService : IProductListService
{
    public IEnumerable<Product> GetAllProducts()
    {
        var product1 = new Product(
            id: 1,
            name: "Gold"
        );

        var product2 = new Product(
            id: 2,
            name: "Silver"
        );

        var product3 = new Product(
            id: 3,
            name: "Oil"
        );

        var product4 = new Product(
            id: 4,
            name: "Wheat"
        );

        var product5 = new Product(
            id: 5,
            name: "Cotton"
        );

        var product6 = new Product(
            id: 6,
            name: "Coffee"
        );

        var product7 = new Product(
            id: 7,
            name: "Sugar"
        );

        var product8 = new Product(
            id: 8,
            name: "Petroleum"
        );

        var product9 = new Product(
             id: 9,
             name: "Copper"
        );

        var product10 = new Product(
            id: 10,
            name: "Iron"
        );

        return new List<Product> { product1, product2, product3, product4, product5, product6, product7, product8, product9, product10 };
    }
}
