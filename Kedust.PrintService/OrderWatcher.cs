using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Kedust.PrintService
{
    public class OrderWatcher
    {
        public async void Start(CancellationToken token)
        {
#if DEBUG
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;
#endif
            var hubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/PrintHub")
                .Build();
            hubConnection.On("NewOrder", () => { Console.WriteLine($"New Order {DateTime.Now}"); });
            await hubConnection.StartAsync(token);
            token.WaitHandle.WaitOne();
        }
    }
}