using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// 启动工具
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class StartingToolAttribute : Attribute
    {
        /// <summary>
        /// 工具类型
        /// </summary>
        public Type StartingToolType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startingToolType">工具类型</param>
        public StartingToolAttribute(Type startingToolType)
        {
            StartingToolType = startingToolType;
        }
    }
}
