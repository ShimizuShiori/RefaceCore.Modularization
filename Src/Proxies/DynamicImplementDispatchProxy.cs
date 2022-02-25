using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.DynamicImplements;
using System;
using System.Reflection;

namespace RefaceCore.Modularization.Proxies
{
    public class DynamicImplementDispatchProxy : DispatchProxy
    {
        public DynamicImplementAttribute DynamicImplementAttribute { get; set; }

        public IServiceProvider ServiceProvider { get; set; }
        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            DynamicImplementContext context = new DynamicImplementContext(targetMethod, args, this.ServiceProvider);
            DynamicImplementAttribute.OnInvoke(context);
            return context.Result;
        }
    }
}
