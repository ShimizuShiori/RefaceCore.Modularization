using System;
using System.Reflection;

namespace RefaceCore.Modularization.Aop
{
    public class BeforeInvokeContext : IBeforeInvokeContext
    {
        public object Raw { get; private set; }

        public MethodInfo Method { get; private set; }

        public object[] Arguments { get; private set; }

        public bool IsEarlyReturn { get; private set; } = false;
        public object EarlyReturnResult { get; private set; }

        public IServiceProvider ServiceProvider { get; private set; }

        public BeforeInvokeContext(IAopContext context)
        {
            this.Raw = context.Raw;
            this.Method = context.Method;
            this.Arguments = context.Arguments;
            this.ServiceProvider = context.ServiceProvider;
        }

        public void ReturnValue(object result)
        {
            IsEarlyReturn = true;
            EarlyReturnResult = result;
        }
    }
}
