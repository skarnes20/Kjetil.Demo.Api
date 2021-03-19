using System;
using System.Linq;
using System.Threading.Tasks;
using Kjetil.Demo.DataAccess.Repositories;
using Kjetil.Demo.DataAccess.UnitTest.Infrastructure;
using Xunit;

namespace Kjetil.Demo.DataAccess.UnitTest.Repositories
{
    public class WeatherRepositoryTest : TestBaseDb
    {
        private readonly Random _random = new();
        private readonly WeatherRepository _repository;

        public WeatherRepositoryTest()
        {
            _repository = new WeatherRepository(DbContext);
        }

        [Fact(DisplayName = "WeatherRepository Get returns correct number of forecasts")]
        public async Task Get_3_ReturnsCorrectNumberOfForecasts()
        {
            var number = _random.Next(1, 5);
            CreateForecasts(number);

            var forecasts = await _repository.Get(number);

            Assert.Equal(number, forecasts.Count());
        }
    }
}
