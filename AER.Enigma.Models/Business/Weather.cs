// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weather.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents weather information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Business
{
    using System;

    /// <summary>
    /// Represents weather information
    /// </summary>
    public class Weather
    {
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