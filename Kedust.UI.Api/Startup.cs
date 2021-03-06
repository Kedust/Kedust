using Kedust.Services;
using Kedust.UI.Api.Config;
using Kedust.UI.Api.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Kedust.UI.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddTransient<IPrintSignal, PrintSignal>();
            
            var seqConfig = new SeqConfig();
            Configuration.Bind("Seq", seqConfig);
            
            services.AddKedustServices(Configuration);
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder
                    .AddSeq(seqConfig.Url, seqConfig.Key);
            });

            services.AddCors();
            services.AddControllers();
            services.AddSignalR();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Kedust.UI.Api", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kedust.UI.Api v1"));
            // app.UseCors("CorsPolicy");
            app.UseCors(
                options => options
                    .WithOrigins("http://localhost:8080", "https://localhost:8081", "http://192.168.0.222:8080", "http://192.168.0.222:8081", "https://kedust.be", "https://admin.kedust.be", "http://kedust.be", "http://admin.kedust.be")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<PrintHub>("/PrintHub");
            });
        }
    }
}