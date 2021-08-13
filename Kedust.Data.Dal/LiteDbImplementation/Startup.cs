using LiteDB;
using Microsoft.Extensions.DependencyInjection;

namespace Kedust.Data.Dal.LiteDbImplementation
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<LiteDbContext, LiteDbContext>();
            services.Configure<LiteDbConfig>(options => options.DatabasePath = @"C:\Kedust\db.db");
        }
    }
}