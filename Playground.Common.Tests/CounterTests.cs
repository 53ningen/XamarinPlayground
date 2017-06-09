using NUnit.Framework;

namespace Playground.Common.Tests
{
    [TestFixture]
    public class CounterTests
    {
        [Test]
        public void IncrementTest()
        {
            var counter = new Counter();
            Assert.AreEqual(0, counter.Value);
            counter.Increment();
            Assert.AreEqual(1, counter.Value);
            counter.Increment();
            Assert.AreEqual(2, counter.Value);
            counter.Increment();
            Assert.AreEqual(3, counter.Value);
        }

        [Test]
        public void DecrementTest()
        {
            var counter = new Counter();
            Assert.AreEqual(0, counter.Value);
            counter.Decrement();
            Assert.AreEqual(-1, counter.Value);
            counter.Decrement();
            Assert.AreEqual(-2, counter.Value);
            counter.Decrement();
            Assert.AreEqual(-3, counter.Value);
        }

        [Test]
        public void ResetTest()
        {
            var counter = new Counter();
            Assert.AreEqual(0, counter.Value);
            counter.Increment();
            counter.Increment();
            counter.Increment();
            Assert.AreEqual(3, counter.Value);
            counter.Reset();
            Assert.AreEqual(0, counter.Value);
        }
    }
}
