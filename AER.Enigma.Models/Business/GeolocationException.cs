// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeolocationException.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents a GeolocationException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Business
{
    using System;

    /// <summary>
    /// Represents a GeolocationException.
    /// </summary>
    public class GeolocationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeolocationException" /> class. 
        /// </summary>
        /// <param name="error">
        /// The type of geolocation error that occurred.
        /// </param>
        /// <param name="innerException">
        /// Optional parameter to associate another <see cref="T:System.Exception" /> with the current <see cref="T:AER.Enigma.Models.Business.GeolocationException" />
        /// </param>
        public GeolocationException(GeolocationError error, Exception innerException = null)
            : base("A geolocation error occured: " + error, innerException)
        {
            if (!Enum.IsDefined(typeof(GeolocationError), error))
            {
                throw new ArgumentException("error is not a valid GelocationError member", $"{nameof(error)}");
            }

            this.Error = error;
        }

        /// <summary>
        /// Gets the type of geolocation error that occurred.
        /// </summary>
        public GeolocationError Error { get; }
    }
}
