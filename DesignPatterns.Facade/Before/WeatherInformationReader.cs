using System;
using DesignPatterns.Facade.Before.ExternalWeatherServices;

namespace DesignPatterns.Facade.Before
{
    public class WeatherInformationReader
    {
        private const int ForecastPeriodDays = 5;

        public WeatherInformation Read()
        {
            var stormInformationService = new StormInformationService();
            stormInformationService.SetLocation(Locations.Brasilia);
            stormInformationService.SetForecastPeriod(
                DateTime.Today,
                DateTime.Today + TimeSpan.FromDays(ForecastPeriodDays));
            var token = stormInformationService.GetToken();

            var weatherInformation = new WeatherInformation
            {
                StormInformation = stormInformationService.GetStormInformation(token),

                TemperatureCelsius = AirTemperatureService.GetAirTemperaturCelsius(
                    Locations.Brasilia,
                    DateTime.Today)
            };

            return weatherInformation;
        }
    }
}
