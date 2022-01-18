using System;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Extends IRandomizer with further methods
    /// </summary>
    public static class RandomizerExtensions
    {
        /// <summary>
        /// Returns a random integer greater or equal to 0 and less
        /// than int.MaxValue
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static int NextInt(this IRandomizer r) => r.NextInt(0, int.MaxValue);
        /// <summary>
        /// Returns a random integer greater or equal to 0 and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int NextInt(this IRandomizer r, int maxValue) => r.NextInt(0, maxValue);
        /// <summary>
        /// Returns a random integer greater or equal to the start of the
        /// Range and less than the end of the Range
        /// </summary>
        /// <param name="r"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int NextInt(this IRandomizer r, Range range) => r.NextInt(range.Start.Value, range.End.Value);
        /// <summary>
        /// Returns a random double greater or equal to 0 and less
        /// than double.MaxValue
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static double NextDouble(this IRandomizer r) => r.NextDouble(0, double.MaxValue);
        /// <summary>
        /// Returns a random double greater or equal to 0 and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static double NextDouble(this IRandomizer r, double maxValue) => r.NextDouble(0, maxValue);
        /// <summary>
        /// Returns a random double greater or equal to 0 and less
        /// than long.MaxValue
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static long NextLong(this IRandomizer r) => r.NextLong(0, long.MaxValue);
        /// <summary>
        /// Returns a random double greater or equal to 0 and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static long NextLong(this IRandomizer r, long maxValue) => r.NextLong(0, maxValue);
        /// <summary>
        /// Returns a random double greater or equal to the supplied minValue and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static long NextLong(this IRandomizer r, long minValue, long maxValue) =>
            Convert.ToInt64((maxValue * 1.0 - minValue * 1.0) * r.NextDouble(0, 1) + minValue * 1.0);
        /// <summary>
        /// Returns a random boolean
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool NextBool(this IRandomizer r) => r.NextInt(2) == 1;
        /// <summary>
        /// Returns a random DateTime greater or equal to DateTime.Now and less than
        /// DateTime.MaxValue
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static DateTime NextDateTime(this IRandomizer r) => r.NextDateTime(DateTime.Now, DateTime.MaxValue);
        /// <summary>
        /// Returns a random DateTime greater or equal to DateTime.Now and less than
        /// the supplied endDateTime
        /// </summary>
        /// <param name="r"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public static DateTime NextDateTime(this IRandomizer r, DateTime endDateTime) => r.NextDateTime(DateTime.Now, endDateTime);
        /// <summary>
        /// Returns a random DateTime greater or equal to the supplied startDateTime and less than
        /// the supplied endDateTime
        /// </summary>
        /// <param name="r"></param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public static DateTime NextDateTime(this IRandomizer r, DateTime startDateTime, DateTime endDateTime) => 
            startDateTime.AddDays(r.NextInt((endDateTime - startDateTime).Days));
        /// <summary>
        /// Returns a random item from an array from index equal to or greater
        /// than 0 index and less than the length of the array. If no array is supplied
        /// or if the index is outside of the range if the array, default(T) is return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static T NextItem<T>(this IRandomizer r, T[] items) => r.NextItem(items, 0, items?.Length ?? 0);
        /// <summary>
        /// Returns a random item from an array from index equal to or greater
        /// than 0 index and less than the maxIndex. If no array is supplied
        /// or if the index is outside of the range if the array, default(T) is return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r"></param>
        /// <param name="items"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
        public static T NextItem<T>(this IRandomizer r, T[] items, int maxIndex) => r.NextItem(items, 0, maxIndex);
        /// <summary>
        /// Returns a random item from an array from the index equal to or greater
        /// than minIndex index and less than the maxIndex. If no array is supplied
        /// or if the index is outside of the range if the array, default(T) is return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r"></param>
        /// <param name="items"></param>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns></returns>
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
