using System;
using System.Reflection;

namespace RefaceCore.Modularization.Aop
{
    public class ErrorContext : IErrorContext
    {
        public Exception Error { get; private set; }

        public object Raw { get; private set; }

        public MethodInfo Method { get; private set; }

        public object[] Arguments { get; private set; }

        public bool NeedThrows { get; private set; } = false;

        public IServiceProvider ServiceProvider
        {
            get; private set;
        }

        public ErrorContext(IAopContext context, Exception error)
        {
            this.Raw = context.Raw;
            this.Method = context.Method;
            this.Arguments = context.Arguments;
            this.Error = error;
            this.ServiceProvider = context.ServiceProvider;
        }

        public void Throws()
        {
            this.NeedThrows = true;
        }
    }
}
