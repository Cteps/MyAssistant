using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAlib.ComplexModels
{
    public enum GeralType
    {
        OF_PEJ1 = 0,
        DF_PEJ1 = 1,
        OF_PEJ2 = 2,
        DF_PEJ2 = 3,
        OF_PEJ3 = 4,
        DF_PEJ3 = 5,
        OF_PEJ4 = 6,
        DF_PEJ4 = 7,
        EsqTatico,
        TI,
        Ludico,
        CF
    }

    public class CheckList
    {
        public string Value { get; set; }
        public string Description { get; set; }

        public CheckList(string description, string value)
        {
            Value = value;
            Description = description;
        }
        public CheckList(string nameDesc)
        {
            Description = nameDesc;
        }

        public class CheckListTyped : CheckList
        {
            public GeralType GeralType { get; set; }
            public CheckListTyped(GeralType geraltype, string nameDesc) : base(nameDesc)
            {
                GeralType = geraltype;
            }
        }
    }
}
