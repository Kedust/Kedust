using Kedust.Data.Dal.EfImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Kedust.Data.Dal
{
    public static class Startup
    {
        public static ILoggerFactory MyLoggerFactory { get; set; } = LoggerFactory.Create(builder =>
        {
            builder.AddConsole(configure: config => { builder.SetMinimumLevel(LogLevel.Information); });
        });
        
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<Context>(builder =>
            {
                builder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                builder.UseSqlite(config.GetConnectionString("Db"));
            });
            
            services.AddScoped<IMenuRepo, MenuRepo>();
            services.AddScoped<IChoiceRepo, ChoiceRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderItemRepo, OrderItemRepo>();
            services.AddScoped<ITableRepo, TableRepo>();
        }
    }
}