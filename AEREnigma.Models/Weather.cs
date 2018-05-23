// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Weather.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Represents weather information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AEREnigma.Models
{
    /// <summary>
    /// Represents weather information
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Gets or sets the temperature
        /// </summary>
        public double Temperature
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the humidity
        /// </summary>
        public double Humidity
        {
            get;
            set;
        }
    }
}
