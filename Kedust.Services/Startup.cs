using Kedust.Data.Dal;
using Kedust.Services.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.Services
{
    public static class Startup
    {
        public static void AddKedustServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddKedustDal(config);
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<ITableService, TableService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddAutoMapper(typeof(Startup));
        }
    }
}