// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Position.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents position information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Business
{
    using System;

    /// <summary>
    /// Represents position information
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        public Position()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class based on latitude and longitude.
        /// </summary>
        /// <param name="latitude">
        /// The latitude
        /// </param>
        /// <param name="longitude">
        /// The longitude
        /// </param>
        public Position(double latitude, double longitude)
        {
            this.Timestamp = DateTimeOffset.UtcNow;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class from an existing <see cref="Position"/> object.
        /// </summary>
        /// <param name="position">
        /// An existing position to be copied.
        /// </param>
        public Position(Position position)
        {
            if (position == null)
            {
                throw new ArgumentNullException($"{nameof(position)}");
            }

            this.Timestamp = position.Timestamp;
            this.Latitude = position.Latitude;
            this.Longitude = position.Longitude;
            this.Altitude = position.Altitude;
            this.AltitudeAccuracy = position.AltitudeAccuracy;
            this.Accuracy = position.Accuracy;
            this.Heading = position.Heading;
            this.Speed = position.Speed;
        }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        public DateTimeOffset Timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        public double Latitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the longitude.
        /// </summary>
        public double Longitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the altitude.
        /// </summary>
        public double Altitude
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the accuracy.
        /// </summary>
        public double Accuracy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the altitude accuracy.
        /// </summary>
        public double AltitudeAccuracy
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the heading.
        /// </summary>
        public double Heading
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the speed.
        /// </summary>
        public double Speed
        {
            get;
            set;
        }
    }
}
