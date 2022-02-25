using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.StartingTools.ComponentRegistions;
using System.Collections.Generic;
using System.Linq;

namespace RefaceCore.Modularization
{
    /// <summary>
    /// 扫描模块
    /// </summary>
    public class ScannerModule : Module
    {
        public override void OnStarting(IModuleStartingContext context)
        {
            IEnumerable<IComponentRegistion> componentRegistions = context.StartingToolsContainter.GetServices<IComponentRegistion>();
            if (!componentRegistions.Any())
                return;

            foreach (var type in context.AllTypes)
            {
                foreach (var registion in componentRegistions)
                    registion.OnTypeScanned(context.ServiceCollection, type);
            }
        }
    }
}
