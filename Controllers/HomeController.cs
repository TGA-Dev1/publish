using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Numerics;
using TestCore.Models;

namespace TestCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly WeatherService _weatherService;

        public HomeController(WeatherService weatherService, ILogger<HomeController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        [HttpGet("melbourne")]
        public async Task<ActionResult<WeatherResponse>> GetMelbourneWeather()
        {
            try
            {
                var weatherData = await _weatherService.GetWeatherAsync("Melbourne");
                return Ok(weatherData);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching weather data: {ex.Message}");
            }
        }

       

        [HttpGet]
        public IActionResult Index()
        {
            Fact f = new Fact();
            return View(f);
        }



        [HttpPost]
        public IActionResult Index(Fact n)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n.Number; i++)
                result *= i;

            n.result = result;
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
