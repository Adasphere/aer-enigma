using System;
using System.Collections.Generic;
using System.Text;

namespace AER.Enigma.Core
{
    public static class CoreExtensions
    {
        public static double? ToNullableDouble(this string value)
        {
            return value == null ? (double?)null : Convert.ToDouble(value);
        }

        public static int? ToNullableint(this string value)
        {
            return value == null ? (int?)null : Convert.ToInt32(value);
        }

    }
}
