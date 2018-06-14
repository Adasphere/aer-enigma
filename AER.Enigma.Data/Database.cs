using AER.Enigma.Models.Business;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AER.Enigma.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Weather>().Wait();
        }

        public Task<List<Weather>> GetWeatherItemsAsync()
        {
            return database.Table<Weather>().ToListAsync();
        }

        //public Task<List<Weather>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<Weather>("SELECT * FROM [Weather] WHERE [StartDateTime] > 0");
        //}

        //public Task<Weather> GetItemAsync(int id)
        //{
        //    return database.Table<Weather>().Where(i => i.ID == id).FirstOrDefaultAsync();
        //}

        public Task<int> SaveWeatherItemAsync(Weather item)
        {
            return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Weather item)
        {
            return database.DeleteAsync(item);
        }
    }
}
