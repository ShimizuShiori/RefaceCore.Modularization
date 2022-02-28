using RefaceCore.Modularization.Attributes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefaceCore.Modularization.Events
{
    /// <summary>
    /// 默认实现
    /// </summary>
    [RegisterAs(typeof(IEventBus))]
    public class DefaultEventBus : IEventBus
    {
        private readonly IServiceProvider serviceProvider;

        public DefaultEventBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task Publish(object eventData)
        {
            IDictionary<Type, IEnumerable<object>> listeners = EventListenerHelper.GetAllListeners(this.serviceProvider, eventData.GetType());

            ICollection<Func<Task>> invokers = new List<Func<Task>>();
            foreach (var item in listeners)
            {
                foreach (var listner in item.Value)
                {
                    Func<Task> invoker = EventListenerHelper.GetProxiedInvoker(
                        listner,
                        item.Key,
                        eventData
                    );
                    invokers.Add(invoker);
                }
            }
            foreach (var invoker in invokers)
                await invoker();
        }
    }
}
