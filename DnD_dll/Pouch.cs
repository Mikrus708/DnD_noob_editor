using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DnD
{
    public class Pouch : INotifyPropertyChanged, IEnumerable<Coin>, IXmlSerializable
    {
        private Coin[] _coins;
        public event PropertyChangedEventHandler PropertyChanged;
        public Pouch()
        {
            _coins = new Coin[4];
            for (int i = 0; i < 4; ++i)
            {
                _coins[i] = new Coin((CoinType)i);
            }
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Changes()
        {
            NotifyPropertyChanged("Coins");
            NotifyPropertyChanged("ValueInCopper");
            NotifyPropertyChanged("Weight");
            NotifyPropertyChanged("Indexer");
        }
        public void Add(Coin c)
        {
            _coins[(int)c.Type] += c;
        }
        public static Pouch operator+(Pouch p, Coin c)
        {
            p[c.Type] += c.Ammount;

            p.Changes();
            return p;
        }
        public static Pouch operator-(Pouch p, Coin c)
        {
            if (p[c.Type] < c.Ammount)
                throw new Exception("Za malo monet danego typu");
            p[c.Type] -= c.Ammount;
            p.Changes();
            return p;
        }
        public IEnumerable<Coin> Coins
        {
            get
            {
                return _coins;
            }
        }
        [XmlAttribute]
        public decimal TotalValue
        {
            get
            {
                return _coins.Aggregate(0m, (sum, coin) => sum + coin.Value);
            }
        }
        [XmlIgnore]
        public decimal Weight
        {
            get
            {
                return _coins.Aggregate(0m, (sum, coin) => sum + coin.Weight);
            }
        }
        public Pouch Pay(int valueInCopper)
        {
            if (TotalValue < valueInCopper)
                return null;
            Pouch result = new Pouch();
            int tmp;
            for (int i = 3; i >= 0; --i)
            {
                tmp = Math.Min(valueInCopper / (int)Math.Pow(10, i), _coins[i].Ammount);
                valueInCopper -= tmp * (int)Math.Pow(10, i);
                _coins[i].Ammount -= tmp;
                result._coins[i].Ammount += tmp;
            }
            if (valueInCopper > 0)
                throw new Exception("To nie powinno sie wysypac. Sprawdz Pouch.Pay()");
            return result;
        }
        public IEnumerator<Coin> GetEnumerator()
        {
            foreach (var c in _coins)
                yield return c;
            yield break;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _coins.GetEnumerator();
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.ReadNode(reader));
            XmlElement root = doc.DocumentElement;
            XmlSerializer ser = new XmlSerializer(typeof(Coin));
            foreach (XmlElement el in root.SelectNodes("Coin"))
            {
                Coin c = (Coin)ser.Deserialize(new XmlNodeReader(el));
                this[c.Type] += c.Ammount;
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Coin));
            foreach (Coin c in _coins)
            {
                ser.Serialize(writer, c);
            }
        }
        public int this[CoinType type]
        {
            get
            {
                return _coins[(int)type].Ammount;
            }
            set
            {
                _coins[(int)type].Ammount = value;
                Changes();
                NotifyPropertyChanged("Item[]");
            }
        }
    }
}
