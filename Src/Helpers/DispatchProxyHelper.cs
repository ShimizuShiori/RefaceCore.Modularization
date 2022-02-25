using System;
using System.Reflection;

namespace RefaceCore.Modularization.Helpers
{
    public static class DispatchProxyHelper
    {
        public static T Create<T>(Type serviceType)
            where T : DispatchProxy
        {
            MethodInfo method = typeof(DispatchProxy).GetMethod("Create");
            return (T)method.MakeGenericMethod(serviceType, typeof(T))
                .Invoke(null, null);
        }
    }
}
