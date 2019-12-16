using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containervervoer.Logic.Objects
{
    public interface IContainer
    {
        bool allowTopStack { get; }
        int maxTopStackWeight { get; }
        int weight { get; set; }
        int maxWeight { get; }
        List<Row> allowedRows { get; set; }
    }
}
