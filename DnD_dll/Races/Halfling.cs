using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Halfling : Race
    {
        private static Halfling _singleton;
        private Halfling() { }
        public static Halfling Instance
        {
            get
            {
                if (_singleton == null)
                {
					Halfling tmp = new Halfling();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override string Name
        {
            get { return "Niziołek"; }
        }
    }
}
