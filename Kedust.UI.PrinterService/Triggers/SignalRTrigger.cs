using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Kedust.UI.PrinterService.Triggers
{
    public class SignalRTrigger
    {
        private readonly Config _config;
        private readonly IOrderServiceClient _orderServiceClient;
        private readonly PrintService _printService;
        public SignalRTrigger(IOrderServiceClient orderServiceClient, PrintService printService, Config config)
        {
            _config = config;
            _printService = printService;
            _orderServiceClient = orderServiceClient;
        }
        
        public async Task Start(CancellationToken token)
        {
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
#endif
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(_config.SignalRHub)
                .Build();

            hubConnection.On("NotifyNewOrder", async (string eventCode, int id) =>
            {
                var order = await _orderServiceClient.GetOrder(id, token);
                await _printService.PrintOrderTicket(order);
            });

            hubConnection.Closed += exception =>
            {
                Console.WriteLine("Connection closed");
                return Task.CompletedTask;
            };

            hubConnection.Reconnected += exception =>
            {
                Console.WriteLine("Connection reconnected");
                return Task.CompletedTask;
            };

            hubConnection.Reconnecting += exception =>
            {
                Console.WriteLine("Connection reconnection");
                return Task.CompletedTask;
            };

            await hubConnection.StartAsync(token).ContinueWith(async (task) =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("Connection failed");
                }
                else
                {
                    await hubConnection.SendAsync("JoinRoom", _config.EventCode, token);
                    Console.WriteLine("Connection started");
                }
                
            }, token);
            
            token.WaitHandle.WaitOne();
        }
    }
}