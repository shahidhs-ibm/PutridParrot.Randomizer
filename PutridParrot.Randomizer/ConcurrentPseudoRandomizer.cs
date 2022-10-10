using System;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Implementation of a threadsafe <see cref="IRandomizer"/>
    /// </summary>
    public class ConcurrentPseudoRandomizer : IRandomizer
    {
        private readonly PseudoRandomizer _random;

        public ConcurrentPseudoRandomizer()
        {
            _random = new PseudoRandomizer();
        }

        public ConcurrentPseudoRandomizer(int seed)
        {
            _random = new PseudoRandomizer(seed);
        }

        public int NextInt(int minValue, int maxValue)
        {
            lock (_random)
            {
                return _random.NextInt(minValue, maxValue);
            }
        }

        public double NextDouble(double minValue, double maxValue)
        {
            lock (_random)
            {
                return _random.NextDouble();
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