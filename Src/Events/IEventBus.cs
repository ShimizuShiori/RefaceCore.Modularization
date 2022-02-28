using System.Threading.Tasks;

namespace RefaceCore.Modularization.Events
{
    /// <summary>
    /// 事件总线，用于向系统发出事件通知
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="eventData">事件数据</param>
        Task Publish(object eventData);
    }
}
