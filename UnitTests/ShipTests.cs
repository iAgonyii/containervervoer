﻿using Containervervoer.Logic;
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

        [TestMethod]
        public void PlaceAllContainersOn2x2Normal()
        {
            Ship ship = new Ship(2, 2);
            List<IContainer> containers = ContainerFactory.MakeContainers(0,20,0);
            ship.PlaceAllContainers(containers);

            // The last stack has 5 containers, meaning all other stacks on the ship have 5 too.
            Assert.AreEqual(5, ship.rows[1].stacks[1].containersInStack.Count);

        }

        [TestMethod]
        public void GetHalfWeightForFull3x2Ship()
        {
            Ship ship = new Ship(3, 2);
            List<IContainer> containers = ContainerFactory.MakeContainers(10, 10, 10);

            ship.PlaceAllContainers(containers);

            int[] halfWeights = ship.GetHalfWeights();

            Assert.AreEqual(450, halfWeights[0]);
        }

        [TestMethod]
        public void GetHalfWeightForFull4x2Ship()
        {
            Ship ship = new Ship(4, 2);
            List<IContainer> containers = ContainerFactory.MakeContainers(10, 20, 10);

            ship.PlaceAllContainers(containers);

            int[] halfWeights = ship.GetHalfWeights();

            Assert.AreEqual(601, halfWeights[0]);
        }


    }
}
