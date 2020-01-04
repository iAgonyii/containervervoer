using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public class Stack
    {
        int maxWeight = 150;
        public List<IContainer> containersInStack;
        int positionInRow;
        public bool valuableContainerInStack;
        public bool isCoolableStack;
        public bool isValuableStack;

        public Stack(bool coolable, bool valuable)
        {
            this.isValuableStack = valuable;
            this.isCoolableStack = coolable;
            this.containersInStack = new List<IContainer>();
        }

        public void PlaceContainer(IContainer container)
        {
            if (CanContainerBePlaced(container))
            {
                if(container is ValuableContainer)
                {
                    this.valuableContainerInStack = true;
                }
                this.containersInStack.Add(container);
                SortStack();
            }
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
            if(container is CoolableContainer)
            {
                if(isCoolableStack == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            else if(container is ValuableContainer)
            {
                if (valuableContainerInStack)
                {
                    return false;
                }
                else
                {
                    if (isCoolableStack == true)
                    {
                        return true;
                    }
                    else if (isValuableStack == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            else
            {
                return true;
            }
        }

        private bool StackWontOverload(IContainer container)
        {
            int currentWeight = GetTotalStackWeight();
            if(currentWeight + container.weight <= this.maxWeight)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void SortStack()
        {
            if (valuableContainerInStack)
            {
                ValuableContainer vContainer = (ValuableContainer)containersInStack.Find(v => v.allowTopStack == false);
                this.containersInStack.Remove(vContainer);
                this.containersInStack.Add(vContainer);
            }
        }
    }
}
