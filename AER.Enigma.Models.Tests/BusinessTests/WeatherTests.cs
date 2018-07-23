// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeatherTests.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents a set of tests of the Weather class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Tests.BusinessTests
{
    using System;

    using AER.Enigma.Models.Business;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents a set of tests for the <see cref="Weather"/> class.
    /// </summary>
    [TestClass]
    public class WeatherTests
    {
        #region Fields

        /// <summary>
        /// Stores an instance of the <see cref="Weather"/> class.
        /// </summary>
        private Weather weather;

        #endregion Fields

        #region Initialize Test

        /// <summary>
        /// Creates a new instance of the <see cref="Weather"/> class on initialization of the test suite in order to test the properties of that class.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.weather = new Weather();
        }

        #endregion Initialize Test

        #region Constructor Test

        /// <summary>
        /// Constructor test for the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void WeatherConstructorTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                Weather expected = new Weather();
                Assert.IsNotNull(expected);
            }
        }

        #endregion Constructor Test

        #region Method Tests

        /// <summary>
        /// Test for the <see cref="Weather.StartDateTime"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void StartDateTimeTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                DateTime expected = DateTime.Now;
                this.weather.StartDateTime = expected;
                DateTime actual = this.weather.StartDateTime;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.EndDateTime"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void EndDateTimeTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                DateTime expected = DateTime.Now;
                this.weather.EndDateTime = expected;
                DateTime actual = this.weather.EndDateTime;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.DewPoint"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void DewPointTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.DewPoint = expected;
                double? actual = this.weather.DewPoint;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.HeatIndex"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void HeatIndexTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.HeatIndex = expected;
                double? actual = this.weather.HeatIndex;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.WindSpeed"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void WindSpeedTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.WindSpeed = expected;
                double? actual = this.weather.WindSpeed;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.CloudAmount"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void CloudAmountTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.CloudAmount = expected;
                double? actual = this.weather.CloudAmount;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.ProbabilityPrecipitation"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void ProbabilityPrecipitationTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.ProbabilityPrecipitation = expected;
                double? actual = this.weather.ProbabilityPrecipitation;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.Humidity"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void HumidityTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.Humidity = expected;
                double? actual = this.weather.Humidity;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.WindDirection"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void WindDirectionTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                int? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.Next() : (int?)null;
                this.weather.WindDirection = expected;
                int? actual = this.weather.WindDirection;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.Temperature"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void TemperatureTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.Temperature = expected;
                double? actual = this.weather.Temperature;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.WindGust"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void WindGustTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.WindGust = expected;
                double? actual = this.weather.WindGust;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.Precipitation"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void PrecipitationTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double? expected = UnitTestHelpers.NextBool() ? UnitTestHelpers.NextDouble() : (double?)null;
                this.weather.Precipitation = expected;
                double? actual = this.weather.Precipitation;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Weather.WeatherDescription"/> property of the <see cref="Weather"/> class.
        /// </summary>
        [TestMethod]
        public void WeatherDescriptionTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                string expected = Guid.NewGuid().ToString();
                this.weather.WeatherDescription = expected;
                string actual = this.weather.WeatherDescription;
                Assert.AreEqual(expected, actual);
            }
        }

        #endregion Method Tests
    }
}
