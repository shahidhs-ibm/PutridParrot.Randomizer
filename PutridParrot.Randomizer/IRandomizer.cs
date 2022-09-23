using System;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Generates random values
    /// </summary>
    public interface IRandomizer
    {
        /// <summary>
        /// Returns a random integer greater or equal to minValue but less than maxValue
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>A random int greater or equal to minValue and less than maxValue</returns>
        int NextInt(int minValue, int maxValue);
        /// <summary>
        /// Returns a random double greater or equal to minValue but less than maxValue
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns>A random double greater or equal to minValue and less than maxValue</returns>
        double NextDouble(double minValue, double maxValue);
        /// <summary>
        /// Populates a buffer with random byes
        /// </summary>
        /// <param name="buffer"></param>
        void NextBytes(Span<byte> buffer);
        /// <summary>
        /// Populates a buffer with random byes
        /// </summary>
        /// <param name="buffer"></param>
        void NextBytes(byte[] buffer);
    }

}
