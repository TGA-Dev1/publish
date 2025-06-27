using System.Text.Json;

namespace TestCore.Models
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "b7561d6e558db3ed6c20401c95705382"; // Replace with your OpenWeatherMap API key
        private readonly string _baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherResponse> GetWeatherAsync(string city)
        {
            var url = $"{_baseUrl}?q={city}&appid={_apiKey}&units=metric"; // Metric for Celsius
            var response = await _httpClient.GetStringAsync(url);

            return JsonSerializer.Deserialize<WeatherResponse>(response);
        }
    }
}
