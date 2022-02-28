using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace RefaceCore.Modularization.Events
{
    public static class EventListenerHelper
    {
        private static Type TYPE_LISTENER = typeof(IEventListener<>);

        public static Type GetEventListenerTypeByEventDataType(Type eventDataType)
        {
            return TYPE_LISTENER.MakeGenericType(eventDataType);
        }

        public static IEnumerable<object> GetListenersFromServiceProvider(this IServiceProvider sp, Type eventDataType)
        {
            Type listenerType = EventListenerHelper.GetEventListenerTypeByEventDataType(eventDataType);
            return sp.GetServices(listenerType);
        }
    }
}
