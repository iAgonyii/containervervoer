using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Containervervoer.Logic.Objects;
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
        public void TwoValuableContainersInStackNotPossible()
        {
            Stack stack = new Stack(true, true);
            IContainer container1 = new ValuableContainer();
            IContainer container2 = new ValuableContainer();
            stack.PlaceContainer(container1);

            Assert.IsFalse(stack.CanContainerBePlaced(container2));
        }

        [TestMethod]
        public void CoolableContainerNotSuitable()
        {
            Stack stack = new Stack(false, false);
            Assert.IsFalse(stack.CanContainerBePlaced(new CoolableContainer()));
        }

        [TestMethod]
        public void ValuableContainerNotSuitable()
        {
            Stack stack = new Stack(false, false);
            Assert.IsFalse(stack.CanContainerBePlaced(new ValuableContainer()));
        }

        [TestMethod]
        public void StackWeightOverload()
        {
            Stack stack = new Stack(false, false);
            IContainer container6 = new NormalContainer();

            stack.containersInStack = new List<IContainer>()
            {
                new NormalContainer() { weight = 26 },
                new NormalContainer() { weight = 26 },
                new NormalContainer() { weight = 26 },
                new NormalContainer() { weight = 26 },
                new NormalContainer() { weight = 26 },
            };

            Assert.IsFalse(stack.CanContainerBePlaced(container6));
        }

        [TestMethod]
        public void ValuableContainerOnTop()
        {
            Stack stack = new Stack(true, true);
            IContainer container1 = new ValuableContainer();
            IContainer container2 = new CoolableContainer();
            IContainer container3 = new NormalContainer();
            stack.PlaceContainer(container2);
            stack.PlaceContainer(container1);
            stack.PlaceContainer(container3);

            Assert.AreEqual(container1, stack.containersInStack[2]);
        }
    }
}
