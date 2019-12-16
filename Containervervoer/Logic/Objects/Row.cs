using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public class Row
    {
        public int length;
        List<Stack> stacks;
        public bool isCoolableRow;

        public Row()
        {
            this.stacks = new List<Stack>();
            for(int i = 0; i < length; i++)
            {
                if (this.isCoolableRow == true)
                {
                    stacks.Add(new Stack() { isCoolableStack = true });
                }
                else
                {
                    stacks.Add(new Stack());
                }
            }
        }

        public int GetTotalRowWeight()
        {
            int weight = 0;
            foreach(Stack stack in stacks)
            {
                weight += stack.GetTotalStackWeight();
            }
            return weight;
        }
    }
}
