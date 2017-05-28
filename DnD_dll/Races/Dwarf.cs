using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Dwarf : Race
    {
        private static Dwarf _singleton;
        private Dwarf() { }
        public static Dwarf Instance
        {
            get
            {
                if (_singleton == null)
                {
					Dwarf tmp = new Dwarf();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override string Name
        {
            get { return "Krasnolud"; }
        }
    }
}
