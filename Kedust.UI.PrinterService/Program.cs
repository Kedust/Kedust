using System;
using System.Threading;
using System.Threading.Tasks;
using Kedust.UI.PrinterService.Triggers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.UI.PrinterService
{
    
    class Program
    {
        public static async Task Main(string[] args)
        {
            //Fetch configuration
            Config config = new Config();
            var configurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json",optional:true)
                .AddUserSecrets<Program>()
                .Build();
            

            configurationRoot.Bind(config);
            
            //Setup services
            var services = new ServiceCollection();
            await services
                .AddTransient<Program>()
                .AddTransient<SignalRTrigger>()
                .AddTransient<PrintService>()
                .AddTransient<IOrderServiceClient, OrderServiceClient>()
                .AddTransient<QuartzTrigger>()
                .AddSingleton(config)
                .BuildServiceProvider()
            //Start program
                .GetRequiredService<Program>().Start();
        }


        
        
        private readonly SignalRTrigger _signalRTrigger;
        private readonly QuartzTrigger _quartzTrigger;
        public Program(SignalRTrigger signalRTrigger, QuartzTrigger quartzTrigger)
        {
            _signalRTrigger = signalRTrigger;
            _quartzTrigger = quartzTrigger;
        }

        private Task Start()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            _signalRTrigger.Start(cancellationTokenSource.Token);
            // _quartzTrigger.Start(cancellationTokenSource.Token);
            Console.ReadLine();
            cancellationTokenSource.Cancel();
            return Task.CompletedTask;
        }
    }
}