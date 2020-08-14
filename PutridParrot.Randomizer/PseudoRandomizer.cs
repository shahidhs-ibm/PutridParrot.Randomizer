using System;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Implementation of IRandomizer based upon the pseudo random
    /// generator Random
    /// </summary>
    public class PseudoRandomizer : IRandomizer
    {
        private readonly Random _random;

        public PseudoRandomizer()
        {
            _random = new Random();
        }
        public PseudoRandomizer(int seed)
        {
            _random = new Random(seed);
        }

        public int NextInt(int minValue, int maxValue)
        {
            lock (_random)
            {
                return _random.Next(minValue, maxValue);
            }
        }

        public double NextDouble(double minValue, double maxValue)
        {
            lock (_random)
            {
                return _random.NextDouble() * (maxValue - minValue) + minValue;
            }
        }

        public void NextBytes(Span<byte> buffer)
        {
            lock (_random)
            {
                _random.NextBytes(buffer);
            }
        }
        public void NextBytes(byte[] buffer)
        {
            lock (_random)
            {
                _random.NextBytes(buffer);
            }
        }
    }
}