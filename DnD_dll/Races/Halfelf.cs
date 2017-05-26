using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Halfelf : Race
    {
        private static readonly Halfelf _singleton = new Halfelf();
        private Halfelf() { }
        public static Halfelf Instance
        {
            get { return _singleton; }
        }
        public override string Name
        {
            get { return "Półelf"; }
        }
    }
}
