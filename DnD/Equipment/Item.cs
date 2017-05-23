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
        public Item(string name, int value, string family = null, string category = null)
        {
            _name = name;
            _category = category;
            _family = family;
            _value = value;
        }
        public int ValueInCopper
        {
            get { return _value; }
        }
        public int SaleValueInCopper
        {
            get { return _value / 2; }
        }
        public enum Family
        {

        }
    }
}
