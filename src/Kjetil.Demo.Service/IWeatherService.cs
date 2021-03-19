using System.Collections.Generic;
using System.Threading.Tasks;
using Kjetil.Demo.Shared.ViewModels;

namespace Kjetil.Demo.Service
{
    public interface IWeatherService
    {
        public Task<IEnumerable<ForecastViewModel>> Get(int days);
    }
}