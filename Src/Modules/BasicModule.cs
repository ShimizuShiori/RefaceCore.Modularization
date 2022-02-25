using RefaceCore.Modularization.Attributes;

namespace RefaceCore.Modularization.Modules
{
    /// <summary>
    /// ����ģ�飬������ɨ������Aop ������ģ��
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
