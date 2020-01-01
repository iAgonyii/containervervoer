using Containervervoer.Logic.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class RowTests
    {
        [TestMethod]
        public void CreatingRowMakesStacksForLength()
        {
            Row row = new Row(4, false);
            int expected = 4;
            int actual = row.stacks.Count;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CreatingCoolRowMakesCoolStacksForLength()
        {
            Row row = new Row(4, true);
            List<Stack> expected = new List<Stack>()
            {
                new Stack(true), new Stack(true), new Stack(true), new Stack(true),
            };
            List<Stack> actual = row.stacks;

            Assert.AreEqual(actual[0].isCoolableStack, expected[0].isCoolableStack);
        }
    }
}
