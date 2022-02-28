using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefaceCore.Modularization.Attributes;
using RefaceCore.Modularization.Tests;

namespace RefaceCore.Modularization.Starters.Tests
{
    [TestClass()]
    public class SimpleAppStarterTests
    {
        #region 测试类型

        public interface IA { }

        [AutoRegister]
        public class A : IA { }

        #endregion

        public IA PA { get; set; }

        [TestInitialize]
        public void OnInitialize()
        {
            IAppStarter appStarter = new UnitTestStarter(this);
            appStarter.Start<TestModule>();
        }

        [TestMethod]
        public void PAIsIA()
        {
            Assert.IsInstanceOfType(this.PA, typeof(IA));
        }
    }
}