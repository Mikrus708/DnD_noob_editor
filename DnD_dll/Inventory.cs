using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Equipment;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;

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
        public Inventory(IEnumerable<Item> items, IEnumerable<Coin> coins,string name=null)
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
        public void NotifyChanges()
        {
            NotifyPropertyChanged("TotalValue");
            NotifyPropertyChanged("TotalWeight");
        }
        private void _pouch_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyChanges();
        }
        private void _itemList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyChanges();
        }
        public string Description { get; set; }
        public Pouch Pouch
        {
            get { return _pouch; }
        }
        [XmlArray("Bag")]
        [XmlArrayItem("Item", typeof(Item))]
        [XmlArrayItem("Weapon", typeof(Weapon))]
        [XmlArrayItem("Armor", typeof(Armor))]
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
        public decimal TotalWeight
        {
            get { return _itemList.Sum(x => x.Weight) + Pouch.Weight; }
        }
        public decimal TotalValue
        {
            get { return _itemList.Sum(x => x.Value) + Pouch.TotalValue; }
        }
        public override string ToString()
        {
            return Name;
        }
        public void RemoveItem(Item i)
        {
            _itemList.Remove(i);
        }
        public bool SerializeXML(string FilePath)
        {
            bool result = true;
            XmlSerializer ser = new XmlSerializer(typeof(Inventory));
            FileStream fs = File.Open(FilePath, FileMode.Create);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            try
            {
                ser.Serialize(fs, this, ns);
            }
            catch
            {
                result = false;
            }
            fs.Close();
            return result;
        }
        public static object DeserializeXML(string FilePath)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Inventory));
            FileStream fs = File.Open(FilePath, FileMode.Open);
            Inventory result = new Inventory();
            try
            {
                result = (Inventory)ser.Deserialize(fs);
            }
            catch { }
            fs.Close();
            return result;
        }
    }
}
