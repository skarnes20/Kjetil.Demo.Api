using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Kjetil.Demo.Api.IntegrationTest.Infrastructure
{
    public class TestServerBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public TestServerBase(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        public HttpClient HttpClient => _factory.CreateDefaultClient();

        public async Task<T> Get<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }
    }
}
