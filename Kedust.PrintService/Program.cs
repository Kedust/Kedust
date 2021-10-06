using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.PrintService
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services
                .AddSingleton<Program>()
                .AddSingleton<OrderWatcher>();
            var provider = services.BuildServiceProvider();
            await provider.GetRequiredService<Program>().Start();
        }


        private readonly OrderWatcher _orderWatcher;
        public Program(OrderWatcher orderWatcher) => _orderWatcher = orderWatcher;

        private Task Start()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task.Run(() => _orderWatcher.Start(cancellationTokenSource.Token), cancellationTokenSource.Token);
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }
    }
}