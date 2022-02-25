using RefaceCore.Modularization.Attributes;

namespace RefaceCore.Modularization.Modules
{
    /// <summary>
    /// 基础模块，包含了扫描器，Aop 和增加模块
    /// </summary>
    [UseModule(
        typeof(ScannerModule),
        typeof(EnhancerModule),
        typeof(AopModule)
    )]
    public class BasicModule : Module
    {
    }
}
