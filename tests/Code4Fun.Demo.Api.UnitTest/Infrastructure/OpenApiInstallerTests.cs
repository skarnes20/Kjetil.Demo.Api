namespace Code4Fun.Demo.Api.UnitTest.Infrastructure;

public class OpenApiInstallerTests(WebApplicationFactory<Startup> factory)
    : IClassFixture<WebApplicationFactory<Startup>>
{

    [Fact]
    public async Task AddOpenApi_ShouldRegisterSwaggerGen()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/docs/1.0/docs.json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.NotNull(content);
    }
}