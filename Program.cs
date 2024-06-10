using WeatherForecastAPI;

var builder = WebApplication.CreateBuilder(args);

// Configurar HttpClient e inje��o de depend�ncia
builder.Services.AddHttpClient();
builder.Services.Configure<WeatherApiSettings>(builder.Configuration.GetSection("WeatherApiSettings"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
