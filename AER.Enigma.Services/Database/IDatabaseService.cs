using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Database
{
    using AER.Enigma.Models.Business;
    using System.Threading.Tasks;

    public interface IDatabaseService
    {
        Task InitializeAsync(string dbPath);

        Task<List<Weather>> RetrieveWeatherAsync();

        Task UpdateWeatherAsync(List<Weather> list);
    }
}