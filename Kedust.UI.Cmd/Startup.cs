using System;
using System.Threading.Tasks;
using Kedust.UI.Cmd.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.UI.Cmd
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public static async Task RunAsync(string[] args)
        {
            var startup = new Startup(args);
            await startup.RunAsync();
        }

        public Startup(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true)
                .AddCommandLine(args);
            Configuration = builder.Build();
        }

        private Task RunAsync()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var provider = services.BuildServiceProvider();
            provider.GetRequiredService<CommandService>().Start();
            return Task.CompletedTask;
        }

        private void ConfigureServices(IServiceCollection services)
        {
            Kedust.Services.Startup.ConfigureServices(services);
            services.AddSingleton(Configuration)
                .AddSingleton<CommandService>();
        }
    }
}