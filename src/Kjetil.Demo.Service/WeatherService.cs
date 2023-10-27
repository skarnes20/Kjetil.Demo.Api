using System.Collections.Generic;
using System.Threading.Tasks;
using Kjetil.Demo.DataAccess.Repositories;
using Kjetil.Demo.Service.Mappers;
using Kjetil.Demo.Shared.ViewModels;

namespace Kjetil.Demo.Service
{
    public class WeatherService(IWeatherRepository repository) : IWeatherService
    {
        public async Task<IEnumerable<ForecastViewModel>> Get(int days)
        {
            return (await repository.Get(days)).ToViewModel();
        }
    }
}