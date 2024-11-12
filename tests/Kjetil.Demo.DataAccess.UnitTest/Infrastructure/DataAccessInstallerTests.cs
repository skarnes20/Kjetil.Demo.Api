namespace Kjetil.Demo.DataAccess.UnitTest.Infrastructure;

public class DataAccessInstallerTests
{
    [Fact]
    public void AddDb_ShouldRegisterDbContext()
    {
        var services = new ServiceCollection();

        services.AddDb();
        var serviceProvider = services.BuildServiceProvider();
        var dbContext = serviceProvider.GetService<WeatherDbContext>();

        Assert.NotNull(dbContext);
        Assert.IsType<WeatherDbContext>(dbContext);
    }

    [Fact]
    public void AddDb_ShouldRegisterWeatherRepository()
    {
        var services = new ServiceCollection();

        services.AddDb();
        var serviceProvider = services.BuildServiceProvider();
        var weatherRepository = serviceProvider.GetService<IWeatherRepository>();

        Assert.NotNull(weatherRepository);
        Assert.IsType<WeatherRepository>(weatherRepository);
    }
}