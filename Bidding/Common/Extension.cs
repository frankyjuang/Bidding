using System;
using System.Collections.Generic;
using System.Linq;

namespace Bidding.Common
{
    public static class Extensions
    {
        public static T ElementAtLast<T>(this IEnumerable<T> source, int n)
        {
            return source.SkipLast(n - 1).Last();
        }

        public static Range Intersect(this Range source, Range other)
        {
            if (source.Min < other.Min)
            {
                return new Range { Min = other.Min, Max = Math.Min(source.Max, other.Max) };
            }
            if (source.Min > other.Min && source.Min < other.Max)
            {
                return new Range { Min = source.Min, Max = Math.Min(source.Max, other.Max) };
            }
            return null;
        }

        public static TEnum Previous<TEnum>(this TEnum src) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException();
            }

            var enums = (TEnum[])Enum.GetValues(src.GetType());
            var i = Array.IndexOf<TEnum>(enums, src);
            return (i == 0) ? enums[enums.Length - 1] : enums[i - 1];
        }

        public static TEnum Next<TEnum>(this TEnum src) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException();
            }

            var enums = (TEnum[])Enum.GetValues(src.GetType());
            var i = Array.IndexOf<TEnum>(enums, src);
            return (i == enums.Length - 1) ? enums[0] : enums[i + 1];
        }
    }
}