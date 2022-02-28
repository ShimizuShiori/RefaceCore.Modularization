using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RefaceCore.Modularization.Events
{
    public static class EventListenerHelper
    {
        private static Type TYPE_LISTENER = typeof(IEventListener<>);

        public static Type GetEventListenerType(Type eventDataType)
        {
            return TYPE_LISTENER.MakeGenericType(eventDataType);
        }

        public static IEnumerable<Type> GetAllEventDataType(Type eventDataType)
        {
            return eventDataType.GetInterfaces()
                .Concat(eventDataType.GetAllBaseTypes().Reverse())
                .Concat(new Type[] { eventDataType });
        }

        public static IEnumerable<object> GetListeners(IServiceProvider sp, Type eventDataType)
        {
            Type listenerType = EventListenerHelper.GetEventListenerType(eventDataType);
            return sp.GetServices(listenerType);
        }

        public static IEnumerable<object> GetAllListeners(IServiceProvider serviceProvider, Type eventDataType)
        {
            return GetAllEventDataType(eventDataType)
                .SelectMany(type => GetListeners(serviceProvider, type));
        }
    }
}
