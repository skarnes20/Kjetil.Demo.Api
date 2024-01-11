namespace Kjetil.Demo.Service;

public interface IWeatherService
{
    public Task<IEnumerable<ForecastViewModel>> Get(int days);
}