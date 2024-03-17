using Castle.Data;

using Microsoft.AspNetCore.Mvc;

namespace Castle.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    public WeatherForecastController()
    {
    }
}
