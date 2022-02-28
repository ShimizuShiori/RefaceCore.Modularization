using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefaceCore.Modularization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RefaceCore.Modularization.Tests
{
    [TestClass()]
    public class TypeExtensionTests
    {
        #region 测试类型

        public class A1
        {
            public string Hello(string name, string lan)
            {
                return "Hello" + name;
            }
        }
        public class A2 : A1 { }
        public class A3 : A2 { }
        #endregion


        [TestMethod()]
        public void GetAllBaseTypesTest()
        {
            Type type = typeof(A3);
            IEnumerable<Type> parents = type.GetAllBaseTypes();
            Assert.AreEqual(3, parents.Count());
            Assert.AreEqual(typeof(A2), parents.ElementAt(0));
            Assert.AreEqual(typeof(A1), parents.ElementAt(1));
            Assert.AreEqual(typeof(object), parents.ElementAt(2));
        }

        [TestMethod]
        public void CallA1HelloByDelegate()
        {
            Type a1Type = typeof(A1);
            MethodInfo method = a1Type.GetMethod("Hello");
            Delegate del = method.CreateDelegate(typeof(Func<A1, string, string, string>));
            //Func<object, string, string, string> act = (Func<object, string, string, string>)del;
            A1 a1 = new A1();
            string result = (string)del.DynamicInvoke(a1, "abc", "lan");
            Assert.AreEqual("Helloabc", result);
        }
    }
}