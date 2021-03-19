using Kjetil.Demo.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kjetil.Demo.DataAccess.Infrastructure
{
    public static class DataAccessInstaller
    {
        public static void AddDb(this IServiceCollection services)
        {
            services.AddDbContext<WeatherDbContext>(options => options.UseSqlite("Data Source=weather.db"));

            services.AddTransient<IWeatherRepository, WeatherRepository>();
        }
    }
}