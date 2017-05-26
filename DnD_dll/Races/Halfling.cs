using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Halfling : Race
    {
        private static readonly Halfling _singleton = new Halfling();
        private Halfling() { }
        public static Halfling Instance
        {
            get { return _singleton; }
        }
        public override string Name
        {
            get { return "Niziołek"; }
        }
    }
}
