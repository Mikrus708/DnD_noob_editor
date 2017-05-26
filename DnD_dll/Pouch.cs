using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnD
{
    public class Pouch : INotifyPropertyChanged, IEnumerable<Coin>
    {
        private Coin[] coins;
        public event PropertyChangedEventHandler PropertyChanged;
        public Pouch()
        {
            coins = new Coin[4];
            for (int i = 0; i < 4; ++i)
            {
                coins[i] = new Coin((CoinType)i);
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
        }
        public void Add(Coin c)
        {
            coins[(int)c.Type] += c;
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
        [XmlElement("Coin"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Coin[] List
        {
            get { return coins; }
            set { coins = value; }
        }
        public IEnumerable<Coin> Coins
        {
            get
            {
                return coins;
            }
        }
        [XmlIgnore]
        public int ValueInCopper
        {
            get
            {
                return coins.Aggregate(0, (sum, coin) => sum + coin.ValueInCopper);
            }
        }
        [XmlIgnore]
        public int Weight
        {
            get
            {
                return coins.Aggregate(0, (sum, coin) => sum + coin.Weight);
            }
        }
        public Pouch Pay(int valueInCopper)
        {
            if (ValueInCopper < valueInCopper)
                return null;
            Pouch result = new Pouch();
            int tmp;
            for (int i = 3; i >= 0; --i)
            {
                tmp = Math.Min(valueInCopper / (int)Math.Pow(10, i), coins[i].Ammount);
                valueInCopper -= tmp * (int)Math.Pow(10, i);
                coins[i].Ammount -= tmp;
                result.coins[i].Ammount += tmp;
            }
            if (valueInCopper > 0)
                throw new Exception("To nie powinno sie wysypac. Sprawdz Pouch.Pay()");
            return result;
        }
        public IEnumerator<Coin> GetEnumerator()
        {
            foreach (var c in coins)
                yield return c;
            yield break;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return coins.GetEnumerator();
        }
        public int this[CoinType type]
        {
            get
            {
                return coins[(int)type].Ammount;
            }
            set
            {
                coins[(int)type].Ammount = value;
                Changes();
            }
        }
    }
}
