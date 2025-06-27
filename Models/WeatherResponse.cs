namespace TestCore.Models
{
    public class WeatherResponse
    {
        public MainWeather main { get; set; }
        public List<Weather> weather { get; set; }
        public string name { get; set; }

        public class MainWeather
        {
            public float temp { get; set; }
            public float humidity { get; set; }
            public float pressure { get; set; }
        }

        public class Weather
        {
            public string description { get; set; }
        }
    }
}
