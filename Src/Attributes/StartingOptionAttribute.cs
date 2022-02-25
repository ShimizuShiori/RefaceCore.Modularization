using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 启动过程中的配置选项
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class StartingOptionAttribute : Attribute
    {
        /// <summary>
        /// 节点
        /// </summary>
        public string Section { get; }

        public StartingOptionAttribute(string section)
        {
            Section = section;
        }
    }
}
