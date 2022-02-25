using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Helpers;
using RefaceCore.Modularization.Proxies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RefaceCore.Modularization.Modules
{
    /// <summary>
    /// 切面模块，添加此模块将会自动为具备 <see cref="AopAttribute"/> 的类型添加切面功能
    /// </summary>
    public class AopModule : Module
    {
        public override void OnReciveMessage(IModule sender, string messageType, object message)
        {
            if (messageType != MessageTypes.STARTED)
                return;

            IModuleStartingContext context = (IModuleStartingContext)message;

            Queue<ServiceDescriptor> deleteQ = new Queue<ServiceDescriptor>();
            Queue<ServiceDescriptor> newQ = new Queue<ServiceDescriptor>();

            foreach (var item in context.ServiceCollection)
            {
                if (item.ImplementationType == null)
                    continue;

                bool needAop;
                var aopsOnClass = item.ImplementationType.GetCustomAttributes<AopAttribute>();
                Dictionary<string, IEnumerable<AopAttribute>> aopMapping = new Dictionary<string, IEnumerable<AopAttribute>>();

                needAop = aopsOnClass.Any();

                foreach (var method in item.ImplementationType.GetMethods())
                {
                    var aopsOnMethod = method.GetCustomAttributes<AopAttribute>();
                    needAop = needAop || aopsOnMethod.Any();

                    if (needAop)
                        aopMapping[method.ToString()] = aopsOnClass.Concat(aopsOnMethod);
                }

                if (!needAop)
                    continue;

                deleteQ.Enqueue(item);
                newQ.Enqueue(CreateServiceItSelf(item));
                newQ.Enqueue(CreateServiceByProxy(item, aopMapping));
            }

            RefreshService(context, deleteQ, newQ);
        }

        private ServiceDescriptor CreateServiceByProxy(ServiceDescriptor item, Dictionary<string, IEnumerable<AopAttribute>> aopMapping)
        {
            return new ServiceDescriptor
            (
                item.ServiceType,
                sp =>
                {
                    object raw = sp.GetService(item.ImplementationType);
                    AopDispatchProxy proxy = DispatchProxyHelper.Create<AopDispatchProxy>(item.ServiceType);
                    proxy.Raw = raw;
                    proxy.AopMapping = aopMapping;
                    proxy.ServiceProvider = sp;
                    foreach (var aop in proxy.AopMapping.Values.SelectMany(x => x))
                        sp.InjectProperties(aop);
                    return proxy;
                },
                item.Lifetime
            );
        }

        private ServiceDescriptor CreateServiceItSelf(ServiceDescriptor item)
        {
            return new ServiceDescriptor
                                (
                                    item.ImplementationType,
                                    item.ImplementationType,
                                    item.Lifetime
                                );
        }

        private void RefreshService(IModuleStartingContext context, Queue<ServiceDescriptor> deleteQ, Queue<ServiceDescriptor> newQ)
        {
            while (deleteQ.Any())
                context.ServiceCollection.Remove(deleteQ.Dequeue());
            while (newQ.Any())
                context.ServiceCollection.Add(newQ.Dequeue());
        }
    }
}
