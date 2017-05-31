using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnD.Equipment
{
    public class Weapon : Item, ICloneable
    {
        public Weapon()
        {
            Damage = new Damage();
        }
        public Damage Damage { get; set; }
        public string Critical { get; set; }
        public int Range { get; set; }
        public override object Clone()
        {
            Weapon result = new Weapon
            {
                Name = Name,
                Family = Family,
                Category = Category,
                Value = Value,
                Weight = Weight,
                Description = Description,
                Damage = Damage,
                Critical = Critical,
                Range = Range
            };
            return result;
        }
    }
}
