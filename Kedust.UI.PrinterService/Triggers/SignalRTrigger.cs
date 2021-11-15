using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Kedust.Services.DTO;
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
            Console.WriteLine(_config.SignalRHub);
            
            var hubConnection = new HubConnectionBuilder()
                .WithUrl(_config.SignalRHub)
                .WithAutomaticReconnect(new RetryPolicy())
                .Build();

            hubConnection.On("NotifyNewOrder", async (int id) =>
            {
                OrderForPrinting order = await _orderServiceClient.GetOrder(id, token);
                await _printService.PrintOrderTicket(order, _config);
                await _orderServiceClient.SetPrinted(id, token);
            });
            await hubConnection.StartAsync(token).ContinueWith((task) =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("Connection failed");
                }
            }, token);

            token.WaitHandle.WaitOne();
        }
    }
}