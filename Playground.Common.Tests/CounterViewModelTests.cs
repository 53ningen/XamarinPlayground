using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Playground.Common.Tests
{
    [TestFixture]
    public class CounterViewModelTests
    {
        [Test]
        public void IncrementTest()
        {
            var vm = new CounterViewModel();
            Assert.AreEqual("0", vm.CounterValue.Value);
            vm.Increment.Execute();
            Assert.AreEqual("1", vm.CounterValue.Value);
            vm.Increment.Execute();
            Assert.AreEqual("2", vm.CounterValue.Value);
            vm.Increment.Execute();
            Assert.AreEqual("3", vm.CounterValue.Value);
        }

        [Test]
        public void DecrementTest()
        {
            var vm = new CounterViewModel();
            Assert.AreEqual("0", vm.CounterValue.Value);
            vm.Decrement.Execute();
            Assert.AreEqual("-1", vm.CounterValue.Value);
            vm.Decrement.Execute();
            Assert.AreEqual("-2", vm.CounterValue.Value);
            vm.Decrement.Execute();
            Assert.AreEqual("-3", vm.CounterValue.Value);
            vm.Decrement.Execute();
            Assert.AreEqual("-4", vm.CounterValue.Value);
            vm.Decrement.Execute();
            Assert.AreEqual("-5", vm.CounterValue.Value);
        }

        [Test]
        public void ResetTest()
        {
            var vm = new CounterViewModel();
            Assert.AreEqual("last value: ---", vm.Title.Value);
            Assert.AreEqual("0", vm.CounterValue.Value);
            vm.Increment.Execute();
            vm.Increment.Execute();
            vm.Increment.Execute();
            Assert.AreEqual("last value: ---", vm.Title.Value);
            Assert.AreEqual("3", vm.CounterValue.Value);
            vm.Reset.Execute();
            Task.Delay(2000).Wait();
            Assert.AreEqual("last value: 3", vm.Title.Value);
            Assert.AreEqual("0", vm.CounterValue.Value);
        }
    }
}
