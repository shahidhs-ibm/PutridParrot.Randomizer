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

        [Test]
        public void NextInt_ExpectMockValue()
        {
            var mock = Mock.Create<IRandomizer>();

            Mock.Arrange(() => mock.NextInt(0, int.MaxValue)).Returns(2);

            Assert.AreEqual(2, mock.NextInt());
        }

        //[Test]
        //public void NextLong_ExpectMockValue()
        //{
        //    var mock = Mock.Create<IRandomizer>();

        //    Mock.Arrange(() => mock.NextDouble(0, 1)).Returns(809123);

        //    Assert.AreEqual(809123, mock.NextLong());
        //}


        [Test]
        public void NextDouble_ExpectMockValue()
        {
            var mock = Mock.Create<IRandomizer>();

            Mock.Arrange(() => mock.NextDouble(0, double.MaxValue)).Returns(3.14);

            Assert.AreEqual(3.14, mock.NextDouble());
        }

        [Test]
        public void NextDoubleWithMax_ExpectMockValue()
        {
            var mock = Mock.Create<IRandomizer>();

            Mock.Arrange(() => mock.NextDouble(0, 5)).Returns(3.91);

            Assert.AreEqual(3.91, mock.NextDouble(5));
        }
    }
}
