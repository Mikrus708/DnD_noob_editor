using System;
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
    public struct Coin : IXmlSerializable
    {
        private CoinType _Type;
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
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.ReadNode(reader));
            XmlElement root = doc.DocumentElement;
            Enum.TryParse(root.GetAttribute("Type"), out _Type);
            int.TryParse(root.GetAttribute("Ammount"), out Ammount);
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Type", _Type.ToString());
            writer.WriteAttributeString("Ammount", Ammount.ToString());
        }
        public decimal Weight
        {
            get { return Ammount * 0.01m; }
        }
        public decimal Value
        {
            get
            {
                return Ammount * (int)Math.Pow(10, (int)Type) * 0.01m;
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
