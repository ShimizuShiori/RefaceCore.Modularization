using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RefaceCore.Modularization.Helpers
{
    public static class ModuleHelper
    {
        public static IEnumerable<Assembly> GetAssemblies(IEnumerable<Type> moduleTypes)
        {
            HashSet<Assembly> result = new HashSet<Assembly>();
            foreach (var type in moduleTypes)
                result.Add(type.Assembly);

            return result;
        }

        public static IEnumerable<Type> GetModuleTypes(Type type)
        {
            ICollection<Type> result = new List<Type>();
            HashSet<Type> analysedTypes = new HashSet<Type>();
            Queue<Type> analysingTypes = new Queue<Type>();

            analysingTypes.Enqueue(type);

            while (analysingTypes.Count > 0)
            {
                Type analysingType = analysingTypes.Dequeue();

                if (analysedTypes.Contains(analysingType))
                    continue;

                result.Add(analysingType);
                analysedTypes.Add(analysingType);

                IEnumerable<UseModuleAttribute> attributes = analysingType.GetCustomAttributes<UseModuleAttribute>();
                if (!attributes.Any())
                    continue;

                foreach (UseModuleAttribute attribute in attributes)
                {
                    foreach (Type moduleType in attribute.ModuleTypes)
                    {
                        if (analysedTypes.Contains(moduleType))
                            continue;

                        analysingTypes.Enqueue(moduleType);
                    }
                }
            }

            return result;
        }

        public static IEnumerable<IModule> GetModuleInstances(IEnumerable<Type> moduleTypes)
        {
            return moduleTypes
                    .Select(x => Activator.CreateInstance(x))
                    .Cast<IModule>();
        }

        public static IEnumerable<Type> GetAllTypesInEveryAssembly(IEnumerable<Assembly> assemblies)
        {
            return assemblies.SelectMany(x => x.GetTypes());
        }

        public static IEnumerable<Tuple<Type, IEnumerable<StartingToolAttribute>>> FindStartingToolTypes(IEnumerable<Type> types)
        {
            return types
                .Select(x => new Tuple<Type, IEnumerable<StartingToolAttribute>>(x, x.GetCustomAttributes<StartingToolAttribute>()))
                .Where(x => x.Item2.Any());
        }

        public static IEnumerable<Tuple<Type, string>> FindStartingOptions(IEnumerable<Type> types)
        {
            return types
                .Select(x => new Tuple<Type, StartingOptionAttribute>(x, x.GetCustomAttribute<StartingOptionAttribute>()))
                .Where(x => x.Item2 != null)
                .Select(x => new Tuple<Type, string>(x.Item1, x.Item2.Section));
        }

        public static void Start(IServiceCollection services, IConfiguration configuration, Type startModuleType)
        {
            IEnumerable<Type> moduleTypes = ModuleHelper.GetModuleTypes(startModuleType);
            IEnumerable<Assembly> assemblies = ModuleHelper.GetAssemblies(moduleTypes);
            IEnumerable<IModule> modules = ModuleHelper.GetModuleInstances(moduleTypes);
            IEnumerable<Type> allTypes = ModuleHelper.GetAllTypesInEveryAssembly(assemblies);

            IEnumerable<Tuple<Type, IEnumerable<StartingToolAttribute>>> startingToolInfos = ModuleHelper.FindStartingToolTypes(allTypes);
            IEnumerable<Tuple<Type, string>> startingOptions = ModuleHelper.FindStartingOptions(allTypes);

            IServiceCollection startingToolsCollection = new ServiceCollection();
            startingToolsCollection.AddSingleton(configuration);
            foreach (var tuple in startingToolInfos)
            {
                foreach (var startingToolAttribute in tuple.Item2)
                {
                    startingToolsCollection.AddSingleton(startingToolAttribute.StartingToolType, tuple.Item1);
                }
            }

            foreach (var tuple in startingOptions)
                ServiceCollectionHelper.AddOption(startingToolsCollection, tuple.Item1, configuration.GetSection(tuple.Item2));

            IServiceProvider startingToolsContainer = startingToolsCollection.BuildServiceProvider();

            IModuleStartingContext startingContext = new ModuleStartingContext()
            {
                ServiceCollection = services,
                AllTypes = allTypes,
                Assemblies = assemblies,
                ModuleTypes = moduleTypes,
                StartingToolsContainter = startingToolsContainer,
                Configuration = configuration,
                Modules = modules
            };

            foreach (IModule module in modules)
                module.OnStarting(startingContext);

            startingContext.PublishMessage(null, MessageTypes.STARTED, startingContext);
        }
    }
}
