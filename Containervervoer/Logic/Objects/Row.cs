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
        public int positionOnShip;
        public List<Stack> stacks;
        public bool isCoolableRow;
        public bool isValuableRow;

        public Row(int length, bool coolable, bool valuable, int position)
        {
            this.positionOnShip = position;
            this.isValuableRow = valuable;
            this.isCoolableRow = coolable;
            this.stacks = new List<Stack>();

            // We fill the row with stacks and give them boolean values to determine if they are valuable or coolable stacks.
            for(int i = 0; i < length; i++)
            {
                if (this.isCoolableRow == true)
                {
                    stacks.Add(new Stack(true, true));
                }
                else if(this.isValuableRow == true && this.isCoolableRow == false)
                {
                    stacks.Add(new Stack(false, true));
                }
                else
                {
                    stacks.Add(new Stack(false, false));
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
