namespace Code4Fun.Demo.Api.UnitTest.Infrastructure;

public class OpenApiInstallerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public OpenApiInstallerTests(WebApplicationFactory<Program> factory) => _factory = factory;

    [Fact]
    public async Task AddOpenApi_ShouldRegisterSwaggerGen()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/docs/1.0/docs.json");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.NotNull(content);
    }
}