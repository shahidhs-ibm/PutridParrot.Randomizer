using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using PutridParrot.Randomizer;

namespace Tests.PutridParrot.Randomizer
{
    /// <summary>
    /// Obviously the underlying IRandomizer
    /// is non-deterministic in nature, so these
    /// are more like integration tests
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class RandomizerTests
    {
        [Test]
        [Repeat(100)]
        public void NextDateTime_FromTodayUntilDateTimeMaxValue()
        {
            var randomGenerator = new PseudoRandomizer();
            var now = DateTime.Now;
            var next = randomGenerator.NextDateTime();
            Assert.IsTrue(next >= now);
            Assert.IsTrue(next < DateTime.MaxValue);
        }

        [Test]
        [Repeat(100)]
        public void NextDateTime_FromTodayUntilSuppliedEndDateTime()
        {
            var randomGenerator = new PseudoRandomizer();
            var now = DateTime.Now;
            var endDateTime = now.AddDays(2);
            var next = randomGenerator.NextDateTime(endDateTime);
            Assert.IsTrue(next >= now, $"{next} >= now");
            Assert.IsTrue(next < endDateTime, $"{next} < endDateTime");
        }

        [Test]
        [Repeat(100)]
        public void NextDateTime_FromStartDateTimeUntilEndDateTime()
        {
            var randomGenerator = new PseudoRandomizer();
            var startDateTime = DateTime.Now.AddDays(3);
            var endDateTime = startDateTime.AddDays(2);
            var next = randomGenerator.NextDateTime(startDateTime, endDateTime);
            Assert.IsTrue(next >= startDateTime, $"{next} >= startDateTime");
            Assert.IsTrue(next < endDateTime, $"{next} < endDateTime");
        }

        [Test]
        public void NextItem_FromNullArrayExpectNull()
        {
            var randomGenerator = new PseudoRandomizer();
            Assert.IsNull(randomGenerator.NextItem<string>(null!));
        }

        [Test]
        public void NextItem_FromEmptyArrayExpectNull()
        {
            var randomGenerator = new PseudoRandomizer();
            Assert.IsNull(randomGenerator.NextItem(new string[] { }));
        }

        [Test]
        [Repeat(100)]
        public void NextItem_FromArrayWithItems_ExpectNonNull()
        {
            var randomGenerator = new PseudoRandomizer();
            Assert.IsNotNull(randomGenerator.NextItem(new[]
            {
                "One",
                "Two",
                "Three"
            }));
        }

        [Test]
        [Repeat(100)]
        public void NextItem_FromArrayWithItems_ExpectOccasionalHit()
        {
            var randomGenerator = new PseudoRandomizer();
            var items = new []
            {
                "One",
                "Two"
            };
            Assert.IsTrue(items.Contains(randomGenerator.NextItem(items)));
        }
    }
}