using Microsoft.Extensions.DependencyInjection;

namespace Kedust.Data.Dal
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<SqLiteBaseRepository>();
        }
    }
}