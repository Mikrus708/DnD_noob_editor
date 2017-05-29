using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Gnom : Race
    {
        private static Gnom _singleton;
        private Gnom() { }
        public static Gnom Instance
        {
            get
            {
                if (_singleton == null)
                {
					Gnom tmp = new Gnom();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override string Name
        {
            get { return "Gnom"; }
        }
    }
}
