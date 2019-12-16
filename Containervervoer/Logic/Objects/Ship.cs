using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public class Ship
    {
        List<Row> rows;
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
                    rows.Add(new Row() { length = width });
                }
                else
                {
                    rows.Add(new Row() { length = width, isCoolableRow = true });
                }

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
