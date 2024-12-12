using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAlib.Entity.Models._Obj
{
    public class PEJ
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }

        public PEJ( string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}
