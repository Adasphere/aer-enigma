// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherService.cs" company="Adasphere">
//   2018
// </copyright>
// <summary>
//   Service for getting weather information
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Core.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Xml;

    using AEREnigma.Models;

    /// <summary>
    /// Service for getting weather information
    /// </summary>
    public class WeatherService : IWeatherService
    {
        /// <summary>
        /// Asynchronously gets the weather for a given zip code.
        /// </summary>
        /// <param name="zipCode">
        /// The zip code with weather.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> of <see cref="Weather"/>.
        /// </returns>
        public async Task<Weather> GetWeatherAsync(int zipCode)
        {
            // Replace with an asynchronous call to a web service
            Task<Weather> task = Task<Weather>.Factory.StartNew(
                z =>
                {
                    Weather weather = new Weather()
                    {
                        Humidity = 50.5,
                        Temperature = 70.8
                    };

                    return weather;
                },
                zipCode);

            return await task;
        }

        /// <summary>
        /// Asynchronously gets the weather for a given zip code.
        /// </summary>
        /// <param name="city">
        /// The city with weather.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> of <see cref="Weather"/>.
        /// </returns>
        public async Task<Weather> GetWeatherAsync(string city)
        {
            // Replace with an asynchronous call to a web service
            Task<Weather> task = Task<Weather>.Factory.StartNew(
                c =>
                {
                    Weather weather = new Weather()
                    {
                        Humidity = 50.5,
                        Temperature = 70.8
                    };

                    return weather;
                },
                city);

            return await task;
        }

        /// <summary>
        /// Asynchronously gets the weather for a given location.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<List<Weather>> GetWeatherAsync(Location location)
        {
            string path = $"https://forecast.weather.gov/MapClick.php?lat={location.Latitude}&lon={location.Longitude}&FcstType=digitalDWML";

            // Tried to generate classes from xml and deserialize, but that failed due to bugs:
            // PlatformNotSupportedException: Compiling JScript/CSharp scripts is not supported.
            // So tried this instead:
            string xmlStr;
            using (var wc = new WebClient())
            {
                // returns 403 if you do not include user agent!!
                wc.Headers.Add(HttpRequestHeader.UserAgent, "weather app prototype");
                try
                {
                    // todo: review error handling guidelines
                    // Basic error handling. If the XML download fails there won't be any data to create the weather list.
                    xmlStr = await wc.DownloadStringTaskAsync(path);
                }
                catch (ArgumentNullException ae)
                {
                    Console.Write(ae);
                    return new List<Weather>();
                }
                catch (NotSupportedException ne)
                {
                    Console.Write(ne);
                    return new List<Weather>();
                }
                catch (WebException we)
                {
                    Console.Write(we);
                    return new List<Weather>();
                }
            }

            var doc = new XmlDocument();
            doc.LoadXml(xmlStr);

            XmlNodeList startTimeNodeList = doc.SelectNodes("/dwml/data/time-layout/start-valid-time");
            XmlNodeList endTimeNodeList = doc.SelectNodes("/dwml/data/time-layout/end-valid-time");

            XmlNodeList dewPointList = doc.SelectNodes("/dwml/data/parameters/temperature[@type='dew point']/value");
            XmlNodeList heatIndexList = doc.SelectNodes("/dwml/data/parameters/temperature[@type='heat index']/value");
            XmlNodeList windSpeedList = doc.SelectNodes("/dwml/data/parameters/wind-speed[@type='sustained']/value");
            XmlNodeList cloudAmountList = doc.SelectNodes("/dwml/data/parameters/cloud-amount/value");
            XmlNodeList probabilityPrecipitationList = doc.SelectNodes("/dwml/data/parameters/probability-of-precipitation/value");
            XmlNodeList humidityList = doc.SelectNodes("/dwml/data/parameters/humidity/value");
            XmlNodeList windDirectionList = doc.SelectNodes("/dwml/data/parameters/direction/value");
            XmlNodeList hourlyTempList = doc.SelectNodes("/dwml/data/parameters/temperature[@type='hourly']/value");
            XmlNodeList windGustList = doc.SelectNodes("/dwml/data/parameters/wind-speed[@type='gust']/value");
            XmlNodeList precipitationList = doc.SelectNodes("/dwml/data/parameters/hourly-qpf/value");
            XmlNodeList weatherDescriptionList = doc.SelectNodes("/dwml/data/parameters/weather/weather-conditions/value");

            List<Weather> weather = new List<Weather>();

            for (int i = 0; i < startTimeNodeList.Count; i++)
            {
                try
                {
                    DateTime startDateTime = DateTime.Parse(startTimeNodeList[i].InnerText);
                    DateTime endDateTime = DateTime.Parse(endTimeNodeList[i].InnerText);
                    double? dewPoint = ToNullableDouble(dewPointList[i].InnerText);
                    double? heatIndex = heatIndexList[i].HasChildNodes ? ToNullableDouble(heatIndexList[i].InnerText) : null;
                    double? windSpeed = windSpeedList[i].HasChildNodes ? ToNullableDouble(windSpeedList[i].InnerText) : null;
                    double? cloudAmount = cloudAmountList[i].HasChildNodes ? ToNullableDouble(cloudAmountList[i].InnerText) : null;
                    double? probabilityPrecipitation = probabilityPrecipitationList[i].HasChildNodes ? ToNullableDouble(probabilityPrecipitationList[i].InnerText) : null;
                    double? humidity = humidityList[i].HasChildNodes ? ToNullableDouble(humidityList[i].InnerText) : null;
                    int? windDirection = windDirectionList[i].HasChildNodes ? ToNullableint(windDirectionList[i].InnerText) : null;
                    double? temperature = hourlyTempList[i].HasChildNodes ? ToNullableDouble(hourlyTempList[i].InnerText) : null;
                    double? windGust = windGustList[i].HasChildNodes ? ToNullableDouble(windGustList[i].InnerText) : null;
                    double? precipitation = precipitationList[i].HasChildNodes ? ToNullableDouble(precipitationList[i].InnerText) : null;
                    string weatherDescription = weatherDescriptionList[i].OuterXml;

                    Weather weatherItem = new Weather(
                        startDateTime,
                        endDateTime,
                        dewPoint,
                        heatIndex,
                        windSpeed,
                        cloudAmount,
                        probabilityPrecipitation,
                        humidity,
                        windDirection,
                        temperature,
                        windGust,
                        precipitation,
                        weatherDescription);
                    weather.Add(weatherItem);
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }

            return weather;
        }
        
        // todo: make these extensions methods and move out of here
        public static double? ToNullableDouble(string value)
        {
            try
            {
                return value == null ? (double?)null : Convert.ToDouble(value);
            }
            catch (FormatException fe)
            {
                Console.Write(fe);
                return null;
            }
        }

        public static int? ToNullableint(string value)
        {
            try
            {
                return value == null ? (int?)null : Convert.ToInt32(value);
            }
            catch (FormatException fe)
            {
                Console.Write(fe);
                return null;
            }
        }
    }
}