using DesignPatterns.Facade.After.ExternalWeatherServices;

namespace DesignPatterns.Facade.After
{
    public class WeatherInformationReader
    {
        private const int ForecastPeriodDays = 5;

        public WeatherInformation Read()
        {
            var weatherServiceFacade = new WeatherServiceFacade();

            var weatherInformation = new WeatherInformation
            {
                StormInformation = weatherServiceFacade.GetStormInformation(
                    Locations.Brasilia,
                    ForecastPeriodDays),

                TemperatureCelsius = weatherServiceFacade.GetAirTemperaturCelsius(
                    Locations.Brasilia)
            };

            return weatherInformation;
        }
    }
}
