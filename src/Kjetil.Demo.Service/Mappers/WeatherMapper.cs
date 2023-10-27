using System.Collections.Generic;
using System.Linq;
using Kjetil.Demo.DataAccess.Entities;
using Kjetil.Demo.Service.Extensions;
using Kjetil.Demo.Shared.ViewModels;

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
                Celcius = entity.Temperature,
                Farenheit = entity.Temperature.ToFarenheit()
            },
            Summary = entity.Summary
        };
    }
}