using AEREnigma.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Core.Services
{
    public interface IWeatherService
    {
        Weather GetWeather(int zipCode);

        Weather GetWeather(Location location);
    }
}
