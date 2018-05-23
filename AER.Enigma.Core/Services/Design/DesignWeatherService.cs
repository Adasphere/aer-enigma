using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Core.Services.Design
{
    using System.Threading.Tasks;

    using AEREnigma.Models;

    public class DesignWeatherService : IWeatherService
    {
        public async Task<Weather> GetWeatherAsync(int zipCode)
        {
            return await Task<Weather>.Factory.StartNew(() => new Weather { Humidity = 42, Temperature = 72 });
        }

        public async Task<Weather> GetWeatherAsync(string city)
        {
            return null;
        }
    }
}
