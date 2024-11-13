using System;

namespace Code4Fun.Demo.Shared.ViewModels;

public record ForecastViewModel(DateTime Date, TemperatureViewModel Temperature, string Summary);