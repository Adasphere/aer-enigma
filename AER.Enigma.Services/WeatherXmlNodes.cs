using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Services
{
    using System.Xml;

    internal class WeatherXmlNodes
    {
        public XmlNodeList Starts
        {
            get;
            set;
        }

        public XmlNodeList Ends
        {
            get;
            set;
        }

        public XmlNodeList DewPoints
        {
            get;
            set;
        }

        public XmlNodeList HeatIndexes
        {
            get;
            set;
        }

        public XmlNodeList WindSpeeds
        {
            get;
            set;
        }

        public XmlNodeList CloudAmounts
        {
            get;
            set;
        }

        public XmlNodeList ProbabilityPrecipitations
        {
            get;
            set;
        }

        public XmlNodeList Humidities
        {
            get;
            set;
        }

        public XmlNodeList WindDirections
        {
            get;
            set;
        }

        public XmlNodeList Temperatures
        {
            get;
            set;
        }

        public XmlNodeList WindGusts
        {
            get;
            set;
        }

        public XmlNodeList Precipitations
        {
            get;
            set;
        }

        public XmlNodeList WeatherDescriptions
        {
            get;
            set;
        }
    }
}
