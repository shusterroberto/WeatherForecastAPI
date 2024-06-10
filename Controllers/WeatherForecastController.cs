using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WeatherForecastAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly WeatherApiSettings _settings;

        public WeatherForecastController(IHttpClientFactory httpClientFactory, IOptions<WeatherApiSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _settings = settings.Value;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeatherForecast(string city)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_settings.BaseUrl}forecast?q={city}&appid={_settings.ApiKey}&units=metric");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest("Erro ao consultar a previsão do tempo.");
            }

            var data = await response.Content.ReadAsStringAsync();
            return Ok(data);
        }
    }
}