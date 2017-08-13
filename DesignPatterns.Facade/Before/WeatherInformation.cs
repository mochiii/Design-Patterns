using DesignPatterns.Facade.Before.ExternalWeatherServices;

namespace DesignPatterns.Facade.Before
{
    public class WeatherInformation
    {
        public int TemperatureCelsius { get; set; }

        public StormInformation StormInformation { get; set; }
    }
}
