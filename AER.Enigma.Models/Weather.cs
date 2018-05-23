// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weather.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Represents weather information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models
{
    using System;

    /// <summary>
    /// Represents weather information
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Weather"/> class.
        /// </summary>
        public Weather()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Weather"/> class.
        /// </summary>
        /// <param name="startDateTime">
        /// The start date time.
        /// </param>
        /// <param name="endDateTime">
        /// The end date time.
        /// </param>
        /// <param name="dewPoint">
        /// The dew point.
        /// </param>
        /// <param name="heatIndex">
        /// The heat index.
        /// </param>
        /// <param name="windSpeed">
        /// The wind speed.
        /// </param>
        /// <param name="cloudAmount">
        /// The cloud amount.
        /// </param>
        /// <param name="probabilityPrecipitation">
        /// The probability precipitation.
        /// </param>
        /// <param name="humidity">
        /// The humidity.
        /// </param>
        /// <param name="windDirection">
        /// The wind direction.
        /// </param>
        /// <param name="temperature">
        /// The temperature.
        /// </param>
        /// <param name="windGust">
        /// The wind gust.
        /// </param>
        /// <param name="precipitation">
        /// The precipitation.
        /// </param>
        /// <param name="weatherDescription">
        /// The weather description.
        /// </param>
        public Weather(DateTime startDateTime, DateTime endDateTime, double? dewPoint, double? heatIndex, double? windSpeed, double? cloudAmount, double? probabilityPrecipitation, double? humidity, int? windDirection, double? temperature, double? windGust, double? precipitation, string weatherDescription)
        {
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            this.DewPoint = dewPoint;
            this.HeatIndex = heatIndex;
            this.WindSpeed = windSpeed;
            this.CloudAmount = cloudAmount;
            this.ProbabilityPrecipitation = probabilityPrecipitation;
            this.Humidity = humidity;
            this.WindDirection = windDirection;
            this.Temperature = temperature;
            this.WindGust = windGust;
            this.Precipitation = precipitation;
            this.WeatherDescription = weatherDescription;
        }

        /// <summary>
        /// Gets or sets the start date time.
        /// </summary>
        public DateTime StartDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the end date time.
        /// </summary>
        public DateTime EndDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the dew point.
        /// </summary>
        public double? DewPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the heat index.
        /// </summary>
        public double? HeatIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wind speed.
        /// </summary>
        public double? WindSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cloud amount.
        /// </summary>
        public double? CloudAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the probability precipitation.
        /// </summary>
        public double? ProbabilityPrecipitation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the humidity.
        /// </summary>
        public double? Humidity
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wind direction.
        /// </summary>
        public int? WindDirection
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the temperature.
        /// </summary>
        public double? Temperature
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the wind gust.
        /// </summary>
        public double? WindGust
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the precipitation.
        /// </summary>
        public double? Precipitation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the weather description.
        /// </summary>
        public string WeatherDescription
        {
            get;
            set;
        }
    }
}