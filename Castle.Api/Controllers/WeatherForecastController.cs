using Castle.Domain.Entities.Parties;
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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = _context.Set<Party>().Count(),
            Summary = Summaries[0]
        })
        .ToArray();
    }

    [HttpPost("{name}")]
    public IActionResult InsertNew(string name)
    {
        _context.Parties.Add(Party.Create(new PartyId(Guid.NewGuid()), name));
        _context.SaveChanges();
        return Ok();
    }
}
