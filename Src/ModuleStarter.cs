//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using RefaceCore.Modularization.Attributes;
//using RefaceCore.Modularization.Helpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace RefaceCore.Modularization
//{
//    /// <summary>
//    /// 模块启动器
//    /// </summary>
//    public class ModuleStarter
//    {
//        /// <summary>
//        /// 启动一个模块，以及它所使用的所有模块
//        /// </summary>
//        /// <typeparam name="T">模块</typeparam>
//        /// <param name="services">IOC 注册容器</param>
//        /// <param name="configuration">配置信息</param>
//        public void Start<T>(IServiceCollection services, IConfiguration configuration)
//            where T : IModule
//        {

//            IEnumerable<Type> moduleTypes = GetModuleTypes(typeof(T));
//            IEnumerable<Assembly> assemblies = GetAssemblies(moduleTypes);
//            IEnumerable<IModule> modules = GetModuleInstances(moduleTypes);
//            IEnumerable<Type> allTypes = GetAllTypesInEveryAssembly(assemblies);

//            IEnumerable<Tuple<Type, IEnumerable<StartingToolAttribute>>> startingToolInfos = FindStartingToolTypes(allTypes);
//            IEnumerable<Tuple<Type, string>> startingOptions = FindStartingOptions(allTypes);

//            IServiceCollection startingToolsCollection = new ServiceCollection();
//            startingToolsCollection.AddSingleton(configuration);
//            foreach (var tuple in startingToolInfos)
//            {
//                foreach (var startingToolAttribute in tuple.Item2)
//                {
//                    startingToolsCollection.AddSingleton(startingToolAttribute.StartingToolType, tuple.Item1);
//                }
//            }

//            foreach (var tuple in startingOptions)
//                ServiceCollectionHelper.AddOption(startingToolsCollection, tuple.Item1, configuration.GetSection(tuple.Item2));

//            IServiceProvider startingToolsContainer = startingToolsCollection.BuildServiceProvider();

//            IModuleStartingContext startingContext = new ModuleStartingContext()
//            {
//                ServiceCollection = services,
//                AllTypes = allTypes,
//                Assemblies = assemblies,
//                ModuleTypes = moduleTypes,
//                StartingToolsContainter = startingToolsContainer,
//                Configuration = configuration,
//                Modules = modules
//            };

//            foreach (IModule module in modules)
//                module.OnStarting(startingContext);

//            startingContext.PublishMessage(null, MessageTypes.STARTED, startingContext);
//        }

//        /// <summary>
//        /// 不借助外部的 <see cref="IServiceCollection"/> 启动所有模块
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="configuration"></param>
//        /// <returns><see cref="IServiceProvider"/> 的实例</returns>
//        public IServiceProvider Start<T>(IConfiguration configuration)
//            where T : IModule
//        {
//            IServiceCollection services = new ServiceCollection();
//            Start<T>(services, configuration);
//            return services.BuildServiceProvider();
//        }

//        public IServiceProvider Start<T>()
//            where T : IModule
//        {
//            return Start<T>(new ConfigurationBuilder().Build());
//        }

//    }
//}
