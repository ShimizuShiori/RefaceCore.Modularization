using QuickStart;
using QuickStart.Services;
using RefaceCore.Modularization.Starters;

namespace QuickStarter
{


    public class OnStarted : IOnStartedListener
    {
        private readonly IGreeting greeting;

        public OnStarted(IGreeting greeting)
        {
            this.greeting = greeting;
        }

        void IOnStartedListener.OnStarted(object startArguments)
        {
            this.greeting.SayHello();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAppStarter starter = new SimpleAppStarter<OnStarted>(startArguments: args);
            starter.Start<QuickStartModule>();
        }
    }
}
