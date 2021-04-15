using System.Net.Http;
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
    }
}
