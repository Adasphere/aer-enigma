// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreExtensionsTests.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents a set of tests for the CoreExtensions class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Core.Tests
{
    using System;
    using System.Globalization;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents a set of tests for the <see cref="CoreExtensions"/> class.
    /// </summary>
    [TestClass]
    public class CoreExtensionsTests
    {
        /// <summary>
        /// Generates random numbers that can be used in the tests.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// A string that cannot be parsed as a valid integer or double
        /// </summary>
        private static readonly string FailureString = new Guid().ToString();

        /// <summary>
        /// Test for the <see cref="CoreExtensions.ToNullableDouble"/> method of the <see cref="CoreExtensions"/> class.
        /// </summary>
        [TestMethod]
        public void ToNullableDoubleTest()
        {
            double? actual = ((string)null).ToNullableDouble();
            Assert.IsNull(actual, $"{nameof(CoreExtensions.ToNullableDouble)} did not return null when passed null");
            actual = FailureString.ToNullableDouble();
            Assert.IsNull(actual, $"{nameof(CoreExtensions.ToNullableDouble)} did not return null when passed a garbage string");

            actual = $"1.0E{Random.Next(300, 400)}".ToNullableDouble();
            Assert.IsNull(actual, $"{nameof(CoreExtensions.ToNullableDouble)} did not return null when passed a number greater than Double.MaxValue");

            actual = $"1.0E-{Random.Next(400, 500)}".ToNullableDouble();
            Assert.IsNull(actual, $"{nameof(CoreExtensions.ToNullableDouble)} did not return null when passed a number less than Double.MinValue");
            
            double? expected = Random.NextDouble();
            actual = expected.ToString().ToNullableDouble();
            Assert.AreEqual(expected, actual, $"Actual result: {actual} did not match expected result: {expected}");
        }

        /// <summary>
        /// Test for the <see cref="CoreExtensions.ToNullableint"/> method of the <see cref="CoreExtensions"/> class.
        /// </summary>
        [TestMethod]
        public void ToNullableIntTest()
        {
            double? actual = ((string)null).ToNullableint();
            Assert.IsNull(actual, $"{nameof(CoreExtensions.ToNullableint)} did not return null when passed null");
            actual = FailureString.ToNullableDouble();
            Assert.IsNull(actual, $"{nameof(CoreExtensions.ToNullableint)} did not return null when passed a garbage string");

            actual = long.MaxValue.ToString().ToNullableint();
            Assert.IsNull(actual, $"{nameof(CoreExtensions.ToNullableint)} did not return null when passed a number greater than Int32.MaxValue");

            actual = long.MinValue.ToString().ToNullableint();
            Assert.IsNull(actual, $"{nameof(CoreExtensions.ToNullableint)} did not return null when passed a number less than Int32.MinValue");

            double? expected = Random.Next();
            actual = expected.ToString().ToNullableint();
            Assert.AreEqual(expected, actual, $"Actual result: {actual} did not match expected result: {expected}");
        }
    }
}
