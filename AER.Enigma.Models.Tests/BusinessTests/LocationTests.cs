// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationTests.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents a set of tests of the Location class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Tests.BusinessTests
{
    using System;

    using AER.Enigma.Models.Business;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents a set of tests for the <see cref="Location"/> class.
    /// </summary>
    [TestClass]
    public class LocationTests
    {
        #region Fields

        /// <summary>
        /// Stores an instance of the <see cref="Location"/> class.
        /// </summary>
        private Location location;

        #endregion Fields

        #region Initialize Test

        /// <summary>
        /// Creates a new instance of the <see cref="Location"/> class on initialization of the test suite in order to test the properties of that class.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.location = new Location();
        }

        #endregion Initialize Test

        #region Constructor Test

        /// <summary>
        /// Constructor test for the <see cref="Location"/> class.
        /// </summary>
        [TestMethod]
        public void LocationConstructorTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                Location expected = new Location();
                Assert.IsNotNull(expected);
            }
        }

        #endregion Constructor Test

        #region Method Tests

        /// <summary>
        /// Test for the <see cref="Location.Latitude"/> property of the <see cref="Location"/> class.
        /// </summary>
        [TestMethod]
        public void LatitudeTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.location.Latitude = expected;
                double actual = this.location.Latitude;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Location.Longitude"/> property of the <see cref="Location"/> class.
        /// </summary>
        [TestMethod]
        public void LongitudeTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.location.Longitude = expected;
                double actual = this.location.Longitude;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Location.ZipCode"/> property of the <see cref="Location"/> class.
        /// </summary>
        [TestMethod]
        public void ZipCodeTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                int expected = UnitTestHelpers.Next();
                this.location.ZipCode = expected;
                int actual = this.location.ZipCode;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Location.City"/> property of the <see cref="Location"/> class.
        /// </summary>
        [TestMethod]
        public void CityTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                string expected = Guid.NewGuid().ToString();
                this.location.City = expected;
                string actual = this.location.City;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Location.State"/> property of the <see cref="Location"/> class.
        /// </summary>
        [TestMethod]
        public void StateTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                string expected = Guid.NewGuid().ToString();
                this.location.State = expected;
                string actual = this.location.State;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Location.Country"/> property of the <see cref="Location"/> class.
        /// </summary>
        [TestMethod]
        public void CountryTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                string expected = Guid.NewGuid().ToString();
                this.location.Country = expected;
                string actual = this.location.Country;
                Assert.AreEqual(expected, actual);
            }
        }

        #endregion Method Tests
    }
}
