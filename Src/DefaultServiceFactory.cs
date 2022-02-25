using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using System;

namespace RefaceCore.Modularization
{
    [RegisterAs(typeof(IServiceFactory<>))]
    public class DefaultServiceFactory<T> : IServiceFactory<T>
    {
        private readonly IServiceProvider serviceProvider;

        public DefaultServiceFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Create()
        {
            return this.serviceProvider.GetService<T>();
        }
    }
}
