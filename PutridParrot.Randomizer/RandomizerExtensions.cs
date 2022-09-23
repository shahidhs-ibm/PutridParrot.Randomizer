using System;
using System.Collections.Generic;
using System.Linq;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Extends IRandomizer with further methods
    /// </summary>
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a random integer greater or equal to 0 and less
        /// than int.MaxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <returns>An integer between 0 and less than int.MaxValue</returns>
        public static int NextInt(this IRandomizer r)
        {
            if(r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextInt(0, int.MaxValue);
        }

        /// <summary>
        /// Returns a random integer greater or equal to 0 and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="maxValue"></param>
        /// <returns>An integer between 0 and less than maxValue</returns>
        public static int NextInt(this IRandomizer r, int maxValue)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextInt(0, maxValue);
        }

        /// <summary>
        /// Returns a random integer greater or equal to the start of the
        /// Range and less than the end of the Range
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="range"></param>
        /// <returns>An integer between start of the range and less that end of the range</returns>
        public static int NextInt(this IRandomizer r, Range range)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextInt(range.Start.Value, range.End.Value);
        }

        /// <summary>
        /// Returns a random byte greater or equal to 0 and less
        /// than byte.MaxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <returns>An byte between 0 and less than byte.MaxValue</returns>
        public static int NextByte(this IRandomizer r)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextInt(0, byte.MaxValue);
        }

        /// <summary>
        /// Returns a random byte greater or equal to 0 and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="maxValue"></param>
        /// <returns>An byte  between 0 and less than maxValue</returns>
        public static int NextByte(this IRandomizer r, byte maxValue)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextInt(0, maxValue);
        }

        /// <summary>
        /// Returns a random byte greater or equal to the start of the
        /// Range and less than the end of the Range
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="range"></param>
        /// <returns>An byte between start of the range and less that end of the range</returns>
        public static byte NextByte(this IRandomizer r, Range range)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return (byte)r.NextInt(range.Start.Value, range.End.Value);
        }

        /// <summary>
        /// Returns a random double greater or equal to 0 and less
        /// than double.MaxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <returns>A double between 0 and less than double.MaxValue</returns>
        public static double NextDouble(this IRandomizer r)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextDouble(0, double.MaxValue);
        }

        /// <summary>
        /// Returns a random double greater or equal to 0 and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="maxValue"></param>
        /// <returns>A double between 0 and less than maxValue</returns>
        public static double NextDouble(this IRandomizer r, double maxValue)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextDouble(0, maxValue);
        }

        /// <summary>
        /// Returns a random long greater or equal to 0 and less
        /// than long.MaxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <returns>A long between 0 and less than long.MaxValue</returns>
        public static long NextLong(this IRandomizer r)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextLong(0, long.MaxValue);
        }

        /// <summary>
        /// Returns a random double greater or equal to 0 and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="maxValue"></param>
        /// <returns>A long between 0 and less than maxValue</returns>
        public static long NextLong(this IRandomizer r, long maxValue)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextLong(0, maxValue);
        }

        /// <summary>
        /// Returns a random double greater or equal to the supplied minValue and less
        /// than the supplied maxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>An long between minValue and less than maxValue</returns>
        public static long NextLong(this IRandomizer r, long minValue, long maxValue)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return Convert.ToInt64((maxValue * 1.0 - minValue * 1.0) * r.NextDouble(0, 1) + minValue * 1.0);
        }

        /// <summary>
        /// Returns a random boolean
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <returns>A boolean, true or false</returns>
        public static bool NextBool(this IRandomizer r)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextInt(2) == 1;
        }

        /// <summary>
        /// Returns a random boolean using the supplied probability as a threshold.
        /// If probability is less than or equal to 0, then it's an impossibility,
        /// if it's greater than or equal to 1 then it's a certainty, otherwise
        /// if the random value is greater than the probability the return is true
        /// else false.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="probability">The probability threshold</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool NextBool(this IRandomizer r, double probability)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            if (probability <= 0)
                return false;
            if (probability >= 1)
                return true;

            return r.NextDouble() >= probability;
        }


        /// <summary>
        /// Returns a random DateTime greater or equal to DateTime.Now and less than
        /// DateTime.MaxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <returns>A DateTime between DateTime.Now and less than DateTime.MaxValue</returns>
        public static DateTime NextDateTime(this IRandomizer r)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextDateTime(DateTime.Now, DateTime.MaxValue);
        }

        /// <summary>
        /// Returns a random DateTime greater or equal to DateTime.Now and less than
        /// the supplied endDateTime
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="endDateTime"></param>
        /// <returns>A DateTime between DateTime.Now and less than endDateTime</returns>
        public static DateTime NextDateTime(this IRandomizer r, DateTime endDateTime)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextDateTime(DateTime.Now, endDateTime);
        }

        /// <summary>
        /// Returns a random DateTime greater or equal to the supplied startDateTime and less than
        /// the supplied endDateTime
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns>A DateTime between startDateTime and less than endDateTime</returns>
        public static DateTime NextDateTime(this IRandomizer r, DateTime startDateTime, DateTime endDateTime)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return startDateTime.AddDays(r.NextInt((endDateTime - startDateTime).Days));
        }

        /// <summary>
        /// Returns a random Date greater or equal to DateTime.Now and less than
        /// DateTime.MaxValue
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <returns>A DateTime between DateTime.Now and less than DateTime.MaxValue</returns>
        public static DateTime NextDate(this IRandomizer r) => 
            r.NextDateTime().Date;

        /// <summary>
        /// Returns a random Date greater or equal to DateTime.Now and less than
        /// the supplied endDateTime
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="endDateTime"></param>
        /// <returns>A DateTime between DateTime.Now and less than endDateTime</returns>
        public static DateTime NextDate(this IRandomizer r, DateTime endDateTime) =>
            r.NextDateTime(endDateTime).Date;

        /// <summary>
        /// Returns a random Date greater or equal to the supplied startDateTime and less than
        /// the supplied endDateTime
        /// </summary>
        /// <param name="r">The randomizer instance</param>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns>A DateTime between startDateTime and less than endDateTime</returns>
        public static DateTime NextDate(this IRandomizer r, DateTime startDateTime, DateTime endDateTime) =>
            r.NextDateTime(startDateTime, endDateTime).Date;

        /// <summary>
        /// Returns a random item from an array from index equal to or greater
        /// than 0 index and less than the length of the array. If no array is supplied
        /// or if the index is outside of the range if the array, default(T) is return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r">The randomizer instance</param>
        /// <param name="items"></param>
        /// <returns>An item randomly selected from the list of items</returns>
        public static T NextItem<T>(this IRandomizer r, IList<T> items)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextItem(items, 0, items?.Count ?? 0);
        }

        /// <summary>
        /// Returns a random item from an array from index equal to or greater
        /// than 0 index and less than the maxIndex. If no array is supplied
        /// or if the index is outside of the range if the array, default(T) is return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r">The randomizer instance</param>
        /// <param name="items"></param>
        /// <param name="maxIndex"></param>
        /// <returns>An item randomly selected from the list of items but less than maxIndex</returns>
        public static T NextItem<T>(this IRandomizer r, IList<T> items, int maxIndex)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            return r.NextItem(items, 0, maxIndex);
        }

        /// <summary>
        /// Returns a random item from an array from the index equal to or greater
        /// than minIndex index and less than the maxIndex. If no array is supplied
        /// or if the index is outside of the range if the array, default(T) is return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r">The randomizer instance</param>
        /// <param name="items"></param>
        /// <param name="minIndex"></param>
        /// <param name="maxIndex"></param>
        /// <returns>An item from the list of items, starting at minIndex and with an index less than maxIndex</returns>
        public static T NextItem<T>(this IRandomizer r, IList<T> items, int minIndex, int maxIndex)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            if (items == null || items.Count == 0)
                return default;

            var next = r.NextInt(minIndex, maxIndex);
            return next < items.Count ? items[next] : default;
        }
        /// <summary>
        /// Returns a random item from an Enum
        /// </summary>
        /// <code>
        /// randomizer.NextItem&lt;MyEnum&gt;();
        /// </code>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="r">The randomizer instance</param>
        /// <returns>A random enum value from the TEnum</returns>
        public static TEnum NextItem<TEnum>(this IRandomizer r)
            where TEnum : Enum
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            var items = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();
            return r.NextItem(items, 0, items.Length);
        }

        /// <summary>
        /// Returns a random item from the array of params
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r">The randomizer instance</param>
        /// <param name="items"></param>
        /// <returns>A random item within the params array</returns>
        public static T NextItem<T>(this IRandomizer r, params T[] items)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            if (items == null || items.Length == 0)
                return default;

            return r.NextItem(items, 0, items.Length);
        }

        /// <summary>
        /// Takes a collection of items and shuffles/randomizes. This
        /// mutates the original collection and returns the collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="r">The randomizer instance</param>
        /// <param name="items"></param>
        /// <returns>A randomized list of the supplied items</returns>
        public static IList<T> Shuffle<T>(this IRandomizer r, IList<T> items)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            if (items == null || items.Count == 0)
                return items;

            // https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            for (var i = items.Count - 1; i > 1; i--)
            {
                var j = r.NextInt(i + 1);
                (items[j], items[i]) = (items[i], items[j]);
            }

            return items;
        }

        /// <summary>
        ///
        /// <see href="https://stackoverflow.com/questions/218060/random-gaussian-variables">source</see>
        /// </summary>
        /// <param name="r"></param>
        /// <param name="mu"></param>
        /// <param name="sigma"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static double NextGaussian(this IRandomizer r, double mu = 0, double sigma = 1)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            // uniform(0,1] random doubles
            var u1 = 1.0 - r.NextDouble();
            var u2 = 1.0 - r.NextDouble();
            // random normal(0,1)
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            // random normal(mean,stdDev^2)
            return mu + sigma * randStdNormal;
        }

        /// <summary>
        /// Returns a random string of given length mad up of characters
        /// from the supplied charset.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="length"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string NextString(this IRandomizer r, int length, string charset)
        {
            if (r == null)
                throw new ArgumentNullException(nameof(r));

            if (String.IsNullOrEmpty(charset))
                throw new ArgumentException(nameof(charset));

            var s = new char[length];
            for (var i = 0; i < length; i++)
            {
                s[i] = charset[r.NextInt(charset.Length)];
            }

            return new string(s);
        }
    }
}
