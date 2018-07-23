// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeolocationError.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents geolocation error information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Business
{
    /// <summary>
    /// Represents geolocation error information.
    /// </summary>
    public enum GeolocationError
    {
        /// <summary>
        /// An error that occurs when the user is authorized to use geolocation data, but the data is not available.
        /// </summary>
        PositionUnavailable,

        /// <summary>
        /// An error that occurs when the user is not authorized to use geolocation data.
        /// </summary>
        Unauthorized
    }
}
