using Microsoft.Extensions.DependencyInjection;
using QuickStart;
using QuickStart.Services;
using RefaceCore.Modularization;
using System;

namespace QuickStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider sp = ModuleStarter.Start<QuickStartModule>();

            IGreeting greeting = sp.GetService<IGreeting>();
            greeting.SayHello();

            Console.ReadLine();
        }
    }
}
