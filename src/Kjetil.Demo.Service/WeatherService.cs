namespace Kjetil.Demo.Service;

public class WeatherService : IWeatherService
{
    private readonly IWeatherRepository _repository;

    public WeatherService(IWeatherRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ForecastViewModel>> Get(int days)
    {
        return (await _repository.Get(days)).ToViewModel();
    }
}