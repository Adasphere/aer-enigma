// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CoreExtensions.cs"  company="Adasphere Incorporated">
//   Copyright (c) 2018 Adasphere Incorporated. All rights reserved.
// </copyright>
// <summary>
//   Contains common extension methods used by AER-Enigma.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AER.Enigma.Core
{
    using System;

    /// <summary>
    /// Common extensions methods used by AER-Enigma.
    /// </summary>
    public static class CoreExtensions
    {
        /// <summary>
        /// Converts a string representation of a nullable double to a nullable double.
        /// </summary>
        /// <param name="value">
        /// The string being converted into a nullable double.
        /// </param>
        /// <returns>
        /// The equivalent double-precision floating point number if value is not null and null otherwise.
        /// </returns>
        public static double? ToNullableDouble(this string value)
        {
            try
            {
                return value == null ? (double?)null : Convert.ToDouble(value);
            }
            catch (FormatException)
            {
                // value was not null, but could not be converted into a number in a valid format
                // TODO determine if we need better error handling then just catching the exception.
                return null;
            }
            catch (OverflowException)
            {
                // value represents a number that is less than Double.MinValue or greater than Double.MaxValue
                return null;
            }
        }

        /// <summary>
        /// Converts a string representation of a nullable integer to a nullable integer.
        /// </summary>
        /// <param name="value">
        /// The string being converted into a nullable integer.
        /// </param>
        /// <returns>
        /// The equivalent 32-bit signed integer if value is not null and null otherwise.
        /// </returns>
        public static int? ToNullableint(this string value)
        {
            try
            {
                return value == null ? (int?)null : Convert.ToInt32(value);
            }
            catch (FormatException)
            {
                // value was not null, but could not be converted into a number in a valid format
                return null;
            }
            catch (OverflowException)
            {
                // value represents a number that is less than Int32.MinValue or greater than Int32.MaxValue
                return null;
            }
        }
    }
}
