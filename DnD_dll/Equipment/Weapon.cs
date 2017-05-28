using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnD.Equipment
{
    public class Weapon : Item
    {
        public Weapon() : base() { }
        public Weapon(string name, int value, string family = null, string category = null) : base(name, value, family, category) { }
        public Damage Damage { get; set; }
        public string Critical { get; set; }
        public int Range { get; set; }
    }
}
