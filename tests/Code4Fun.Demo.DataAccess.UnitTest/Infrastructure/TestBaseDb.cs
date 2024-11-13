namespace Code4Fun.Demo.DataAccess.UnitTest.Infrastructure;

public class TestBaseDb
{
    private readonly DbContextOptions<WeatherDbContext> _options = new DbContextOptionsBuilder<WeatherDbContext>()
        .UseInMemoryDatabase($"Temp_{Guid.NewGuid()}")
        .Options;

    private readonly Random _random = new();
    private readonly Faker _faker = new();

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
                Summary = _faker.Lorem.Sentence()
            }).ToList();

        DbContext.Weather.AddRange(forecasts);
        DbContext.SaveChanges();
    }
}