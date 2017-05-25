using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnD.Equipment
{
    public class Item
    {
        protected string _name;
        protected string _family;
        protected string _category;
        protected int _value;
        protected string _description;
        public Item()
        {
            _name = string.Empty;
            _category = string.Empty;
            _family = string.Empty;
            _value = 0;
        }
        public Item(string name, int value = 0, string family = null, string category = null)
        {
            _name = name;
            _category = category;
            _family = family;
            _value = value;
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [XmlAttribute]
        public string Family
        {
            get { return _family; }
            set { _family = value; }
        }
        [XmlAttribute]
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        [XmlAttribute]
        public int ValueInCopper
        {
            get { return _value; }
            set { _value = value; }
        }
        /// <summary>
        /// Waga w 0.01 kg
        /// </summary>
        [XmlAttribute]
        public int Weight { get; set; }
    }
}
