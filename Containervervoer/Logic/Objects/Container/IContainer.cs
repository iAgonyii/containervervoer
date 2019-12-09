using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public interface IContainer
    {
        bool allowTopStack { get; set; }
        int maxTopStackWeight { get; set; }
        int maxWeight { get; set; }
        List<Row> allowedRows { get; set; }
    }
}
