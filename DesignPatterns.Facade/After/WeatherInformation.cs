using DesignPatterns.Facade.After.ExternalWeatherServices;

namespace DesignPatterns.Facade.After
{
    public class WeatherInformation
    {
        public int TemperatureCelsius { get; set; }

        public StormInformation StormInformation { get; set; }
    }
}
