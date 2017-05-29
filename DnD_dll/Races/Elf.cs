using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Elf : Race
    {
        private static Elf _singleton;
        private Elf() { }
        public static Elf Instance
        {
            get
            {
                if (_singleton == null)
                {
					Elf tmp = new Elf();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override string Name
        {
            get { return "Elf"; }
        }
    }
}
