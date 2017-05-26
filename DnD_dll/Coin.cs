using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnD
{
    public struct Coin
    {
        [XmlAttribute("Type"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public CoinType _Type;
        [XmlAttribute("Ammount")]
        public int Ammount;
        public Coin(CoinType Type = CoinType.Copper, int Ammount = 0)
        {
            _Type = Type;
            this.Ammount = Ammount;
        }
        public static Coin operator+(Coin c1, Coin c2)
        {
            if (c1.Type != c2.Type)
                throw new ArgumentException("Monety są innych typów!");
            return new Coin(c1.Type, c1.Ammount + c2.Ammount);
        }
        public static Coin operator-(Coin c1, Coin c2)
        {
            if (c1.Type != c2.Type)
                throw new ArgumentException("Monety są innych typów!");
            return new Coin(c1.Type, c1.Ammount - c2.Ammount);
        }
        public static bool operator==(Coin c1, Coin c2)
        {
            return Equals(c1, c2);
        }
        public static bool operator!=(Coin c1, Coin c2)
        {
            return !Equals(c1, c2);
        }
        public override bool Equals(object obj)
        {
            return ((Coin)obj).Type == Type && ((Coin)obj).Ammount == Ammount;
        }
        public override string ToString()
        {
            return $"{Ammount} {Type} coins";
        }
        [XmlIgnore]
        public CoinType Type
        {
            get { return _Type; }
        }
        public override int GetHashCode()
        {
            return Ammount.GetHashCode() ^ Type.GetHashCode();
        }
        [XmlIgnore]
        public int Weight
        {
            get { return Ammount * 10; }
        }
        [XmlIgnore]
        public int ValueInCopper
        {
            get
            {
                return Ammount * (int)Math.Pow(10, (int)Type);
            }
        }
    }
    public enum CoinType
    {
        Copper,
        Silver,
        Gold,
        Platinium
    }
}
