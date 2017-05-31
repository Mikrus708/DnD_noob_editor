using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Equipment
{
    public class Armor : Item, ICloneable
    {
        public Armor() : base() { }
        public int Defense { get; set; }
        public decimal FailureSpell { get; set; }
        public override object Clone()
        {
            Armor result = new Armor
            {
                Name = Name,
                Family = Family,
                Category = Category,
                Value = Value,
                Weight = Weight,
                Description = Description,
                Defense = Defense,
                FailureSpell = FailureSpell
            };
            return result;
        }
    }
}
