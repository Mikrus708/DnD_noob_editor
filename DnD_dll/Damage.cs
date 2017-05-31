using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace DnD
{
    public class Damage : IXmlSerializable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        int _base;
        private int[] diceNum = new int[Enum.GetValues(typeof(Dice.Type)).Length];
        public Damage() { }
        public int Base
        {
            get { return _base; }
            set
            {
                _base = value;
                NotifyPropertyChanged("Name");
            }
        }
        public void Clear()
        {
            _base = 0;
            for (int i = diceNum.Length - 1; i >= 0; --i)
                diceNum[i] = 0;
            NotifyPropertyChanged("Item[]");
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Base");
        }
        public int this[Dice.Type t]
        {
            get
            {
                return diceNum[(int)t];
            }
            set
            {
                diceNum[(int)t] = value;
                NotifyPropertyChanged("Item[]");
                NotifyPropertyChanged("Name");
            }
        }
        public void Add(Dice.Type t, int ammount = 1)
        {
            this[t] += ammount;
        }
        public int Roll()
        {
            int result = 0;
            foreach (Dice.Type t in Enum.GetValues(typeof(Dice.Type)))
            {
                result += Dice.Roll(t, this[t]);
            }
            return result + Base;
        }
        public string Name
        {
            get { return ToString(); }
        }
        public override string ToString()
        {
            StringBuilder build = new StringBuilder();
            foreach (Dice.Type t in Enum.GetValues(typeof(Dice.Type)))
            {
                if (this[t] > 0)
                {
                    build.Append(this[t]);
                    build.Append(t.ToString());
                    build.Append(" + ");
                }
            }
            build.Append(Base);
            return build.ToString();
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
            int tmp;
            if (int.TryParse(root.GetAttribute("Base"), out tmp))
                Base = tmp;
            XmlElement el = (XmlElement)root.SelectSingleNode("Dices");
            Dice.Type ts;
            if (el != null)
                foreach (XmlElement elem in el)
                    if (Enum.TryParse(elem.Name, out ts) && int.TryParse(elem.GetAttribute("Ammount"), out tmp))
                        this[ts] += tmp;
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Base", Base.ToString());
            writer.WriteStartElement("Dices");
            foreach (Dice.Type t in Enum.GetValues(typeof(Dice.Type)))
            {
                if (this[t] > 0)
                {
                    writer.WriteStartElement(t.ToString());
                    writer.WriteAttributeString("Ammount", this[t].ToString());
                    writer.WriteEndElement();
                }
            }
            writer.WriteEndElement();
        }
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public enum DamageType
        {
            Slashing,       //Cięte
            Bludgeoning,    //Miażdżone
            Piercing        //Kłute
        }
    }
}
