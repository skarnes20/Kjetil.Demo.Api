namespace Kjetil.Demo.Service.Mappers;

public static class WeatherMapper
{
    public static IEnumerable<ForecastViewModel> ToViewModel(this IEnumerable<WeatherEntity> entities)
    {
        return entities.Select(entity => entity.ToViewModel()).ToList();
    }

    private static ForecastViewModel ToViewModel(this WeatherEntity entity)
    {
        return new()
        {
            Date = entity.Date,
            Temperature = new TemperatureViewModel
            {
                Celsius = entity.Temperature,
                Fahrenheit = entity.Temperature.ToFahrenheit()
            },
            Summary = entity.Summary
        };
    }
}