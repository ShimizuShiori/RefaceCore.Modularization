using Microsoft.Extensions.DependencyInjection;
using RefaceCore.Modularization.Attributes;

namespace RefaceCore.Modularization.StartingTools.Enhancers
{
    /// <summary>
    /// ģ����ǿ������Ҫͨ�� <see cref="StartingToolAttribute"/> ����������
    /// </summary>
    public interface IModuleEnhancer
    {
        /// <summary>
        /// ������ģ�鶼��ʼ����ɺ󣬿����������е�ģ��
        /// </summary>
        /// <param name="services"></param>
        /// <param name="module"></param>
        void Enhance(IServiceCollection services, IModule module);
    }
}
