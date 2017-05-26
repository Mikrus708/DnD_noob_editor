﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Equipment;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace DnD
{
#warning Stasiu weź ogarnij tutaj i spójrz czy Ci wszystko odpowiada. Hero może mieć inventory zamiast listy, dodatkowo jedna osoba może mieć ich kilka, albo można coś gdziś wówczas zostawić itp. \

    public class Inventory : INotifyPropertyChanged
    {
        private Pouch _pouch = new Pouch();
        private ObservableCollection<Item> _itemList = new ObservableCollection<Item>();
        public event PropertyChangedEventHandler PropertyChanged;
        public Inventory()
        {
            _pouch.PropertyChanged += _pouch_PropertyChanged;
            _itemList.CollectionChanged += _itemList_CollectionChanged;
        }
        public Inventory(IEnumerable<Item> items, IEnumerable<Coin> coins,string name="Untitled")
        {
            _pouch.PropertyChanged += _pouch_PropertyChanged;
            _itemList.CollectionChanged += _itemList_CollectionChanged;
            Name = name;
            if (items != null)
                foreach (var x in items)
                    _itemList.Add(x);
            if (coins != null)
                foreach (var c in coins)
                    _pouch.Add(c);
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
        [XmlAttribute("Name")]
        public string Name { get; set; }
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
