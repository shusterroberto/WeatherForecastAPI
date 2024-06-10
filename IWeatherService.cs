namespace WeatherForecastAPI
{
    public interface IWeatherService
    {
        Task<string> GetWeatherForecastAsync(string city);
    }
}
