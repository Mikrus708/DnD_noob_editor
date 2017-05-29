using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Human : Race
    {
        private static Human _singleton;
        private Human() { }
        public static Human Instance
        {
            get
            {
                if (_singleton == null)
                {
					Human tmp = new Human();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override string Name
        {
            get { return "Człowiek"; }
        }
    }
}
