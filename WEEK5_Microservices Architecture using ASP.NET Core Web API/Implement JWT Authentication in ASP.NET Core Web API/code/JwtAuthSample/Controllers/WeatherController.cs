using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetWeather()
        {
            return Ok(new { Weather = "Sunny", Temperature = "32°C" });
        }
    }
}
