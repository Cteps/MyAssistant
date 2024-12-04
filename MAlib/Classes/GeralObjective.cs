using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAlib.Classes
{
    public class GeralObjective
    {
        public string? Name { get; set; }
        public List<SpecificObjective>? specificObjectives { get; set; }
    }
}
