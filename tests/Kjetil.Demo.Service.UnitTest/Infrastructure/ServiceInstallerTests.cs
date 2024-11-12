namespace Kjetil.Demo.Service.UnitTest.Infrastructure;

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

    [Fact]
    public void AddServices_ShouldCallAddDb()
    {
        var services = Substitute.For<IServiceCollection>();
        var serviceInstaller = Substitute.ForPartsOf<IServiceCollection>();

        services.AddServices();

        serviceInstaller.Received(1).AddDb();
    }
}