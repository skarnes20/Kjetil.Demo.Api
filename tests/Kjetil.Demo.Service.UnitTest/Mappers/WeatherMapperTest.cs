using System.Linq;
using AutoFixture;
using Kjetil.Demo.DataAccess.Entities;
using Kjetil.Demo.Service.Mappers;
using Xunit;

namespace Kjetil.Demo.Service.UnitTest.Mappers
{
    public class WeatherMapperTest
    {
        private static readonly Fixture Fixture = new();

        [Fact(DisplayName = "WeatherMapper ToViewModel correct mapping")]
        public void ToViewModel_ListWithEntities_CorrectMapping()
        {
            var entities = Fixture.CreateMany<WeatherEntity>(1).ToList();

            var models = entities.ToViewModel().ToList();

            Assert.Equal(entities[0].Date, models[0].Date);
            Assert.Equal(entities[0].Summary, models[0].Summary);
            Assert.Equal(entities[0].Temperature, models[0].Temperature?.Celcius);
        }
    }
}