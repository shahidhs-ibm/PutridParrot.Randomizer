using System;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Extends IRandomizer with further methods
    /// </summary>
    public static class RandomizerExtensions
    {
        public static int NextInt(this IRandomizer r) => r.NextInt(0, int.MaxValue);

        public static int NextInt(this IRandomizer r, int maxValue) => r.NextInt(0, maxValue);

        public static double NextDouble(this IRandomizer r) => r.NextDouble(0, double.MaxValue);
        public static double NextDouble(this IRandomizer r, double maxValue) => r.NextDouble(0, maxValue);

        public static long NextLong(this IRandomizer r) => r.NextLong(0, long.MaxValue);

        public static long NextLong(this IRandomizer r, long maxValue) => r.NextLong(0, maxValue);

        public static long NextLong(this IRandomizer r, long minValue, long maxValue)
        {
            var value = (maxValue * 1.0 - minValue * 1.0) * r.NextDouble(0, 1) + minValue * 1.0;
            return Convert.ToInt64(value);
        }

        public static bool NextBool(this IRandomizer r) => r.NextInt(2) == 1;

        public static DateTime NextDateTime(this IRandomizer r)
        {
            return r.NextDateTime(DateTime.Now, DateTime.MaxValue);
        }

        public static DateTime NextDateTime(this IRandomizer r, DateTime endDateTime)
        {
            var now = DateTime.Now;
            return r.NextDateTime(now, endDateTime);
        }

        public static DateTime NextDateTime(this IRandomizer r, DateTime startDateTime, DateTime endDateTime)
        {
            var next = r.NextInt((endDateTime - startDateTime).Days);
            return startDateTime.AddDays(next);
        }

        public static T NextItem<T>(this IRandomizer r, T[] items) => r.NextItem(items, 0, items?.Length ?? 0);
        public static T NextItem<T>(this IRandomizer r, T[] items, int maxIndex) => r.NextItem(items, 0, maxIndex);

        public static T NextItem<T>(this IRandomizer r, T[] items, int minIndex, int maxIndex)
        {
            if (items == null || items.Length == 0)
            {
                return default;
            }

            var next = r.NextInt(minIndex, maxIndex);
            return next < items.Length ? items[next] : default;
        }
    }
}
