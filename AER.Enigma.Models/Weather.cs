namespace AER.Enigma.Models
{
    using System;

    public class Weather
    {
        public Weather()
        {
        }

        public Weather(DateTime startDateTime, DateTime endDateTime, double? dewPoint, double? heatIndex, double? windSpeed, double? cloudAmount, double? probabilityPrecipitation, double? humidity, int? windDirection, double? temperature, double? windGust, double? precipitation, string weatherDescription)
        {
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            this.DewPoint = dewPoint;
            this.HeatIndex = heatIndex;
            this.WindSpeed = windSpeed;
            this.CloudAmount = cloudAmount;
            this.ProbabilityPrecipitation = probabilityPrecipitation;
            this.Humidity = humidity;
            this.WindDirection = windDirection;
            this.Temperature = temperature;
            this.WindGust = windGust;
            this.Precipitation = precipitation;
            this.WeatherDescription = weatherDescription;
        }
        public DateTime StartDateTime
        {
            get;
            set;
        }

        public DateTime EndDateTime
        {
            get;
            set;
        }


        public double? DewPoint
        {
            get;
            set;
        }

        public double? HeatIndex
        {
            get;
            set;
        }

        public double? WindSpeed
        {
            get;
            set;
        }

        public double? CloudAmount
        {
            get;
            set;
        }

        public double? ProbabilityPrecipitation
        {
            get;
            set;
        }

        public double? Humidity
        {
            get;
            set;
        }

        public int? WindDirection
        {
            get;
            set;
        }

        public double? Temperature
        {
            get;
            set;
        }

        public double? WindGust
        {
            get;
            set;
        }

        public double? Precipitation
        {
            get;
            set;
        }
        public string WeatherDescription
        {
            get;
            set;
        }
    }
}