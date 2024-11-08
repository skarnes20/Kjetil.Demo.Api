using System.Threading.Tasks;

namespace Kjetil.Demo.DataAccess.Repositories;

public class WeatherRepository(WeatherDbContext context) : IWeatherRepository
{
    public async Task<IEnumerable<WeatherEntity>> Get(int quantity)
    {
        return await context.Weather.OrderBy(x => x.Id).Take(quantity).ToListAsync();
    }
}