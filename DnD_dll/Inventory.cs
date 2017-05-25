using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Equipment;

namespace DnD
{
#warning Stasiu weź ogarnij tutaj i spójrz czy Ci wszystko odpowiada. Hero może mieć inventory zamiast listy, dodatkowo jedna osoba może mieć ich kilka, albo można coś gdziś wówczas zostawić itp. \

    public class Inventory : INotifyPropertyChanged
    {
        private Pouch _pouch = new Pouch();
        private List<DnD.Equipment.Item> _itemList = new List<DnD.Equipment.Item>();

        public event PropertyChangedEventHandler PropertyChanged;

        public Inventory(List<Equipment.Item> l= null, string name=null)
        {
            Name = name;
            Owner = default(Hero);
            if (l != null)
                _itemList = l;
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
            get {  //NotifyPropertyChanged("Pouch"); 
                return _pouch; }
        }

        public List<Equipment.Item> Bag
        {
            get {  //NotifyPropertyChanged("Bag");
                return _itemList; }

            
        }
        protected void NotifyPropertyChanged( string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Name { get; set; }

        public Hero Owner { get; set; }

        public void AddItem(Equipment.Item item)
        {
            _itemList.Add(item);
            NotifyPropertyChanged("Bag");
        }

        public int TotalWeight
        {
            get { return _itemList.Sum(x => x.Weight) + Pouch.Weight; }
        }
        public int TotalValue
        {
            get { return _itemList.Sum(x => x.ValueInCopper) + Pouch.ValueInCopper; }
        }
        public override string ToString()
        {
            return Name;
        }

        public void RemoveItem(Item i)
        {

            _itemList.Remove(i);
            NotifyPropertyChanged("Bag");
        }
    }
}
