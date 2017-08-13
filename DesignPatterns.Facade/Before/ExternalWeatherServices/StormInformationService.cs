using System;

namespace DesignPatterns.Facade.Before.ExternalWeatherServices
{
    public class StormInformationService
    {
        public void SetLocation(Locations location)
        {
            throw new NotImplementedException();
        }

        public void SetForecastPeriod(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public string GetToken()
        {
            throw new NotImplementedException();
        }

        public StormInformation GetStormInformation(string token)
        {
            throw new NotImplementedException();
        }
    }
}
