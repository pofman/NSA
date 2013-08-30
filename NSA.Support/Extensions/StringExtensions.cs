using System;
using System.Collections.Generic;
using System.Linq;

namespace NSA.Support.Extensions
{
    public static class StringExtensions
    {
        public static string Join<T>(this IEnumerable<T> enumerable, string separator, Func<T, string> converter)
        {
            return string.Join(separator, enumerable.Select(converter).ToArray());
        }

        public static string Join<T>(this IEnumerable<T> enumerable, string separator)
        {
            return enumerable.Join(separator, x => x.ToString());
        }
    }
}
