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
            for(int i = 0; i < length; i++)
            {
                if(i == 0)
                {
                    rows.Add(new Row(width, true, true, i));
                }
                else if(i == length - 1)
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
            if(TotalContainerWeightPasses(containers))
            {

            }
        }

        private bool TotalContainerWeightPasses(List<IContainer> containers)
        {
            int weight = 0;
            foreach(IContainer container in containers)
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

        public int GetTotalWeight()
        {
            int weight = 0;
            foreach(Row row in rows)
            {
                weight += row.GetTotalRowWeight();
            }
            return weight;
        }
    }
}
