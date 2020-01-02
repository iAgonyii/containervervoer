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
            Row row = new Row(4, false, false, 1);
            int expected = 4;
            int actual = row.stacks.Count;

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void CreatingCoolRowMakesCoolStacksForLength()
        {
            Row row = new Row(4, true, false,  1);
            List<Stack> expected = new List<Stack>()
            {
                new Stack(true, false), new Stack(true, false), new Stack(true, false), new Stack(true, false),
            };
            List<Stack> actual = row.stacks;

            Assert.AreEqual(actual[0].isCoolableStack, expected[0].isCoolableStack);
        }

        [TestMethod]
        public void CreatingValuableRowMakesValuableStacksForLength()
        {
            Row row = new Row(4, true, true, 1);
            List<Stack> expected = new List<Stack>()
            {
                new Stack(true, true), new Stack(true, true), new Stack(true, true), new Stack(true, true),
            };
            List<Stack> actual = row.stacks;

            Assert.AreEqual(actual[0].isValuableStack, expected[0].isValuableStack);
        }
    }
}
