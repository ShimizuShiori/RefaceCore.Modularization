using RefaceCore.Modularization.Attributes;
using System;
using System.Reflection;

namespace RefaceCore.Modularization.Aop
{
    public class EarlyReturnContext : IEarylyReturnContext
    {
        public object Result { get; private set; }

        public AopAttribute AopWhichGeneratedThisResult { get; private set; }

        public object Raw { get; private set; }

        public MethodInfo Method { get; private set; }

        public object[] Arguments { get; private set; }

        public IServiceProvider ServiceProvider
        {
            get; private set;
        }

        public EarlyReturnContext(IAopContext context, AopAttribute aopWhichGeneratedThisResult, object result)
        {
            this.Raw = context.Raw;
            this.Method = context.Method;
            this.Arguments = context.Arguments;
            this.Result = result;
            this.AopWhichGeneratedThisResult = aopWhichGeneratedThisResult;
            this.ServiceProvider = context.ServiceProvider;
        }
    }
}
