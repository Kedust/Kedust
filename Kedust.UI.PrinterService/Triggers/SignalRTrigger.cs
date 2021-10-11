using System;
using System.Net;
using System.Threading;
using Microsoft.AspNetCore.SignalR.Client;

namespace Kedust.UI.PrinterService.Triggers
{
    public class SignalRTrigger
    {
        private readonly Config _config;
        
        public SignalRTrigger(Config config)
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
            
            hubConnection.On("NotifyNewOrder", async () =>
            {
                Console.WriteLine(await RestClient.GetOrders());
            });
           
           
            await hubConnection.StartAsync(token).ContinueWith(async (task) =>
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine("Connection failed");
                }
                else
                {
                    await hubConnection.SendAsync("JoinRoom", _config.EventCode, token);
                }
                
            }, token);
            
            token.WaitHandle.WaitOne();
        }
    }
}