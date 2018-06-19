// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace AER.Enigma.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AER.Enigma.Models.Business;
    using SQLite;

    /// <summary>
    /// 
    /// </summary>
    public class Database
    {
        /// <summary>
        /// 
        /// </summary>
        readonly SQLiteAsyncConnection database;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbPath">
        /// 
        /// </param>
        public Database(string dbPath)
        {
            this.database = new SQLiteAsyncConnection(dbPath);
            this.database.CreateTableAsync<Weather>().Wait();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        public Task<List<Weather>> GetWeatherItemsAsync()
        {
            return this.database.Table<Weather>().ToListAsync();
        }

        // public Task<List<Weather>> GetItemsNotDoneAsync()
        // {
        //    return database.QueryAsync<Weather>("SELECT * FROM [Weather] WHERE [StartDateTime] > 0");
        // }

        // public Task<Weather> GetItemAsync(int id)
        // {
        //    return database.Table<Weather>().Where(i => i.ID == id).FirstOrDefaultAsync();
        // }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public Task<int> SaveWeatherItemAsync(Weather item)
        {
            return this.database.InsertAsync(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        public Task<int> DeleteItemAsync(Weather item)
        {
            return this.database.DeleteAsync(item);
        }
    }
}
