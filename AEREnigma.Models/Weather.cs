namespace AEREnigma.Models
{
    using System;

    public class Weather
    {
        public Weather()
        {
        }

        public Weather(DateTime startDateTime, DateTime endDateTime, double? dewPoint, double? heatIndex, double? windSpeed, double? cloudAmount, double? probabilityPrecipitation, double? humidity, int? windDirection, double? temperature, double? windGust, double? precipitation, string weatherDescription)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            DewPoint = dewPoint;
            HeatIndex = heatIndex;
            WindSpeed = windSpeed;
            CloudAmount = cloudAmount;
            ProbabilityPrecipitation = probabilityPrecipitation;
            Humidity = humidity;
            WindDirection = windDirection;
            Temperature = temperature;
            WindGust = windGust;
            Precipitation = precipitation;
            WeatherDescription = weatherDescription;
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