using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnD.Equipment
{
    public class Item : ICloneable
    {
        public Item() { }
        public string Name { get; set; }
        [XmlAttribute]
        public string Family { get; set; }
        [XmlAttribute]
        public string Category { get; set; }
        [XmlAttribute]
        public decimal Value { get; set; }
        /// <summary>
        /// Waga w 0.01 kg
        /// </summary>
        [XmlAttribute]
        public decimal Weight { get; set; }
        public string Description { get; set; }
        public virtual object Clone()
        {
            Item result = new Item
            {
                Name = Name,
                Family = Family,
                Category = Category,
                Value = Value,
                Weight = Weight,
                Description = Description
            };
            return result;
        }
    }
}
