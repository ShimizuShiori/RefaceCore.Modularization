using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefaceCore.Modularization.Events
{
    /// <summary>
    /// 默认实现
    /// </summary>
    public class DefaultEventBus : IEventBus
    {
        private readonly IServiceProvider serviceProvider;

        public DefaultEventBus(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task Publish(object eventData)
        {
            Type eventDataType = eventData.GetType();
            Type[] allInterfaces = eventDataType.GetInterfaces();
            IEnumerable<Type> allBaseType = eventDataType.GetAllBaseTypes();

            ICollection<object> listeners = new List<object>();
            foreach (Type interfaceType in allInterfaces)
            {
                Type listenerType = typeof(IEventListener<>)
                    .MakeGenericType(interfaceType);
                listeners.AddMany(serviceProvider.GetServices(interfaceType));
            }

            throw new NotImplementedException();
        }
    }
}
