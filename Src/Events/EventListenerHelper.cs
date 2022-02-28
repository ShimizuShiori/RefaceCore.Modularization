using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RefaceCore.Modularization.Events
{
    public static class EventListenerHelper
    {
        private static Type TYPE_LISTENER = typeof(IEventListener<>);
        private const string METHOD_NAME_HANDLE_EVENT = "HandleEvent";

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

        public static IDictionary<Type, IEnumerable<object>> GetAllListeners(IServiceProvider serviceProvider, Type eventDataType)
        {
            return GetAllEventDataType(eventDataType)
                .ToMap(
                    type => type,
                    type => GetListeners(serviceProvider, type));
        }

        public static Delegate GetInvoker(Type listenerType, Type eventDataType)
        {
            MethodInfo methodInfo = listenerType.GetMethod(METHOD_NAME_HANDLE_EVENT);
            Type delegateType = typeof(Func<,,>)
                .MakeGenericType(listenerType, eventDataType, typeof(Task));
            return methodInfo.CreateDelegate(delegateType);
        }

        public static Func<Task> GetProxiedInvoker(object listener, Type eventDataType, object eventData)
        {
            Delegate invoker = GetInvoker(listener.GetType(), eventDataType);
            return new Func<Task>(() =>
            {
                return EventListenerHelper.InvokeListener(
                    invoker,
                    listener,
                    eventData
                );
            });
        }

        public static Task InvokeListener(Delegate invoker, object listener, object eventData)
        {
            return (Task)invoker.DynamicInvoke(listener, eventData);
        }
    }
}
