namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// ִ��ǰ������������
    /// </summary>
    public interface IBeforeInvokeContext : IAopContext
    {
        /// <summary>
        /// ͨ���÷�����������ԭ��Ҫִ�еĹ��̣�ֱ�ӷ��ؽ��
        /// </summary>
        /// <param name="result"></param>
        void ReturnValue(object result);
    }
}
