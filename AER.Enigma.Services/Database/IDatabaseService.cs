using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;

namespace AER.Enigma.Services.Database
{
    using AER.Enigma.Models.Business;

    using SQLite.Net;

    public interface IDatabaseService
    {
        string DbPath { get; set; }

        ISQLitePlatform Platform { get; set; }

        List<Weather> RetrieveWeather();

        void UpdateWeather(List<Weather> list);
    }
}
