using System;
using System.Reflection;

namespace RefaceCore.Modularization.DynamicImplements
{
    public class DynamicImplementContext : IDynamicImplementContext
    {
        public MethodInfo Method { get; private set; }

        public object[] Arguments { get; private set; }

        public object Result { get; private set; } = null;

        public IServiceProvider ServiceProvider { get; set; }

        public DynamicImplementContext(MethodInfo method, object[] arguments, IServiceProvider serviceProvider)
        {
            Method = method;
            Arguments = arguments;
            ServiceProvider = serviceProvider;
        }

        public void Return(object result)
        {
            this.Result = result;
        }
    }
}
