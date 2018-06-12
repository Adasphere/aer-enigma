// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Represents a geographic location
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Business
{
    /// <summary>
    /// Represents a geographic location
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Gets or sets the latitude
        /// </summary>
        public double Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the longitude
        /// </summary>
        public double Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the zip code
        /// </summary>
        public int ZipCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the state
        /// </summary>
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        public string Country
        {
            get;
            set;
        }
    }
}
