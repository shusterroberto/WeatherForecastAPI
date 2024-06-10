namespace WeatherForecastAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<OpenWeatherMapSettings>(Configuration.GetSection("OpenWeatherMapSettings"));
            services.AddScoped<WeatherService>();
            services.AddControllers();
        }
    }
}
