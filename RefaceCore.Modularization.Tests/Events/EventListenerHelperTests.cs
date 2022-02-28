using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Starters;
using RefaceCore.Modularization.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefaceCore.Modularization.Events.Tests
{
    [TestClass()]
    public class EventListenerHelperTests
    {
        #region 测试类型

        [RegisterAs(typeof(IEventListener<string>))]
        public class OnString : IEventListener<string>
        {
            public Task HandleEvent(string data)
            {
                return Task.CompletedTask;
            }
        }

        #endregion

        public IServiceProvider ServiceProvider { get; set; }

        [TestInitialize]
        public void OnInit()
        {
            IAppStarter appStarter = new UnitTestStarter(this);
            appStarter.Start<TestModule>();
        }

        [TestMethod()]
        public void GetEventListenerTypeByEventDataTypeTest()
        {
            IEnumerable<object> listeners = EventListenerHelper.GetListenersFromServiceProvider(this.ServiceProvider, typeof(string));
            Assert.AreEqual(1, listeners.Count());

            Assert.IsInstanceOfType(listeners.ElementAt(0), typeof(OnString));
        }
    }
}