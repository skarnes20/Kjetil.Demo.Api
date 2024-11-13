namespace Code4Fun.Demo.Service.UnitTest.Infrastructure;

public class ServiceInstallerTests
{
    [Fact]
    public void AddServices_ShouldRegisterWeatherService()
    {
        var services = new ServiceCollection();

        services.AddServices();
        var serviceProvider = services.BuildServiceProvider();
        var weatherService = serviceProvider.GetService<IWeatherService>();

        Assert.NotNull(weatherService);
        Assert.IsType<WeatherService>(weatherService);
    }
}