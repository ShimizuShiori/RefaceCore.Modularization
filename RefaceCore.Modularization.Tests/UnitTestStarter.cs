using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Modules;
using RefaceCore.Modularization.Starters;
using System;
using System.Reflection;

namespace RefaceCore.Modularization.Tests
{
    [UseModule(typeof(BasicModule))]
    public class TestModule : Module
    { }



    public class OnAppStartedListener : IOnStartedListener
    {
        private readonly IServiceProvider serviceProvider;

        public OnAppStartedListener(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public void OnStarted(object startArguments)
        {
            foreach (PropertyInfo prop in startArguments.GetType().GetProperties())
            {
                if (!prop.CanWrite)
                    continue;

                object service = this.serviceProvider.GetService(prop.PropertyType);
                if (service == null)
                    continue;
                prop.SetValue(startArguments, service);
            }
        }
    }

    public class UnitTestStarter : IAppStarter
    {
        private readonly object testingClass;

        public UnitTestStarter(object testingClass)
        {
            this.testingClass = testingClass;
        }

        public void Start<T>() where T : IModule
        {
            IAppStarter appStarter = new SimpleAppStarter<OnAppStartedListener>(startArguments: this.testingClass);
            appStarter.Start<T>();
        }
    }
}
