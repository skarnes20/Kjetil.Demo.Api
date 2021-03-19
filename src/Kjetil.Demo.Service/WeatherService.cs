using System.Collections.Generic;
using System.Threading.Tasks;
using Kjetil.Demo.DataAccess.Repositories;
using Kjetil.Demo.Service.Mappers;
using Kjetil.Demo.Shared.ViewModels;

namespace Kjetil.Demo.Service
{
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
}