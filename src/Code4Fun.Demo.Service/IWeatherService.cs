namespace Code4Fun.Demo.Service;

public interface IWeatherService
{
    public Task<IEnumerable<ForecastViewModel>> Get(int days);
}