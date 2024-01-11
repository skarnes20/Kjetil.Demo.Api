namespace Kjetil.Demo.Service.Infrastructure;

public static class ServiceInstaller
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IWeatherService, WeatherService>();

        services.AddDb();
    }
}