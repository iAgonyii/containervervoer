using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public class Ship
    {
        public List<Row> rows;
        public int maxWeight;
        public int minWeight;
        int totalContainerweight;

        public Ship(int length, int width)
        {
            this.rows = new List<Row>();
            this.maxWeight = (length * width) * 150;
            this.minWeight = maxWeight / 2;
            for (int i = 0; i < length; i++)
            {
                if (i == 0)
                {
                    rows.Add(new Row(width, true, true, i));
                }
                else if (i == length - 1)
                {
                    rows.Add(new Row(width, false, true, i));
                }
                else
                {
                    rows.Add(new Row(width, false, false, i));
                }

            }
        }

        public void PlaceAllContainers(List<IContainer> containers)
        {
            if (TotalContainerWeightPasses(containers))
            {
                foreach(IContainer container in containers)
                {
                    GetAvailableStack(container).PlaceContainer(container);
                }
            }
        }

        private bool TotalContainerWeightPasses(List<IContainer> containers)
        {
            int weight = 0;
            foreach (IContainer container in containers)
            {
                weight += container.weight;
            }
            if (weight >= minWeight && weight <= maxWeight)
            {
                return true;
            }
            else
            {
                throw new Exception("The total weight of containers is not within requirement bounds");
            }
        }

        private Stack GetAvailableStack(IContainer container)
        {
            foreach (Row row in rows)
            {
                foreach (Stack stack in row.stacks)
                {
                    if (stack.CanContainerBePlaced(container))
                    {
                        return stack;
                    }
                }

            }

            // What should we return if there is no spot available on the ship?
            return null;
        }

        public int GetTotalWeight()
        {
            int weight = 0;
            foreach (Row row in rows)
            {
                weight += row.GetTotalRowWeight();
            }
            return weight;
        }

        public int[] GetHalfWeights()
        {
            int frontWeight = 0;
            int backWeight = 0;

            double rowsDivBy2 = rows.Count / 2.0;
            if(rowsDivBy2 % 1 == 0)
            {
                for(int i = 0; i < rowsDivBy2; i++)
                {
                    frontWeight += rows[i].GetTotalRowWeight();
                    backWeight += rows[i + (int)rowsDivBy2].GetTotalRowWeight();
                }
            }
            else
            {
                int middlerow = rows.Count / 2;
                int halfWeightOfMiddleRow = rows[middlerow].GetTotalRowWeight() / 2;

                for(int i = 0; i < rows.Count; i++)
                {
                    if (i == middlerow)
                    {
                        frontWeight += halfWeightOfMiddleRow;
                        backWeight += halfWeightOfMiddleRow;
                    }
                    else if (i < middlerow)
                    {
                        frontWeight += rows[i].GetTotalRowWeight();
                    }
                    else
                    {
                        backWeight += rows[i].GetTotalRowWeight();
                    }
                }
            }

            int[] weights = { frontWeight, backWeight };
            return weights;
        }
    }
}
