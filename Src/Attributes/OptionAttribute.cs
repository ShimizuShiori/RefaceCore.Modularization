using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 为类型添加该特征，会自动注册成为 Options
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class OptionAttribute : Attribute
    {
        /// <summary>
        /// 配置文件中的 Section 路径
        /// </summary>
        public string Section { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="section">配置文件中的 Section 路径</param>
        public OptionAttribute(string section)
        {
            Section = section;
        }
    }
}
