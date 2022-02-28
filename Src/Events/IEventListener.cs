using System.Threading.Tasks;

namespace RefaceCore.Modularization.Events
{
    /// <summary>
    /// 事件处理器
    /// </summary>
    /// <typeparam name="TEventData"></typeparam>
    public interface IEventListener<TEventData>
    {
        /// <summary>
        /// 处理事件的过程
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task HandleEvent(TEventData data);
    }
}
