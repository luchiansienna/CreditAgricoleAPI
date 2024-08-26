using CreditAgricole.Domain;
using CreditAgricole.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CreditAgricole.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductListController : ControllerBase
{
    private readonly ILogger<ProductListController> _logger;
    private readonly IProductListService _service;
    public ProductListController(ILogger<ProductListController> logger, IProductListService service)
    {
        _logger = logger;
        _service = service;
    }

    /// <summary>
    /// List all products
    /// </summary>
    [HttpGet("/api/ProductList/")]
    [ProducesResponseType(typeof(IEnumerable<Product>), StatusCodes.Status200OK)]
    public IActionResult GetAllProducts()
    {
        var products = _service.GetAllProducts();
        return Ok(products);
    }
}

        
    
