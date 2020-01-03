using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public class ValuableContainer: IContainer
    {
        int _weight = 4;
        public bool allowTopStack { get { return false; } }
        public int maxTopStackWeight { get { return 0; } }
        public int weight { get { return this._weight; } set { this._weight += value; } }
        public int maxWeight { get { return 30; } }
        public List<Row> allowedRows { get; set; }
    }
}
