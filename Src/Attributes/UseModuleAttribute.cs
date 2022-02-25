using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 使用子模块
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class UseModuleAttribute : Attribute
    {
        /// <summary>
        /// 子模块类型
        /// </summary>
        public Type[] ModuleTypes { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="moduleTypes">子模块集合</param>
        public UseModuleAttribute(params Type[] moduleTypes)
        {
            ModuleTypes = moduleTypes;
        }
    }
}
