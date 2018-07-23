// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AlertTests.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents a set of tests of the Alert class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Tests.BusinessTests
{
    using System;

    using AER.Enigma.Models.Business;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents a set of tests for the <see cref="Alert"/> class.
    /// </summary>
    [TestClass]
    public class AlertTests
    {
        #region Fields

        /// <summary>
        /// Stores an instance of the <see cref="Alert"/> class.
        /// </summary>
        private Alert alert;

        #endregion Fields

        #region Initialize Test

        /// <summary>
        /// Creates a new instance of the <see cref="Alert"/> class on initialization of the test suite in order to test the properties of that class.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.alert = new Alert();
        }

        #endregion Initialize Test

        #region Constructor Test

        /// <summary>
        /// Constructor test for the <see cref="Alert"/> class.
        /// </summary>
        [TestMethod]
        public void AlertConstructorTest()
        {
            // TODO could be memory problems running it too much
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                Alert expected = new Alert();
                Assert.IsNotNull(expected);
            }
        }

        #endregion Constructor Test

        #region Method Tests

        /// <summary>
        /// Test for the <see cref="Alert.Title"/> property of the <see cref="Alert"/> class.
        /// </summary>
        [TestMethod]
        public void TitleTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                string expected = Guid.NewGuid().ToString();
                this.alert.Title = expected;
                string actual = this.alert.Title;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Alert.Message"/> property of the <see cref="Alert"/> class.
        /// </summary>
        [TestMethod]
        public void MessageTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                string expected = Guid.NewGuid().ToString();
                this.alert.Message = expected;
                string actual = this.alert.Message;
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for the <see cref="Alert.Length"/> property of the <see cref="Alert"/> class.
        /// </summary>
        [TestMethod]
        public void LengthTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                TimeSpan expected = TimeSpan.FromSeconds(UnitTestHelpers.Next());
                this.alert.Length = expected;
                TimeSpan actual = this.alert.Length;
                Assert.AreEqual(expected, actual);
            }
        }

        #endregion Method Tests
    }
}
