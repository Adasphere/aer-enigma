using System;
using System.Collections.Generic;
using System.Text;
using AER.Enigma.Data;

namespace AER.Enigma.Services.Database
{
    using System.Globalization;
    using System.Threading.Tasks;
    using AER.Enigma.Models.Business;

    public class DatabaseService : IDatabaseService
    {
        protected string DbPath { get; private set; }

        protected Data.Database Database { get; private set; }

        public async Task InitializeAsync(string dbPath)
        {
            await Task.Factory.StartNew(() => this.Database = new Data.Database(dbPath));
        }

        public async Task UpdateWeatherAsync(List<Weather> list)
        {
            foreach (Weather item in list)
            {
                int i = await this.Database.SaveWeatherItemAsync(item);
            }
        }

        private const string _ISOStandardDate = "yyyy-MM-dd HH:mm:ss.fff";

        public async Task<List<Weather>> RetrieveWeatherAsync()
        {
            return await this.Database.GetWeatherItemsAsync();
        }
    }
}