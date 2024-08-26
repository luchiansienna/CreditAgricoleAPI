namespace CreditAgricole.WebSocketService
{
    public interface IWebSocketWrapper : IDisposable, IAsyncDisposable
    {
        Task LaunchSecondTickerAsync();
        Task StartReceivingMessagesAsync();
    }
}
