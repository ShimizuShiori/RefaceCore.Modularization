using System;
using System.Reflection;

namespace RefaceCore.Modularization.Aop
{
    public class AopContext : IAopContext
    {
        public object Raw { get; private set; }

        public MethodInfo Method { get; private set; }

        public object[] Arguments { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public AopContext(object raw, MethodInfo method, object[] arguments, IServiceProvider serviceProvider)
        {
            Raw = raw;
            Method = method;
            Arguments = arguments;
            ServiceProvider = serviceProvider;
        }
    }
}
