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
        protected readonly RandomNumberGenerator _random;

        public CryptoRandomizer()
        {
            _random = RandomNumberGenerator.Create();
        }

        public int NextInt(int minValue, int maxValue)
        {
            return RandomNumberGenerator.GetInt32(minValue, maxValue);
        }

        public virtual double NextDouble(double minValue, double maxValue)
        {
            var data = new byte[sizeof(uint)];
            _random.GetBytes(data);
            var randValue = BitConverter.ToUInt32(data, 0);
            return randValue / (uint.MaxValue + 1.0);
        }

        public virtual void NextBytes(Span<byte> buffer)
        {
            _random.GetBytes(buffer);
        }

        public virtual void NextBytes(byte[] buffer)
        {
            _random.GetBytes(buffer);
        }
    }
}