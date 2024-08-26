using System.Net.WebSockets;
using System.Text;
using CreditAgricole.Services.Contracts;
using CreditAgricole.WebsocketWrapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CreditAgricole.WebSocketService
{
    public class WebSocketWrapper : IWebSocketWrapper
    {
        private WebSocket _socket;
        private readonly ILogger _logger;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly IProductPricesService _productService;

        public WebSocketWrapper(WebSocket socket, IProductPricesService productService,  ILogger logger = null)
        {
            _socket = socket;
            _productService = productService;
            _logger = logger;
            _cancellationToken = new CancellationTokenSource();
        }

        public async Task LaunchSecondTickerAsync()
        {
            PeriodicTimer secondTimer = new PeriodicTimer(new TimeSpan(0, 0, 1));
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new LongNameContractResolver();
            _logger?.LogInformation($"Launching ticker");
            while (await secondTimer.WaitForNextTickAsync(_cancellationToken.Token) && _socket.State == WebSocketState.Open)
            {
                _logger?.LogDebug($"Web socket tick");
                 await BroadcastAsync(JsonConvert.SerializeObject(_productService.GetProducts(), serializerSettings));
            }
        }

        async Task BroadcastAsync(string message)
        {
            try
            {
                var bytes = Encoding.UTF8.GetBytes(message);
                if (_socket.State == WebSocketState.Open)
                {
                    var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
                    await _socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, _cancellationToken.Token);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"Error trying to send message: {ex.Message}");
            }
        }

        public async Task StartReceivingMessagesAsync()
        {
            try
            {
                var buffer = new byte[1024 * 4];
                while (_socket.State == WebSocketState.Open)
                {
                    var result = await _socket.ReceiveAsync(new ArraySegment<byte>(buffer), _cancellationToken.Token);
                    HandleMessage(result, buffer);
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, $"Error when trying to close connection: {ex.Message}");
            }
        }

        async Task HandleMessage(WebSocketReceiveResult result, byte[] buffer)
        {
            if (result.MessageType == WebSocketMessageType.Close || _socket.State == WebSocketState.Aborted)
            {
                _logger?.LogDebug($"Closing connection");
                await _socket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, _cancellationToken.Token);
                _cancellationToken.Cancel();
            }
        }

        public void Dispose()
        {
            _cancellationToken.Cancel();
            _socket?.Dispose();
            _socket = null;
        }

        public ValueTask DisposeAsync()
        {
            Dispose();
            return new ValueTask(Task.CompletedTask);
        }
    }
}
