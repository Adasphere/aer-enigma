// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitTestHelpers.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   A container for properties and methods that are useful for running unit tests
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Models.Tests
{
    using System;

    /// <summary>
    /// A container for properties and methods that are useful for running unit tests
    /// </summary>
    public class UnitTestHelpers
    {
        /// <summary>
        /// The number of times a give unit test should be run.
        /// </summary>
        public static readonly int TestRecurrence = 10000;

        /// <summary>
        /// A static instance of a pseudo-random number generator.
        /// </summary>
        private static readonly Random Random = new Random();

        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is greater than or equal to 0 and less than MaxValue
        /// </returns>
        public static int Next()
        {
            return Random.Next();
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minValue">
        /// The inclusive lower bound of the random number returned
        /// </param>
        /// <param name="maxValue">
        /// The exclusive upper bound of the random number returned
        /// </param>
        /// <returns>
        /// A 32-bit signed integer greater than or equal to minValue and less than maxValue.
        /// </returns>
        public static int Next(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0 and less than 1.0
        /// </summary>
        /// <returns>
        /// A double-precision floating point number that is greater than or equal to 0.0 and less than 1.0
        /// </returns>
        public static double NextDouble()
        {
            return Random.NextDouble();
        }

        /// <summary>
        /// Returns a random bool value of true or false
        /// </summary>
        /// <returns>
        /// A bool that is either true or false
        /// </returns>
        public static bool NextBool()
        {
            return (Random.Next() % 2) == 0;
        }
    }
}
