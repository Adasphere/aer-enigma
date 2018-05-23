using System;
using System.Collections.Generic;
using System.Text;
using AEREnigma.Models;

namespace AER.Enigma.Core.Services
{
    public class WeatherService : IWeatherService
    {
        public Weather GetWeather(int zipCode)
        {
            return new Weather()
            {
                Humidity = 50.5,
                Temperature = 70.8
            };
        }

        public Weather GetWeather(Location location)
        {
            return new Weather()
            {
                Humidity = 50.5,
                Temperature = 70.8
            };
        }
    }
}
