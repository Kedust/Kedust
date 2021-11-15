using Kedust.Data.Dal.EfImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.Data.Dal
{
    public static class Startup
    {
        public static void AddKedustDal(this IServiceCollection services, IConfiguration config)
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
            services.AddScoped<ISettingRepo, SettingRepo>();
        }
    }
}