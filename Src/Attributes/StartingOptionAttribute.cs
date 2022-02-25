using System;

namespace RefaceCore.Modularization.Attributes
{
    /// <summary>
    /// ���������е�����ѡ��
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class StartingOptionAttribute : Attribute
    {
        /// <summary>
        /// �ڵ�
        /// </summary>
        public string Section { get; }

        public StartingOptionAttribute(string section)
        {
            Section = section;
        }
    }
}
