using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
#warning Stasiu weź ogarnij tutaj i spójrz czy Ci wszystko odpowiada. Hero może mieć inventory zamiast listy, dodatkowo jedna osoba może mieć ich kilka, albo można coś gdziś wówczas zostawić itp. \

    public class Inventory
    {
        private Pouch _pouch = new Pouch();
        private List<DnD.Equipment.Item> _itemList = new List<DnD.Equipment.Item>();


        public Inventory()
        {
            Owner = default(Hero);
        }

        public Inventory(Hero h, Pouch p, List<Equipment.Item> l )
        {
            Owner = h;
            _pouch = p;
            _itemList = l; 
        }

        public string Description { get; set; }

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

        public int TotalWeight
        {
            get { return _itemList.Sum(x => x.Weight) + Pouch.Weight; }
        }
        public int TotalValue
        {
            get { return _itemList.Sum(x => x.ValueInCopper) + Pouch.ValueInCopper; }
        }
    }
}
