using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    class Inventory
    {
        private Pouch _pouch = new Pouch();
        private List<DnD.Equipment.Item> _itemList = new List<DnD.Equipment.Item>();

        public Pouch Pouch
        {
            get { return _pouch; }
        }

        public List<Equipment.Item> Bag
        {
            get { return _itemList; }
        }

        public string Name { get; set; }

        public Hero Owner { get; set; }

        public void AddItem(Equipment.Item item)
        {
            _itemList.Add(item);
        }
    }
}
