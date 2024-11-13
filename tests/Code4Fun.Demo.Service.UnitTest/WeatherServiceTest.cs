namespace Code4Fun.Demo.Service.UnitTest;

public class WeatherServiceTest
{
    private readonly IWeatherRepository _repositoryMock;
    private readonly WeatherService _service;

    public WeatherServiceTest()
    {
        _repositoryMock = Substitute.For<IWeatherRepository>();
        _service = new WeatherService(_repositoryMock);
    }

    [Fact(DisplayName = "WeatherService Get call repository with correct quantity")]
    public async Task Get_Five_CallRepositoryWithCorrectQuantity()
    {
        await _service.Get(5);

        await _repositoryMock.Received(1).Get(5);

    }

    [Fact(DisplayName = "WeatherService Get map to correct viewmodel")]
    public async Task Get_Five_MapToViewModel()
    {
        var forecasts = await _service.Get(5);

        Assert.IsType<List<ForecastViewModel>>(forecasts);
    }
}