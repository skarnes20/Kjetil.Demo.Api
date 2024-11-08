namespace Kjetil.Demo.Api.UnitTest.Controllers;

public class WeatherForecastControllerTest
{
    [Fact]
    public async Task Get_Five_FetchFiveForecastsFromService()
    {
        var serviceMock = new Mock<IWeatherService>();
        var controller = new WeatherForecastController(serviceMock.Object);

        await controller.Get(5);

        serviceMock.Verify(service => service.Get(5), Times.Once);
    }
}