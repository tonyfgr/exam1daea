using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add HttpClient and GifService
builder.Services.AddHttpClient<IRecomendacionService, RecomendacionService>();
builder.Services.AddTransient<IRecomendacionService, RecomendacionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.MapGet("/recomendaciones/{searchTerm}", async (string searchTerm, IRecomendacionService RecomendacionService) =>
{
    var recomendacions = await RecomendacionService.GetRecomendacionesAsync(searchTerm);
    return Results.Ok(recomendacions);
})
.WithName("GetRecomendacions")
.WithOpenApi();

app.Run();

// Define the service and controller logic here
public interface IRecomendacionService
{
    Task<IEnumerable<Recomendacion>> GetRecomendacionesAsync(string searchTerm);
}

public class RecomendacionService : IRecomendacionService
{
    private readonly HttpClient _httpClient;

    public RecomendacionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Recomendacion>> GetRecomendacionesAsync(string searchTerm)
    {
        var response = await _httpClient.GetStringAsync(
            $"http://ip172-18-0-90-cras92iim2rg00bmqong-5000.direct.labs.play-with-docker.com/recomendacion/{searchTerm}");
        var data = JArray.Parse(response);

        var recomendacions = new List<Recomendacion>();

        foreach (var result in data)
        {
            var recomendacion = new Recomendacion
            {
                Autor = result["Author"]?.ToString(),
                Nombre = result["Name"]?.ToString(),
                Sinopsis = result["Synopsis"]?.ToString(),
                Genero = result["Genre"]?.ToString(),
            };

            recomendacions.Add(recomendacion);
        }

        return recomendacions;
    }

}

// Define the Gif model
public class Recomendacion
{
    public string Autor { get; set; }
    public string Nombre { get; set; }
    public string Sinopsis { get; set; }
    public string Genero { get; set; }
}
