namespace RefaceCore.Modularization.Aop
{
    /// <summary>
    /// ִ�к��������
    /// </summary>
    public interface IAfterInvokeContext : IAopContext
    {
        /// <summary>
        /// ����ִ����ɺ󷵻صĽ��
        /// </summary>
        object Result { get; }
    }
}
