using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Tests;
using System.Threading.Tasks;

namespace RefaceCore.Modularization.Events.Tests
{
    [TestClass()]
    public class DefaultEventBusTests
    {
        #region 测试类

        public interface IEvent1
        {
            int ValueOfEvent1 { get; set; }
        }

        public class TestEvent : IEvent1
        {
            public string Word { get; set; } = "";
            public int ValueOfEvent1 { get; set; } = 0;
        }

        [AutoRegister]
        public class OnTest : IEventListener<TestEvent>
        {
            public async Task HandleEvent(TestEvent data)
            {
                await Task.Run(() => data.Word = "TESTED");
            }
        }

        [AutoRegister]
        public class OnEvent1 : IEventListener<IEvent1>
        {
            public async Task HandleEvent(IEvent1 data)
            {
                await Task.Run(() => data.ValueOfEvent1 = 100);
            }
        }

        #endregion

        [TestInitialize]
        public void OnInit()
        {
            new UnitTestStarter(this).Start<TestModule>();
        }

        public IEventBus EventBus { get; set; }

        [TestMethod()]
        public async Task PublishTestAsync()
        {
            TestEvent te = new TestEvent();
            await EventBus.Publish(te);
            Assert.AreEqual("TESTED", te.Word);
            Assert.AreEqual(100, te.ValueOfEvent1);
        }
    }
}