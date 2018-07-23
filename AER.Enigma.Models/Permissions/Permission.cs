// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Permission.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents different services that require permission
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Permissions
{
    /// <summary>
    /// Represents different services that require permission
    /// </summary>
    public enum Permission
    {
        /// <summary>
        /// A service that is not recognized
        /// </summary>
        Unknown,

        /// <summary>
        /// A service related to general location
        /// </summary>
        Location,

        /// <summary>
        /// A service related to uninterrupted access to location
        /// </summary>
        LocationAlways,

        /// <summary>
        /// A service related to location when the application is in the foreground.
        /// </summary>
        LocationWhenInUse
    }
}
