using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAlib.Entity.Models._Planner
{
    public class Macrociclo
    {
        public List<Mesociclo> mesos { get; set; }
        public Macrociclo()
        {
            mesos = new List<Mesociclo>();
        }
    }
}
