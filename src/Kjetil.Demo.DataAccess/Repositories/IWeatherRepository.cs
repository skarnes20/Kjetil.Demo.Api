using System.Threading.Tasks;

namespace Kjetil.Demo.DataAccess.Repositories;

public interface IWeatherRepository
{
    public Task<IEnumerable<WeatherEntity>> Get(int quantity);
}