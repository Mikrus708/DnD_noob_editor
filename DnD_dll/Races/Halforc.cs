using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Halforc : Race
    {
        private static Halforc _singleton = new Halforc();
        private Halforc() { }
        public static Halforc Instance
        {
            get
            {
                if (_singleton == null)
                {
					Halforc tmp = new Halforc();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override string Name
        {
            get { return "Półork"; }
        }
    }
}
