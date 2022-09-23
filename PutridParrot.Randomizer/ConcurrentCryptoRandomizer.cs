using System;

namespace PutridParrot.Randomizer
{
    /// <summary>
    /// Thread-safe <see cref="CryptoRandomizer"/> 
    /// </summary>
    public class ConcurrentCryptoRandomizer : CryptoRandomizer
    {
        public override double NextDouble(double minValue, double maxValue)
        {
            lock (_random)
            {
                return base.NextDouble(minValue, maxValue);
            }
        }
        public override void NextBytes(Span<byte> buffer)
        {
            lock (_random)
            {
                base.NextBytes(buffer);
            }
        }
        public override void NextBytes(byte[] buffer)
        {
            lock (_random)
            {
                base.NextBytes(buffer);
            }
        }

    }
}