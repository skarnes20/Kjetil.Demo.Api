namespace Code4Fun.Demo.DataAccess.Infrastructure;

public static class DataAccessInstaller
{
    public static void AddDb(this IServiceCollection services)
    {
        services.AddDbContext<WeatherDbContext>(options => options.UseSqlite("Data Source=weather.db"));

        services.AddTransient<IWeatherRepository, WeatherRepository>();
    }
}