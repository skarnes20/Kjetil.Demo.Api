using System;

namespace Kjetil.Demo.Shared.ViewModels;

public record ForecastViewModel(DateTime Date, TemperatureViewModel Temperature, string Summary);