using System.Collections.Generic;
using System.Threading.Tasks;
using Kjetil.Demo.Api.IntegrationTest.Infrastructure;
using Kjetil.Demo.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Kjetil.Demo.Api.IntegrationTest
{
    public class AcceptanceTest : TestServerBase
    {
        public AcceptanceTest(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory(DisplayName = "Endpoint return success and correct content type")]
        [InlineData("api/forecast/5")]
        public async Task Forecast_Get_SuccessAndCorrectContentType(string url)
        {
            var response = await HttpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
        }

        [Theory(DisplayName = "Return correct forecast")]
        [InlineData("api/forecast/5")]
        public async Task Forecast_Get_CorrectForecast(string url)
        {
            var response = await HttpClient.GetAsync(url);

            var forecast = await Get<List<ForecastViewModel>>(response);

            Assert.True(forecast.Count == 5, "Wrong number of forecasts");
        }
    }
}
