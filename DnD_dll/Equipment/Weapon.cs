using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Equipment
{
    public class Weapon : Item
    {
        public Weapon(string name, int value, string family = null, string category = null) : base(name, value, family, category)
        {
        }
        public string Critical { get; set; }
        public int Range { get; set; }
        public Damage Damage { get; set; }
    }
}
