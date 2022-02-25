using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.StartingTools.Enhancers;
using System.Collections.Generic;
using System.Linq;

namespace RefaceCore.Modularization.Modules
{
    /// <summary>
    /// 增强模块
    /// </summary>
    public class EnhancerModule : Module
    {
        public override void OnStarting(IModuleStartingContext context)
        {
            IEnumerable<IModuleEnhancer> moduleEnhancers = context.StartingToolsContainter.GetServices<IModuleEnhancer>();

            if (!moduleEnhancers.Any())
                return;

            foreach (IModule module in context.Modules)
                foreach (IModuleEnhancer enhancer in moduleEnhancers)
                    enhancer.Enhance(context.ServiceCollection, module);
        }
    }
}
