using System;
using System.Net;
using System.Threading;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace Kedust.UI.PrinterService
{
    public class OrderWatcher
    {
        private readonly Config _config;
        public OrderWatcher(Config config)
        {
            _config = config;
        }
        
        public async void Start(CancellationToken token)
        {
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
#endif
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(_config.SignalRHub)
                .Build();
            hubConnection.On("NewOrder", () => { Console.WriteLine($"New Order {DateTime.Now}"); });
            await hubConnection.StartAsync(token);
            token.WaitHandle.WaitOne();
        }
    }
}