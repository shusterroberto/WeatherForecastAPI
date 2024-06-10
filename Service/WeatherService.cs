using Microsoft.Extensions.Options;

namespace WeatherForecastAPI
{
    public class WeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly WeatherApiSettings _settings;

        public WeatherService(IHttpClientFactory httpClientFactory, IOptions<WeatherApiSettings> settings)
        {
            _httpClientFactory = httpClientFactory;
            _settings = settings.Value;
        }

        public async Task<string> GetWeatherForecastAsync(string city)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_settings.BaseUrl}forecast?q={city}&appid={_settings.ApiKey}&units=metric");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao consultar a previsão do tempo.");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}