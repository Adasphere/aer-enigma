using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Design
{
    using System.Threading.Tasks;

    using AER.Enigma.Models;

    public class DesignWeatherService : IWeatherService
    {
        public Weather GetWeather(Location location)
        {
            return new Weather { Humidity = 42, Temperature = 72 };
        }

        public async Task<List<Weather>> GetWeatherAsync(Location location)
        {
            return await Task<List<Weather>>.Factory.StartNew(() => new List<Weather>(){ new Weather { Humidity = 42, Temperature = 72 }});
        }
    }
}
