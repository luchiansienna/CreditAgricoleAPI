using CreditAgricole.Domain;
using CreditAgricole.Services.Contracts;

namespace CreditAgricole.Services
{
    public class ProductPricesService : IProductPricesService
    {
        private readonly IProductListService _data;
        private readonly IPricingService _pricingService;

        public ProductPricesService(IProductListService data, IPricingService pricingService)
        {
            _data = data;
            _pricingService = pricingService;
        }
        public IEnumerable<ProductPrice> GetProducts()
        {
            return _data.GetAllProducts().Select(p => new ProductPrice(p.Id, _pricingService.GetPrice()));
        }
    }
}
