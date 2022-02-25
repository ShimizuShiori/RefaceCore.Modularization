using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RefaceCore.Modularization
{
    public class ModuleStartingContext : IModuleStartingContext
    {
        public IEnumerable<Type> ModuleTypes { get; set; }

        public IEnumerable<Assembly> Assemblies { get; set; }

        public IEnumerable<Type> AllTypes { get; set; }

        public IServiceProvider StartingToolsContainter { get; set; }

        public IServiceCollection ServiceCollection { get; set; }

        public IConfiguration Configuration { get; set; }

        public IEnumerable<IModule> Modules { get; set; }


        public void PublishMessage(IModule sender, string messageType, object message)
        {
            foreach (IModule module in Modules)
            {
                if (module == sender)
                    continue;

                module.OnReciveMessage(sender, messageType, message);
            }
        }
    }
}
