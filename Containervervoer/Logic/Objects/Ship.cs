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

            // For the length we create rows. The row's length is determined by the width of the ship.
            // The first row is always coolable and valuable. The last row is always valuable.
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
            // Check if the total weight of the containers is within the required bounds
            if (TotalContainerWeightPasses(containers))
            {
                // For every container we are going to find an available stack. Based on balance, availability and container type.
                // If there is no stack available we ignore the container and display it in the console.
                foreach (IContainer container in containers)
                {
                    Stack stack = GetAvailableStack(container);
                    if (stack == null)
                    {
                        Console.WriteLine("Ignored a " + container.GetType().ToString() + " | Weight: " + container.weight + " | No spot available");
                    }
                    else
                    {
                        stack.PlaceContainer(container);
                    }
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
            // If the container is coolable we ignore balancing because they are always on the front row no matter what.
            // If the ship is currently in balance we just find a spot for the container in the front part.
            if (container is CoolableContainer || HalfWeightsWithinBounds(GetHalfWeights()))
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
            }
            // If the ship is currently out of balance
            else
            {
                //Search for a stack on the other half of the ship.
                for (int i = rows.Count - 1; i >= 0; i--)
                {
                    for (int j = rows[i].stacks.Count - 1; j >= 0; j--)
                    {
                        if (rows[i].stacks[j].CanContainerBePlaced(container))
                        {
                            return rows[i].stacks[j];
                        }
                    }
                }
            }

            // If there is no spot available on the ship we return null. The application will display that we ignored the container because there was no spot.
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

        // This method returns true if the weight differences are within the required bounds.
        // It takes the calculated weights of each half as parameter
        public bool HalfWeightsWithinBounds(int[] halfweights)
        {
            int frontWeight = halfweights[0];
            int backWeight = halfweights[1];

            double frontPercentage = (double)frontWeight / (double)GetTotalWeight() * 100.0;
            double backPercentage = (double)backWeight / (double)GetTotalWeight() * 100.0;

            if (frontPercentage > 60 || frontPercentage < 40 || backPercentage > 60 || backPercentage < 40)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int[] GetHalfWeights()
        {
            int frontWeight = 0;
            int backWeight = 0;

            double rowsDivBy2 = rows.Count / 2.0;
            // If the amount of rows is an even number we can easily get the weights of each half.
            if (rowsDivBy2 % 1 == 0)
            {
                for (int i = 0; i < rowsDivBy2; i++)
                {
                    frontWeight += rows[i].GetTotalRowWeight();
                    backWeight += rows[i + (int)rowsDivBy2].GetTotalRowWeight();
                }
            }

            // If the amount of rows is not an even number we split the total weight of the middle row and give each half of the ship a half of the weight of the middle row.
            else
            {
                int middlerow = rows.Count / 2;
                int halfWeightOfMiddleRow = rows[middlerow].GetTotalRowWeight() / 2;

                for (int i = 0; i < rows.Count; i++)
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

            // Return the weights so we can use them in our method that checks if the ship is in balance.
            int[] weights = { frontWeight, backWeight };
            return weights;
        }
    }
}
