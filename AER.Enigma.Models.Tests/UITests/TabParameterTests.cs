// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TabParameterTests.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Represents a set of tests of the TabParameter class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Tests.UITests
{
    using AER.Enigma.Models.UI;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Represents a set of tests for the <see cref="TabParameter"/> class.
    /// </summary>
    [TestClass]
    public class TabParameterTests
    {
        #region Fields

        /// <summary>
        /// Stores an instance of the <see cref="TabParameter"/> class.
        /// </summary>
        private TabParameter tabParameter;

        #endregion Fields

        #region Initialize Test

        /// <summary>
        /// Creates a new instance of the <see cref="TabParameter"/> class on initialization of the test suite in order to test the properties of that class.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.tabParameter = new TabParameter();
        }

        #endregion Initialize Test

        #region Constructor Test

        /// <summary>
        /// Constructor test for the <see cref="TabParameter"/> class.
        /// </summary>
        [TestMethod]
        public void TabParameterConstructorTest()
        {
            // TODO could be memory problems running it too much
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                TabParameter expected = new TabParameter();
                Assert.IsNotNull(expected);
            }
        }

        #endregion Constructor Test

        #region Method Tests

        /// <summary>
        /// Test for the <see cref="TabParameter.TabIndex"/> property of the <see cref="TabParameter"/> class.
        /// </summary>
        [TestMethod]
        public void TabIndexTest()
        {
            for (int i = 0; i < UnitTestHelpers.TestRecurrence; ++i)
            {
                int expected = UnitTestHelpers.Next();
                this.tabParameter.TabIndex = expected;
                int actual = this.tabParameter.TabIndex;
                Assert.AreEqual(expected, actual);
            }
        }
        
        #endregion Method Tests
    }
}
