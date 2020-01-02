using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void test()
        {
            int half = 9 / 2;
            Assert.AreEqual(3,half);
        }
    }
}
