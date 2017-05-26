using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Halforc : Race
    {
        private static readonly Halforc _singleton = new Halforc();
        private Halforc() { }
        public static Halforc Instance
        {
            get { return _singleton; }
        }
        public override string Name
        {
            get { return "Człowiek"; }
        }
    }
}
