namespace RefaceCore.Modularization
{
    public abstract class Module : IModule
    {
        public virtual void OnReciveMessage(IModule sender, string messageType, object message)
        {
        }

        public virtual void OnStarting(IModuleStartingContext context)
        {
        }
    }
}
