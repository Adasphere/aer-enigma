namespace AER.Enigma.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using System.Xml;

    using AER.Enigma.Models;

    public class WeatherService : IWeatherService
    {
        public Weather GetWeather(Location location)
        {
            return new Weather()
            {
                Humidity = 50.5,
                Temperature = 70.8
            };
        }

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
                xmlStr = await wc.DownloadStringTaskAsync(path);
            }

            var doc = new XmlDocument();
            doc.LoadXml(xmlStr);

            List<Weather> list = doc.ToWeatherList();

            return list;
        }

    }
}
