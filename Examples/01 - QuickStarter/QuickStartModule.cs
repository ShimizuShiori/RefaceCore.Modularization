using RefaceCore.Modularization;
using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Modules;

namespace QuickStart
{
    [UseModule(
        typeof(BasicModule)
    )]
    public class QuickStartModule : Module
    {
    }
}
