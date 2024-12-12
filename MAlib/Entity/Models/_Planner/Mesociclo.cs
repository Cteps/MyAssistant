using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAlib.Entity.Models._Planner
{
    public enum MesoFase
    {
        Avaliacao,
        Desenvolvimento,
        Consolidação,
    }

    public class Mesociclo
    {
        public int Id { get; set; }
        public MesoFase fase { get; set; }
        public int Numero { get; set; }
        public string Month { get; set; }
        public string Weeks { get; set; }
        public List<string> TT { get; set; }
        public string PEJ { get; set; }
        public string PEJ4 { get; set; }
        public string EsqTat { get; set; }
        public string CF { get; set; }

        public Mesociclo()
        {
            TT = new List<string>();
        }
    }
}
