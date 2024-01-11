﻿namespace Kjetil.Demo.Api.Controllers;

[ApiController]
[Route("api/forecast")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _service;

    public WeatherForecastController(IWeatherService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get weather forecast for the next 5 days
    /// </summary>
    /// <returns>weather forecast</returns>
    [HttpGet("{days}")]
    public async Task<IEnumerable<ForecastViewModel>> Get(int days)
    {
        return await _service.Get(days);
    }
}