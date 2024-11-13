using System.Threading.Tasks;

namespace Code4Fun.Demo.DataAccess.Repositories;

public interface IWeatherRepository
{
    public Task<IEnumerable<WeatherEntity>> Get(int quantity);
}