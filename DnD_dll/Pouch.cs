using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class Pouch
    {
        private Coin[] coins = new Coin[4];
        public Pouch() { }
        public static Pouch operator+(Pouch p, Coin c)
        {
            p[c.Type] += c.Ammount;
            return p;
        }
        public static Pouch operator-(Pouch p, Coin c)
        {
            if (p[c.Type] < c.Ammount)
                throw new Exception("Za malo monet danego typu");
            p[c.Type] -= c.Ammount;
            return p;
        }
        public int ValueInCopper
        {
            get
            {
                return coins.Aggregate(0, (sum, coin) => sum + coin.ValueInCopper);
            }
        }
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
        public int this[CoinType type]
        {
            get
            {
                return coins[(int)type].Ammount;
            }
            set
            {
                coins[(int)type].Ammount = value;
            }
        }
    }
}
