using System.Text.Json;
using System.Text.Json.Serialization;
using AspNetCoreExamples.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCoreExamples.Pages.Home;

public class Index : PageModel
{
    private HttpClient? _httpClient;
    private const string ApiKey = "1dcbbabaaf365ab69e9274fdfc9d6ab7";
        
    public async Task<WeatherResult?> GetWeatherDataByCity(string city)
    {
        using (_httpClient)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.openweathermap.org/")
            };
            var result = await _httpClient.GetAsync($"data/2.5/weather?appid={ApiKey}&q={city}");
            if (result.IsSuccessStatusCode)
            {
                
                return JsonSerializer.Deserialize<WeatherResult>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                    PropertyNameCaseInsensitive = true
                });
            
            }
            return default;
        }
    }
    
    public void OnGet()
    {
        
    }
}