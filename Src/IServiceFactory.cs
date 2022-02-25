namespace RefaceCore.Modularization
{
    /// <summary>
    /// 服务工厂类，每次都会创建新的服务实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IServiceFactory<T>
    {
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <returns></returns>
        T Create();
    }
}
