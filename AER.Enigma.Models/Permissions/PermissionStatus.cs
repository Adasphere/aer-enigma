// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissionStatus.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents the status of different service permissions
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Permissions
{
    /// <summary>
    /// Represents the status of different service permissions
    /// </summary>
    public enum PermissionStatus
    {
        /// <summary>
        /// Access to this service is not granted
        /// </summary>
        Denied,

        /// <summary>
        /// The service is not available
        /// </summary>
        Disabled,

        /// <summary>
        /// The service is available to use
        /// </summary>
        Granted,

        /// <summary>
        /// The service is available in a limited capacity
        /// </summary>
        Restricted,

        /// <summary>
        /// The status of the permission service is not known
        /// </summary>
        Unknown
    }
}
