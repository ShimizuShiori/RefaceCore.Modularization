using RefaceCore.Modularization.Aop;
using RefaceCore.Modularization.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RefaceCore.Modularization.Proxies
{
    public class AopDispatchProxy : DispatchProxy
    {
        public Dictionary<string, IEnumerable<AopAttribute>> AopMapping { get; set; }

        public object Raw { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            AopContext aopContext = new AopContext(Raw, targetMethod, args, this.ServiceProvider);
            IEnumerable<AopAttribute> aops;
            if (!AopMapping.TryGetValue(targetMethod.ToString(), out aops))
                return targetMethod.Invoke(Raw, args);

            BeforeInvokeContext beforeInvokeContext = new BeforeInvokeContext(aopContext);
            AopAttribute earlyReturnedAop = null;

            foreach (var aop in aops)
            {
                aop.OnBeforeInvoke(beforeInvokeContext);
                if (beforeInvokeContext.IsEarlyReturn)
                {
                    earlyReturnedAop = aop;
                    break;
                }
            }

            if (beforeInvokeContext.IsEarlyReturn)
            {
                EarlyReturnContext onEarlyReturnContext = new EarlyReturnContext(aopContext, earlyReturnedAop, beforeInvokeContext.EarlyReturnResult);
                foreach (var aop in aops)
                    aop.OnEarlyReturn(onEarlyReturnContext);
                return beforeInvokeContext.EarlyReturnResult;
            }


            try
            {
                object result = targetMethod.Invoke(Raw, args);
                AfterInvokeContext afterInvokeContext = new AfterInvokeContext(aopContext, result);
                foreach (var aop in aops)
                    aop.OnAfterInvoke(afterInvokeContext);
                return result;
            }
            catch (Exception ex)
            {
                ErrorContext onErrorContext = new ErrorContext(aopContext, ex.InnerException);
                foreach (var aop in aops)
                {
                    aop.OnError(onErrorContext);
                    if (onErrorContext.NeedThrows)
                        throw onErrorContext.Error;
                }
                return null;
            }

        }
    }
}
