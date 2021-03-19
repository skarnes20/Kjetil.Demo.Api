using Kjetil.Demo.Api.Infrastructure;
using Kjetil.Demo.Service.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Kjetil.Demo.Api
{
    public class Startup
    {
        private readonly OpenApiConfig _openApiConfig;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _openApiConfig = OpenApiInstaller.DefaultConfig();
            Configuration.Bind("OpenApi", _openApiConfig);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddOpenApi(_openApiConfig);
            services.AddServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi(_openApiConfig);
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
