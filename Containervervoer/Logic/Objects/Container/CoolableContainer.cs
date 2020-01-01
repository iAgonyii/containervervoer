using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    class CoolableContainer : IContainer
    {
        int _weight = 4;
        public bool allowTopStack { get { return true; } }
        public int maxTopStackWeight { get { return 120; } }
        public int weight { get { return this._weight; } set { this._weight += value; } }
        public int maxWeight { get { return 30; } }
        public List<Row> allowedRows { get; set; }
    }
}
