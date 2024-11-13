namespace Code4Fun.Demo.Api.Controllers;

/// <summary>
/// Defines the weather forecast controller
/// </summary>
/// <param name="service">Weather Service</param>
[ApiController]
[Route("api/forecast")]
public class WeatherForecastController(IWeatherService service) : ControllerBase
{
    /// <summary>
    /// Get weather forecast for the next 5 days
    /// </summary>
    /// <returns>weather forecast</returns>
    [HttpGet("{days}")]
    public async Task<IEnumerable<ForecastViewModel>> Get(int days)
    {
        return await service.Get(days);
    }
}