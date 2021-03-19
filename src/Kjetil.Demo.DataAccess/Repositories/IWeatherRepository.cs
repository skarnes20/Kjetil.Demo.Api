using System.Collections.Generic;
using System.Threading.Tasks;
using Kjetil.Demo.DataAccess.Entities;

namespace Kjetil.Demo.DataAccess.Repositories
{
    public interface IWeatherRepository
    {
        public Task<IEnumerable<WeatherEntity>> Get(int quantity);
    }
}