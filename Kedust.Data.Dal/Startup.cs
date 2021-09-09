using System.Data.Common;
using Kedust.Data.Dal.EfImplementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.Data.Dal
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(builder =>
            {
                builder.UseSqlite(@"Data Source=c:\Temp\kedust.db;");
            });


            services.AddScoped<IMenuRepo, MenuRepo>();
            services.AddScoped<IMenuItemRepo, MenuItemRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderItemRepo, OrderItemRepo>();
            services.AddScoped<ITableRepo, TableRepo>();
        }
    }
}