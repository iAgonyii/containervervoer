using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public class Stack
    {
        const int maxWeight = 150000;
        List<IContainer> containersInStack;
        int positionInRow;
        bool valuableContainerInStack;
        public bool isCoolableStack;

        public Stack()
        {
            this.containersInStack = new List<IContainer>();
        }

        public void PlaceContainer(IContainer container)
        {
            this.containersInStack.Add(container);
        }

        public int GetTotalStackWeight()
        {
            int weight = 0;
            foreach(IContainer container in containersInStack)
            {
                weight += container.weight;
            }
            return weight;
        }

        public bool CanContainerBePlaced(IContainer container)
        {
            if(StackWontOverload(container) && ContainerIsSuitable(container))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ContainerIsSuitable(IContainer container)
        {
            throw new NotImplementedException();
        }

        private bool StackWontOverload(IContainer container)
        {
            throw new NotImplementedException();
        }
    }
}
