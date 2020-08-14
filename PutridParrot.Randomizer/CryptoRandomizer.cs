using System;
using System.Security.Cryptography;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Implementation of IRandomizer based upon the crypto based random
    /// generator
    /// </summary>
    public class CryptoRandomizer : IRandomizer
    {
        private readonly RandomNumberGenerator _random;

        public CryptoRandomizer()
        {
            _random = RandomNumberGenerator.Create();
        }

        public int NextInt(int minValue, int maxValue)
        {
            return RandomNumberGenerator.GetInt32(minValue, maxValue);
        }

        public double NextDouble(double minValue, double maxValue)
        {
            lock (_random)
            {
                var data = new byte[sizeof(uint)];
                _random.GetBytes(data);
                var randValue = BitConverter.ToUInt32(data, 0);
                return randValue / (uint.MaxValue + 1.0);
            }
        }
        public void NextBytes(Span<byte> buffer)
        {
            lock (_random)
            {
                _random.GetBytes(buffer);
            }
        }
        public void NextBytes(byte[] buffer)
        {
            lock (_random)
            {
                _random.GetBytes(buffer);
            }
        }
    }
}