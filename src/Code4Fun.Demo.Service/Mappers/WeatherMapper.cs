namespace Code4Fun.Demo.Service.Mappers;

public static class WeatherMapper
{
    public static IEnumerable<ForecastViewModel> ToViewModel(this IEnumerable<WeatherEntity> entities)
    {
        return entities.Select(entity => entity.ToViewModel()).ToList();
    }

    private static ForecastViewModel ToViewModel(this WeatherEntity entity)
    {
        var temperature = new TemperatureViewModel(entity.Temperature, entity.Temperature.ToFahrenheit());

        return new ForecastViewModel(entity.Date, temperature, entity.Summary);
    }
}