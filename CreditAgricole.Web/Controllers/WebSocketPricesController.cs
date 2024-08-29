using CreditAgricole.WebSocketService;
using CreditAgricole.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CreditAgricole.Controllers
{
    public class WebSocketPricesController : ControllerBase
    {
        private readonly IProductPricesService _productService;
        private readonly ILogger<WebSocketPricesController> _logger;
        public WebSocketPricesController(IProductPricesService productService, ILogger<WebSocketPricesController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/ws/productprices")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var wsWrapper = new WebSocketWrapper(await HttpContext.WebSockets.AcceptWebSocketAsync(), _productService, _logger);

                wsWrapper.LaunchSecondTickerAsync();
                await wsWrapper.StartReceivingMessagesAsync();
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
    }
}
