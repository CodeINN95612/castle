using Castle.Infrastructure.Data;

using Microsoft.AspNetCore.Mvc;

namespace Castle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly CastleDbContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, CastleDbContext context)
    {
        _logger = logger;
        _context = context;
    }
}
