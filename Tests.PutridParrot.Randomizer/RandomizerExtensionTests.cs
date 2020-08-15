using System;
using NUnit.Framework;
using PutridParrot.Randomizer;
using Telerik.JustMock;

namespace Tests.PutridParrot.Randomizer
{
    public class RandomizerExtensionTests
    {
        [Test]
        public void NextBool_IfNextInt0_ExpectFalse()
        {
            var mock = Mock.Create<IRandomizer>();

            Mock.Arrange(() => mock.NextInt(0, 2)).Returns(0);

            Assert.IsFalse(mock.NextBool());
        }

        [Test]
        public void NextBool_IfNextInt1_ExpectTrue()
        {
            var mock = Mock.Create<IRandomizer>();

            Mock.Arrange(() => mock.NextInt(0, 2)).Returns(1);

            Assert.IsTrue(mock.NextBool());
        }

        [Test]
        public void NextDateTime_WithKnownValue_ExpectCorrespondingDateTime()
        {
            var mock = Mock.Create<IRandomizer>();

            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddDays(5);

            Mock.Arrange(() => mock.NextInt(0, 5)).Returns(2);

            Assert.AreEqual(startDate.AddDays(2).Date, mock.NextDateTime(startDate, endDate));
        }

        [Test]
        public void NextItem_WithKnownValue_ExpectCorrespondingItem()
        {
            var mock = Mock.Create<IRandomizer>();

            var array = new[]
            {
                "A", "B", "C"
            };

            Mock.Arrange(() => mock.NextInt(0, 3)).Returns(1);

            Assert.AreEqual("B", mock.NextItem(array));
        }

        [Test]
        public void NextItem_WithKnownValueAndMaxIndexInRange_ExpectCorrespondingItem()
        {
            var mock = Mock.Create<IRandomizer>();

            var array = new[]
            {
                "A", "B", "C"
            };

            Mock.Arrange(() => mock.NextInt(0, 3)).Returns(0);

            Assert.AreEqual("A", mock.NextItem(array, 2));
        }

        [Test]
        public void NextItem_WithKnownValueUsingMinIndexAndMaxIndexInRange_ExpectCorrespondingItem()
        {
            var mock = Mock.Create<IRandomizer>();

            var array = new[]
            {
                "A", "B", "C"
            };

            Mock.Arrange(() => mock.NextInt(0, 3)).Returns(2);

            Assert.AreEqual("C", mock.NextItem(array, 0, 3));
        }
    }
}
