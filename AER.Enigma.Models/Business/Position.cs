namespace AER.Enigma.Models.Business
{
    using System;

    public class Position
    {
        public DateTimeOffset Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public double Accuracy { get; set; }
        public double AltitudeAccuracy { get; set; }
        public double Heading { get; set; }
        public double Speed { get; set; }

        public Position()
        {
        }

        public Position(double latitude, double longitude)
        {

            this.Timestamp = DateTimeOffset.UtcNow;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public Position(Position position)
        {
            if (position == null)
                throw new ArgumentNullException("position");

            this.Timestamp = position.Timestamp;
            this.Latitude = position.Latitude;
            this.Longitude = position.Longitude;
            this.Altitude = position.Altitude;
            this.AltitudeAccuracy = position.AltitudeAccuracy;
            this.Accuracy = position.Accuracy;
            this.Heading = position.Heading;
            this.Speed = position.Speed;
        }
    }
}
