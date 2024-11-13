namespace Code4Fun.Demo.Service.UnitTest.Mappers;

public class WeatherMapperTest
{
    [Fact(DisplayName = "WeatherMapper ToViewModel correct mapping")]
    public void ToViewModel_ListWithEntities_CorrectMapping()
    {
        var bogusWeather = new Faker<WeatherEntity>()
            .RuleFor(we => we.Id, f => f.IndexFaker + 1)
            .RuleFor(we => we.Date, f => f.Date.Past())
            .RuleFor(we => we.Summary, f => f.Lorem.Sentence(5))
            .RuleFor(we => we.Temperature, f => f.Random.Int(-30, 50));

        var entities = bogusWeather.Generate(1).ToList();

        var models = entities.ToViewModel().ToList();

        Assert.Equal(entities[0].Date, models[0].Date);
        Assert.Equal(entities[0].Summary, models[0].Summary);
        Assert.Equal(entities[0].Temperature, models[0].Temperature?.Celsius);
    }
}