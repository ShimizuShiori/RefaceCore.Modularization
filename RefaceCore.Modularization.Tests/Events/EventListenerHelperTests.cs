using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Starters;
using RefaceCore.Modularization.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public class D
        {
            public int I { get; set; } = 0;
        }

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
                return Task.CompletedTask;
            }
        }

        [RegisterAs(typeof(IEventListener<D>))]
        public class OnD : IEventListener<D>
        {
            public async Task HandleEvent(D data)
            {
                await Task.Run(() => data.I = 100);
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
            IDictionary<Type, IEnumerable<object>> listeners = EventListenerHelper.GetAllListeners(this.ServiceProvider, typeof(OnE));
            Assert.AreEqual(6, listeners.Count());
            Assert.AreEqual(1, listeners[typeof(IA)].Count());
            Assert.AreEqual(1, listeners[typeof(IB)].Count());
            Assert.AreEqual(0, listeners[typeof(IC)].Count());
            Assert.AreEqual(1, listeners[typeof(D)].Count());
            Assert.AreEqual(1, listeners[typeof(object)].Count());
        }

        [TestMethod()]
        public async Task InvokeListenerTestAsync()
        {
            Delegate del = EventListenerHelper.GetInvoker(typeof(OnD), typeof(D));
            D d = new D();
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await EventListenerHelper.InvokeListener(del, new OnD(), d);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Assert.AreEqual(100, d.I);
        }

        [TestMethod()]
        public async Task GetProxiedInvokerTestAsync()
        {
            Delegate del = EventListenerHelper.GetInvoker(typeof(OnD), typeof(D));
            D d = new D();
            IEventListener<D> ond = ServiceProvider.GetService<IEventListener<D>>();
            Func<Task> func = EventListenerHelper.GetProxiedInvoker(
                ond,
                typeof(D),
                d
            );
            await func();
            Assert.AreEqual(100, d.I);
        }
    }
}