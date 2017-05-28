using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Halfelf : Race
    {
        private static Halfelf _singleton;
        private Halfelf() { }
        public static Halfelf Instance
        {
            get
            {
                if (_singleton == null)
                {
					Halfelf tmp = new Halfelf();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override string Name
        {
            get { return "Półelf"; }
        }
    }
}
