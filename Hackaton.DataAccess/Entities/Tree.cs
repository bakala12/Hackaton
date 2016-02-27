using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackaton.DataAccess.Entities
{
    public class Tree : Entity
    {
        public double CoordX { get; set; }
        public double CoordY { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        [Description("Słowna nazwa miejsca")]
        public string Location { get; set; }
        public string Type { get; set; }
    }
}
