using System;
using System.Net;
using System.Threading;
using Kedust.Services;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;

namespace Kedust.UI.PrinterService
{
    public class OrderWatcher
    {
        private readonly Config _config;
        private readonly IOrderService _orderService;
        
        public OrderWatcher(Config config, IOrderService orderService)
        {
            _config = config;
            _orderService = orderService;
        }
        
        public async void Start(CancellationToken token)
        {
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
#endif
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(_config.SignalRHub)
                .Build();
            hubConnection.On("NotifyNewOrder", async () =>
            {
                var data = await _orderService.GetUnprintedOrders();
                Console.WriteLine($"New Order {DateTime.Now}");
            });
            await hubConnection.StartAsync(token).ContinueWith((task) =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("Connection failed");
                }
                
            }, token);
            
            await hubConnection.SendCoreAsync("JoinRoom", new object[]{"event"}, token);
            token.WaitHandle.WaitOne();
        }
    }
}