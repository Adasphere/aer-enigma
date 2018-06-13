using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services.Database
{
    using System.Globalization;

    using AER.Enigma.Models.Business;

    using SQLite.Net;
    using SQLite.Net.Interop;

    public class DatabaseService : IDatabaseService
    {
        private SQLiteConnection connection;

        public string DbPath { get; set; }

        public ISQLitePlatform Platform { get; set; }

        private void CreateWeather()
        {
            this.connection.Execute(
                "CREATE TABLE WEATHER( " +
                "    ID STRING PRIMARY KEY NOT NULL, " +
                "    STARTDATETIME STRING NOT NULL, " +
                "    ENDDATETIME STRING NOT NULL, " +
                "    TEMPERATURE STRING NOT NULL " +
                ");");      
        }

        protected SQLiteConnection Connection => 
            this.connection ?? (this.connection = new SQLiteConnection(this.Platform, this.DbPath));

        public void UpdateWeather(List<Weather> list)
        {
            var weather = this.RetrieveWeather();

            if (weather == null)
            {
                this.CreateWeather();
            }

            this.Connection.BeginTransaction();

            foreach (Weather item in list)
            {
                string startDate = item.StartDateTime.ToString(_ISOStandardDate);
                string endDate = item.EndDateTime.ToString(_ISOStandardDate);

                this.connection.Execute(
                    "INSERT INTO WEATHER " 
                    + "(ID, "
                    + "STARTDATETIME, "
                    + "ENDDATETIME, "
                    + "TEMPERATURE) "
                    + "VALUES(@Param1, @Param2, @Param3, @Param4);",
                    Guid.NewGuid().ToString(),
                    startDate,
                    endDate,
                    item.Temperature.ToString());
            }

            this.connection.Commit();
        }

        private const string _ISOStandardDate = "yyyy-MM-dd HH:mm:ss.fff";

        public List<Weather> RetrieveWeather()
        {
            SQLiteCommand command = this.Connection.CreateCommand("SELECT * FROM 'WEATHER'");

            try
            {
                SQLiteCommandResult result = command.ExecuteDeferredQuery();

                SQLiteDataTable dataTable = result.Data;

                List<Weather> list = new List<Weather>();

                foreach (SQLiteDataTableRow row in dataTable)
                {
                    Weather item = 
                        new Weather
                            {
                                StartDateTime = (DateTime)SQLiteDataTypeConvert(row["STARTDATETIME"], typeof(DateTime)),
                                EndDateTime = (DateTime)SQLiteDataTypeConvert(row["ENDDATETIME"], typeof(DateTime)),
                                Temperature = (double?)SQLiteDataTypeConvert(row["TEMPERATURE"], typeof(double?))
                            };
                    list.Add(item);
                }

                return list;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private static object SQLiteDataTypeConvert(object value, Type propertyType)
        {
            if (value == null)
            {
                return null;
            }

            var valueAsString = value as string;

            if (propertyType == typeof(DateTime))
            {
                return DateTime.ParseExact(valueAsString, _ISOStandardDate, CultureInfo.InvariantCulture);
            }

            if (propertyType == typeof(Guid))
            {
                var guidAsString = valueAsString;
                var guid = Guid.Parse(guidAsString);
                return guid;
            }

            if (propertyType == typeof(double?))
            {
                return double.TryParse(valueAsString, out var result) ? (double?)result : (double?)null;
            }

            if (propertyType == typeof(bool))
            {
                var boolAsInteger = (int)value;
                var theBool = boolAsInteger == 1;
                return theBool;
            }

            if (propertyType != typeof(decimal))
            {
                return value;
            }

            var decimalAsString = valueAsString;
            var theDecimal = decimal.Parse(decimalAsString);
            return theDecimal;
        }
    }
}
