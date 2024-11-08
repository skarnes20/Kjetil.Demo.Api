namespace Kjetil.Demo.DataAccess.UnitTest.Infrastructure;

public class TestBaseDb
{
    private readonly DbContextOptions<WeatherDbContext> _options = new DbContextOptionsBuilder<WeatherDbContext>()
        .UseInMemoryDatabase($"Temp_{Guid.NewGuid()}")
        .Options;

    private readonly Fixture _fixture = new();
    private readonly Random _random = new();

    public TestBaseDb()
    {
        DbContext = new WeatherDbContext(_options);
    }

    protected WeatherDbContext DbContext { get; }

    protected void CreateForecasts(int quantity)
    {
        var forecasts = Enumerable.Range(1, quantity)
            .Select(index => new WeatherEntity
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                Temperature = _random.Next(-20, 55),
                Summary = _fixture.Create<string>()
            }).ToList();

        DbContext.Weather.AddRange(forecasts);
        DbContext.SaveChanges();
    }
}