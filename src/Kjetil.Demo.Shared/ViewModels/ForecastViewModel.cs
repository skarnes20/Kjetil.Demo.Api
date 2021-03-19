using System;

namespace Kjetil.Demo.Shared.ViewModels
{
    public class ForecastViewModel
    {
        public DateTime Date { get; set; }

        public TemperatureViewModel Temperature { get; set; }

        public string Summary { get; set; }
    }
}