using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Dwarf : Race
    {
        private static readonly Dwarf _singleton = new Dwarf();
        private Dwarf() { }
        public static Dwarf Instance
        {
            get { return _singleton; }
        }
        public override string Name
        {
            get { return "Krasnolud"; }
        }
    }
}
