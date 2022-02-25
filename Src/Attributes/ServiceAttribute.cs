using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 声明一个服务类型
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ServiceAttribute : Attribute
    {
    }
}
