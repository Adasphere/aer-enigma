// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AlertLevel.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents alert level information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Business
{
    /// <summary>
    /// Represents alert level information.
    /// </summary>
    public enum AlertLevel
    {
        /// <summary>
        /// An alert that represents no danger.
        /// </summary>
        Low,

        /// <summary>
        /// An alert that advises user to take caution.
        /// </summary>
        Warning,

        /// <summary>
        /// An alert for potential or pending dangers.
        /// </summary>
        Danger
    }
}
