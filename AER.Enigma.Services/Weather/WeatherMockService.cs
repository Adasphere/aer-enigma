using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Weather
{
    using System.Threading.Tasks;

    using AER.Enigma.Models;
    using AER.Enigma.Models.Business;

    public class WeatherMockService : IWeatherService
    {
        public Weather GetWeather(Location location)
        {
            throw new NotImplementedException();
        }

        public Task<List<Weather>> GetWeatherAsync(Location location)
        {
            throw new NotImplementedException();
        }
    }
}
