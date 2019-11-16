using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAMTest
{
    /// <summary>
    /// Example test class
    /// When using mstest to test, all TestMethod in this class will automatically running
    /// </summary>
    [TestClass]
    public class ExampleTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expect = 3;
            int actual = 4;

            Assert.AreEqual(expect, actual);
        }
    }
}
