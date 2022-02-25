using RefaceCore.Modularization.Attributes;

namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// ���������ǰ����ʱ������������
    /// </summary>
    public interface IEarylyReturnContext : IAopContext
    {
        /// <summary>
        /// ���
        /// </summary>
        object Result { get; }

        /// <summary>
        /// �ṩ�˸ý����������ʵ��
        /// </summary>
        AopAttribute AopWhichGeneratedThisResult { get; }
    }
}
