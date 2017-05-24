using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Equipment
{
    public class Item
    {
        protected string _name;
        protected string _family;
        protected string _category;
        protected int _value;
        protected string _comment;
        public Item(string name, int value = 0, string family = null, string category = null)
        {
            _name = name;
            _category = category;
            _family = family;
            _value = value;
        }
        public string Comment
        {
            get { return _comment; }
        }
        /// <summary>
        /// Waga w 0.01 kg
        /// </summary>
        public int Weight { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Family
        {
            get { return _family; }
            set { _family = value; }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        public int ValueInCopper
        {
            get { return _value; }
            set { _value = value; }
        }
        public int SaleValueInCopper
        {
            get { return _value / 2; }
        }
    }
}
