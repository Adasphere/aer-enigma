// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Alert.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents alert information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Business
{
    using System;

    /// <summary>
    /// Represents alert information.
    /// </summary>
    public class Alert
    {
        /// <summary>
        /// Gets or sets a title summarizing the alert.
        /// </summary>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the details of the message to be displayed.
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets how long a message should be displayed before it is automatically dismissed.
        /// </summary>
        public TimeSpan Length
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the category or severity of the alert.
        /// </summary>
        public AlertLevel Level
        {
            get;
            set;
        }
    }
}
