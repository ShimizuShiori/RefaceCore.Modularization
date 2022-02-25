using System;
using System.Reflection;

namespace RefaceCore.Modularization.Aop
{
    public class AfterInvokeContext : IAfterInvokeContext
    {
        public object Result { get; private set; }

        public object Raw { get; private set; }

        public MethodInfo Method { get; private set; }

        public object[] Arguments { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public AfterInvokeContext(IAopContext context, object result)
        {
            this.Raw = context.Raw;
            this.Method = context.Method;
            this.Arguments = context.Arguments;
            this.Result = result;
            this.ServiceProvider = context.ServiceProvider;
        }
    }
}
