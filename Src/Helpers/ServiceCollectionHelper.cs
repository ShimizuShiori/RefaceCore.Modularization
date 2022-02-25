using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace RefaceCore.Modularization.Helpers
{
    public static class ServiceCollectionHelper
    {
        private static readonly MethodInfo methodOfAddOption;

        static ServiceCollectionHelper()
        {
            methodOfAddOption = typeof(OptionsConfigurationServiceCollectionExtensions).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x.GetParameters().Length == 2)
                .FirstOrDefault();
        }
        public static IServiceCollection AddOption(this IServiceCollection services, Type optionType, IConfiguration configuration)
        {
            methodOfAddOption.MakeGenericMethod(optionType).Invoke(null, new object[] { services, configuration });
            return services;
        }
    }
}
