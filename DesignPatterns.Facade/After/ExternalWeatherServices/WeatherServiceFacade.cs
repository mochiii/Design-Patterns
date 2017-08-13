using System;

namespace DesignPatterns.Facade.After.ExternalWeatherServices
{
    public class WeatherServiceFacade
    {
        public StormInformation GetStormInformation(Locations location, int forecastPeriodDays)
        {
            var stormInformationService = new StormInformationService();
            stormInformationService.SetLocation(location);
            stormInformationService.SetForecastPeriod(
                DateTime.Today,
                DateTime.Today + TimeSpan.FromDays(forecastPeriodDays));
            var token = stormInformationService.GetToken();
            var stormInformation = stormInformationService.GetStormInformation(token);

            return stormInformation;
        }

        public int GetAirTemperaturCelsius(Locations location)
        {
            var temperatureCelsius = AirTemperatureService.GetAirTemperaturCelsius(
                location,
                DateTime.Today);

            return temperatureCelsius;
        }
    }
}
