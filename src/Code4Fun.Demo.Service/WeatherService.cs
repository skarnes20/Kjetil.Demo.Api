namespace Code4Fun.Demo.Service;

public class WeatherService(IWeatherRepository repository) : IWeatherService
{
    public async Task<IEnumerable<ForecastViewModel>> Get(int days)
    {
        return (await repository.Get(days)).ToViewModel();
    }
}