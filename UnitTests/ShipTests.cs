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
    public class ShipTests
    {
        [TestMethod]
        public void CreatingShipMakesRows()
        {
            Ship ship = new Ship(10, 3);
            int expected = 10;
            int actual = ship.rows.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreatingShipFirstRowIsCoolable()
        {
            Ship ship = new Ship(10, 3);
            bool expected = true;
            bool actual = ship.rows[0].isCoolableRow;

            Assert.AreEqual(expected, actual);
        }


    }
}
