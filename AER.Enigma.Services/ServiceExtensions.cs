using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services
{
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Xml;
    using AER.Enigma.Core;
    using AER.Enigma.Models;
    using AER.Enigma.Services.Weather;

    internal static class ServiceExtensions
    {
        internal static List<Models.Business.Weather> ToWeatherList(this XmlDocument xmlDocument)
        {
            WeatherXmlNodes nodes = new WeatherXmlNodes()
                .Load(xmlDocument, n => n.Starts, "/dwml/data/time-layout/start-valid-time")
                .Load(xmlDocument, n => n.Ends, "/dwml/data/time-layout/end-valid-time")
                .Load(xmlDocument, n => n.DewPoints, "/dwml/data/parameters/temperature[@type='dew point']/value")
                .Load(xmlDocument, n => n.HeatIndexes, "/dwml/data/parameters/temperature[@type='heat index']/value")
                .Load(xmlDocument, n => n.WindSpeeds, "/dwml/data/parameters/wind-speed[@type='sustained']/value")
                .Load(xmlDocument, n => n.CloudAmounts, "/dwml/data/parameters/cloud-amount/value")
                .Load(xmlDocument, n => n.ProbabilityPrecipitations, "/dwml/data/parameters/probability-of-precipitation/value")
                .Load(xmlDocument, n => n.Humidities, "/dwml/data/parameters/humidity/value")
                .Load(xmlDocument, n => n.WindDirections, "/dwml/data/parameters/direction/value")
                .Load(xmlDocument, n => n.Temperatures, "/dwml/data/parameters/temperature[@type='hourly']/value")
                .Load(xmlDocument, n => n.WindGusts, "/dwml/data/parameters/wind-speed[@type='gust']/value")
                .Load(xmlDocument, n => n.Precipitations, "/dwml/data/parameters/hourly-qpf/value")
                .Load(xmlDocument, n => n.WeatherDescriptions, "/dwml/data/parameters/weather/weather-conditions/value");

            return nodes.ToWeatherList();
        }

        internal static WeatherXmlNodes Load(
            this WeatherXmlNodes target,
            XmlDocument xmlDocument,
            Expression<Func<WeatherXmlNodes, XmlNodeList>> memberLamda,
            string xpath)
        {
            XmlNodeList list = xmlDocument.SelectNodes(xpath);

            if (memberLamda.Body is MemberExpression memberSelectorExpression)
            {
                var property = memberSelectorExpression.Member as PropertyInfo;
                if (property != null)
                {
                    property.SetValue(target, list, null);
                }
            }

            return target;
        }

        private static List<Models.Business.Weather> ToWeatherList(this WeatherXmlNodes nodes)
        {
            List<Models.Business.Weather> list = new List<Models.Business.Weather>();

            for (int i = 0; i < nodes.Starts.Count; i++)
            {
                try
                {
                    Models.Business.Weather item = 
                        new Models.Business.Weather
                        {
                            StartDateTime = DateTime.Parse(nodes.Starts[i].InnerText),
                            EndDateTime = DateTime.Parse(nodes.Ends[i].InnerText),
                            DewPoint = nodes.DewPoints[i].InnerText.ToNullableDouble(),
                            HeatIndex =
                                nodes.HeatIndexes[i].HasChildNodes
                                    ? nodes.HeatIndexes[i].InnerText.ToNullableDouble()
                                    : null,
                            WindSpeed =
                                nodes.WindSpeeds[i].HasChildNodes
                                    ? nodes.WindSpeeds[i].InnerText.ToNullableDouble()
                                    : null,
                            CloudAmount =
                                nodes.CloudAmounts[i].HasChildNodes
                                    ? nodes.CloudAmounts[i].InnerText.ToNullableDouble()
                                    : null,
                            ProbabilityPrecipitation =
                                nodes.ProbabilityPrecipitations[i].HasChildNodes
                                    ? nodes.ProbabilityPrecipitations[i].InnerText
                                        .ToNullableDouble()
                                    : null,
                            Humidity =
                                nodes.Humidities[i].HasChildNodes
                                    ? nodes.Humidities[i].InnerText.ToNullableDouble()
                                    : null,
                            WindDirection =
                                nodes.WindDirections[i].HasChildNodes
                                    ? nodes.WindDirections[i].InnerText.ToNullableint()
                                    : null,
                            Temperature =
                                nodes.Temperatures[i].HasChildNodes
                                    ? nodes.Temperatures[i].InnerText.ToNullableDouble()
                                    : null,
                            WindGust =
                                nodes.WindGusts[i].HasChildNodes
                                    ? nodes.WindGusts[i].InnerText.ToNullableDouble()
                                    : null,
                            Precipitation =
                                nodes.Precipitations[i].HasChildNodes
                                    ? nodes.Precipitations[i].InnerText.ToNullableDouble()
                                    : null,
                            WeatherDescription = nodes.WeatherDescriptions[i].OuterXml
                        };

                    list.Add(item);
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
            }

            return list;
        }
    }
}
