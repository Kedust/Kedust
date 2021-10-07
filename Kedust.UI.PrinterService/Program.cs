using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.UI.PrinterService
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",optional:false)
                .Build();
            Config config = new Config();
            configurationRoot.Bind(config);
            
            var services = new ServiceCollection();
            Kedust.Services.Startup.ConfigureServices(services);
            await services
                .AddSingleton<Program>()
                .AddSingleton<OrderWatcher>()
                .AddSingleton(config)
                .BuildServiceProvider()
                .GetRequiredService<Program>().Start();
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