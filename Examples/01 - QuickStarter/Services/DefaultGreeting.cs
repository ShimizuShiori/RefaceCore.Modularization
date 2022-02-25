using RefaceCore.Modularization.Attributes;
using System;

namespace QuickStart.Services
{
    [RegisterAs(typeof(IGreeting))]
    public class DefaultGreeting : IGreeting
    {
        public void SayHello()
        {
            Console.WriteLine("HelloWorld!");
        }
    }
}
