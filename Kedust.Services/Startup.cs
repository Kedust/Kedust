using Kedust.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.Services
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Data.Dal.Startup.ConfigureServices(services);
            // services.AddTransient<IPrintService, PrintService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<ITableService, TableService>();
            services.AddAutoMapper(typeof(Startup));
        }
    }
}