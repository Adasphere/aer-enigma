// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeolocationExceptionTests.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents a set of tests of the GeolocationException class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Tests.BusinessTests
{
    using System;

    using AER.Enigma.Models.Business;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents a set of tests of the <see cref="GeolocationException"/> class.
    /// </summary>
    [TestClass]
    public class GeolocationExceptionTests
    {
        #region Fields
        
        #endregion Fields

        #region Initialize Test

        #endregion Initialize Test

        #region Constructor Test

        /// <summary>
        /// Constructor test for the <see cref="GeolocationException"/> class.
        /// </summary>
        [TestMethod]
        public void GeolocationExceptionTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                GeolocationError badValue = (GeolocationError)(-1);
                GeolocationException expected;
                foreach (GeolocationError error in (GeolocationError[])Enum.GetValues(typeof(GeolocationError)))
                {
                    expected = new GeolocationException(error);
                    Assert.IsNotNull(expected);
                }

                foreach (GeolocationError error in (GeolocationError[])Enum.GetValues(typeof(GeolocationError)))
                {
                    expected = new GeolocationException(error, new Exception());
                    Assert.IsNotNull(expected);
                }

                expected = null;
                try
                {
                    expected = new GeolocationException(badValue);
                    Assert.Fail($"No exception caught for a bad {typeof(GeolocationError)} value {badValue}.");
                }
                catch (ArgumentException)
                {
                }

                Assert.IsNull(expected, "Expected object was not null after a failed assignment operation.");
                
                try
                {
                    expected = new GeolocationException(badValue, new Exception());
                    Assert.Fail($"No exception caught for a bad {typeof(GeolocationError)} value {badValue}.");
                }
                catch (ArgumentException)
                {
                }

                Assert.IsNull(expected, "Expected object was not null after a failed assignment operation.");
            }
        }

        #endregion Constructor Test

        /// <summary>
        /// Test for the <see cref="GeolocationException.Error"/> property of the <see cref="GeolocationException"/> class.
        /// </summary>
        [TestMethod]
        public void ErrorTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                foreach (GeolocationError error in (GeolocationError[])Enum.GetValues(typeof(GeolocationError)))
                {
                    GeolocationException expected = new GeolocationException(error);
                    Assert.AreEqual(expected.Error, error);

                    expected = null;
                    Assert.IsNull(expected);

                    expected = new GeolocationException(error, new Exception());
                    Assert.AreEqual(expected.Error, error);
                }
            }
        }
    }
}
