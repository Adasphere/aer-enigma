// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PositionTests.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents a set of tests of the Position class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Tests.BusinessTests
{
    using System;

    using AER.Enigma.Models.Business;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents a set of tests of the <see cref="Position"/> class.
    /// </summary>
    [TestClass]
    public class PositionTests
    {
        #region Fields

        /// <summary>
        /// Stores an instance of the <see cref="Position"/> class.
        /// </summary>
        private Position position;

        #endregion Fields

        #region Initialize Test

        /// <summary>
        /// Creates a new instance of the <see cref="Position"/> class on initialization of the test suite in order to test the properties of that class.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.position = new Position();
        }

        #endregion Initialize Test

        #region Constructor Test

        /// <summary>
        /// Constructor test for the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void PositionConstructorTest()
        {
            // TODO could be memory problems running it too much
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                Position expected = new Position();
                Assert.IsNotNull(expected);

                try
                {
                    expected = new Position(null);
                    Assert.Fail("Exception not thrown for null assignment operation");
                }
                catch (ArgumentNullException)
                {
                }

                Assert.IsNotNull(expected, "Value of expected changed despited failed assignment operation");

                double latitude = UnitTestHelpers.NextDouble();
                double longitude = UnitTestHelpers.NextDouble();
                expected = new Position(latitude, longitude);
                Assert.AreEqual(expected.Latitude, latitude);
                Assert.AreEqual(expected.Longitude, longitude);
            }
        }

        #endregion Constructor Test

        /// <summary>
        /// Test for the <see cref="Position.Timestamp"/> property of the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void TimestampTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                DateTimeOffset expected = DateTimeOffset.Now;
                this.position.Timestamp = expected;
                DateTimeOffset actual = this.position.Timestamp;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Position.Latitude"/> property of the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void LatitudeTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.position.Latitude = expected;
                double actual = this.position.Latitude;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Position.Longitude"/> property of the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void LongitudeTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.position.Longitude = expected;
                double actual = this.position.Longitude;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Position.Altitude"/> property of the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void AltitudeTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.position.Altitude = expected;
                double actual = this.position.Altitude;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Position.Accuracy"/> property of the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void AccuracyTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.position.Accuracy = expected;
                double actual = this.position.Accuracy;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Position.AltitudeAccuracy"/> property of the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void AltitudeAccuracyTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.position.AltitudeAccuracy = expected;
                double actual = this.position.AltitudeAccuracy;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Position.Heading"/> property of the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void HeadingTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.position.Heading = expected;
                double actual = this.position.Heading;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Position.Speed"/> property of the <see cref="Position"/> class.
        /// </summary>
        [TestMethod]
        public void SpeedTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                double expected = UnitTestHelpers.NextDouble();
                this.position.Speed = expected;
                double actual = this.position.Speed;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
