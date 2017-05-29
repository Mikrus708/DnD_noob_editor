using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Equipment
{
    public class Armor : Item
    {
        public Armor() : base() { }
        public Armor(string name, int value = 0, string family = null, string category = null) : base(name, value, family, category) { }
        public int Defense { get; set; }
        public decimal FailureSpell { get; set; }
    }
}
