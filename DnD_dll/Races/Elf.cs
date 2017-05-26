using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Elf : Race
    {
        private static readonly Elf _singleton = new Elf();
        private Elf() { }
        public static Elf Instance
        {
            get { return _singleton; }
        }
        public override string Name
        {
            get { return "Elf"; }
        }
    }
}
