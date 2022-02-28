using RefaceCore.Modularization.Events;
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

        public interface IA { }
        public interface IB { }
        public interface IC { }
        public class D { }

        public class OnE : D, IA, IB, IC { }

        [RegisterAs(typeof(IEventListener<IA>))]
        public class OnIA : IEventListener<IA>
        {
            public Task HandleEvent(IA data)
            {
                throw new NotImplementedException();
            }
        }

        [RegisterAs(typeof(IEventListener<IB>))]
        public class OnIB : IEventListener<IB>
        {
            public Task HandleEvent(IB data)
            {
                throw new NotImplementedException();
            }
        }

        [RegisterAs(typeof(IEventListener<object>))]
        public class OnAny : IEventListener<object>
        {
            public Task HandleEvent(object data)
            {
                throw new NotImplementedException();
            }
        }

        [RegisterAs(typeof(IEventListener<D>))]
        public class OnD : IEventListener<D>
        {
            public Task HandleEvent(D data)
            {
                throw new NotImplementedException();
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
            IEnumerable<object> listeners = EventListenerHelper.GetListeners(this.ServiceProvider, typeof(string));
            Assert.AreEqual(1, listeners.Count());

            Assert.IsInstanceOfType(listeners.ElementAt(0), typeof(OnString));
        }

        [TestMethod()]
        public void GetAllEventDataTypeTest()
        {
            IEnumerable<Type> allEventDataTypes = EventListenerHelper.GetAllEventDataType(typeof(OnE));
            Assert.AreEqual(6, allEventDataTypes.Count());
            Assert.AreEqual(typeof(IA), allEventDataTypes.ElementAt(0));
            Assert.AreEqual(typeof(IB), allEventDataTypes.ElementAt(1));
            Assert.AreEqual(typeof(IC), allEventDataTypes.ElementAt(2));
            Assert.AreEqual(typeof(object), allEventDataTypes.ElementAt(3));
            Assert.AreEqual(typeof(D), allEventDataTypes.ElementAt(4));
            Assert.AreEqual(typeof(OnE), allEventDataTypes.ElementAt(5));
        }

        [TestMethod()]
        public void GetAllListenersTest()
        {
            IEnumerable<object> listeners = EventListenerHelper.GetAllListeners(this.ServiceProvider, typeof(OnE));
            Assert.AreEqual(4, listeners.Count());
        }
    }
}