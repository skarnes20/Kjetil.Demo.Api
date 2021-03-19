using System.Collections.Generic;
using System.Threading.Tasks;
using Kjetil.Demo.DataAccess.Repositories;
using Kjetil.Demo.Shared.ViewModels;
using Moq;
using Xunit;

namespace Kjetil.Demo.Service.UnitTest
{
    public class WeatherServiceTest
    {
        private readonly Mock<IWeatherRepository> _repositoryMock;
        private readonly WeatherService _service;

        public WeatherServiceTest()
        {
            _repositoryMock = new Mock<IWeatherRepository>();
            _service = new WeatherService(_repositoryMock.Object);
        }

        [Fact(DisplayName = "WeatherService Get call repository with correct quantity")]
        public async Task Get_Five_CallRepositoryWithCorrectQuantity()
        {
            await _service.Get(5);

            _repositoryMock.Verify(x => x.Get(5), Times.Once);

        }

        [Fact(DisplayName = "WeatherService Get map to correct viewmodel")]
        public async Task Get_Five_MapToViewModel()
        {
            var forecasts = await _service.Get(5);

            Assert.IsType<List<ForecastViewModel>>(forecasts);
        }
    }
}
