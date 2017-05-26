using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Gnom : Race
    {
        private static readonly Gnom _singleton = new Gnom();
        private Gnom() { }
        public static Gnom Instance
        {
            get { return _singleton; }
        }
        public override string Name
        {
            get { return "Gnom"; }
        }
    }
}
