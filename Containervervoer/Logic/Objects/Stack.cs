using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public class Stack
    {
        List<IContainer> containersInStack;
        int positionInRow;
        bool valuableContainerInStack;
    }
}
