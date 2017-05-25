using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Equipment;
using System.Collections.ObjectModel;

namespace DnD
{
#warning Stasiu weź ogarnij tutaj i spójrz czy Ci wszystko odpowiada. Hero może mieć inventory zamiast listy, dodatkowo jedna osoba może mieć ich kilka, albo można coś gdziś wówczas zostawić itp. \

    public class Inventory : INotifyPropertyChanged
    {
        private Pouch _pouch = new Pouch();
        private ObservableCollection<Item> _itemList = new ObservableCollection<Item>();
        private string _sometext;

        public event PropertyChangedEventHandler PropertyChanged;
        public Inventory(List<Item> l= null, string name=null)
        {
            _pouch.PropertyChanged += _pouch_PropertyChanged;
            _itemList.CollectionChanged += _itemList_CollectionChanged;
            Name = name;
            Owner = default(Hero);
            if (l != null)
                foreach (var x in l)
                    _itemList.Add(x);
            _sometext = "blah";
        }
        private void changes()
        {
            NotifyPropertyChanged("TotalValue");
            NotifyPropertyChanged("TotalWeight");
        }
        private void _pouch_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            changes();
        }
        private void _itemList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            changes();
        }
        public Inventory(Hero h, Pouch p, List<Item> l )
        {
            _pouch.PropertyChanged += _pouch_PropertyChanged;
            Owner = h;
            _pouch = p;
            if (l != null)
                foreach (var x in l)
                    _itemList.Add(x);
            _sometext = "blah";
        }
        public string someText
        {
            get { return _sometext; }
            set { _sometext = value; }
        }
        public string Description { get; set; }
        public Pouch Pouch
        {
            get { return _pouch; }
        }
        public ObservableCollection<Item> Bag
        {
            get { return _itemList; }
        }
        protected void NotifyPropertyChanged( string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Name { get; set; }
        public Hero Owner { get; set; }
        public void AddItem(Item item)
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
        public override string ToString()
        {
            return Name;
        }
        public void RemoveItem(Item i)
        {
            _itemList.Remove(i);
        }
    }
}
