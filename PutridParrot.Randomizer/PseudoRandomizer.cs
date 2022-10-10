using System;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Implementation of IRandomizer based upon the pseudo random
    /// generator <see cref="System.Random"/>
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

        public int NextInt(int minValue, int maxValue) => _random.Next(minValue, maxValue);

        public double NextDouble(double minValue, double maxValue) => _random.NextDouble() * (maxValue - minValue) + minValue;

        public void NextBytes(Span<byte> buffer) => _random.NextBytes(buffer);

        public void NextBytes(byte[] buffer) => _random.NextBytes(buffer);
    }
}