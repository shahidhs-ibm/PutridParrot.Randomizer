using System;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Thread-safe implementation of the crypto based random
    /// generator
    /// </summary>
    public class ConcurrentCryptoRandomizer : IRandomizer
    {
        protected readonly CryptoRandomizer _random;

        public ConcurrentCryptoRandomizer()
        {
            _random = new CryptoRandomizer();
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
                return _random.NextDouble(minValue, maxValue);
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