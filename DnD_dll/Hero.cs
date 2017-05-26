using DnD.Classes;
using DnD.Equipment;
using DnD.Races;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace DnD
{
    public class Hero : IXmlSerializable
    {
        private int[] _atr = new int[6];
        private int[] _marks = new int[Enum.GetValues(typeof(Skill.Type)).Length];
        public Hero()
        {
            Inventory = new Inventory();
            Inventory.Name = $"Inventory of {Name}";
        }
        public int Speed { get; set; }
        public Inventory Inventory { get; set; }
        public CreatureSize Size { get; set; }
        public int MaxHealthPoints { get; set; }
        public int CurrentHealthPoints { get; set; }
        public int Bruise { get; set; }
        public int Armor
        {
            get
            {
                return 10 + Atribute.GetModifcator(this[Atribute.Type.Dexterity]);
            }
        }
        public int ArmorTouch
        {
            get
            {
                return 10 + Atribute.GetModifcator(this[Atribute.Type.Dexterity]);
            }
        }
        public int ArmorUnprepared
        {
            get
            {
                return 10;
            }
        }
        public int this[Atribute.Type t]
        {
            get
            {
                return _atr[(int)t];
            }
            set
            {
                _atr[(int)t] = value;
            }
        }
        public int this[Skill.Type t]
        {
            get
            {
                return _marks[(int)t];
            }
            set
            {
                _marks[(int)t] = value;
            }
        }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string PlayerName { get; set; }
        [XmlIgnore]
        public Race Race { get; set; }
        [XmlIgnore]
        public HeroClass Class { get; set; }
        public int ClassLevel { get; set; }
        public int Modifier { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string EyesColor { get; set; }
        public string HairColor { get; set; }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            Name = reader.GetAttribute("Name");
            PlayerName = reader.GetAttribute("PlayerName");
            while (reader.Read())
            {
                switch (reader.Name)
                {
                case "Class":
                    foreach (var t in HeroClass.AllClasses())
                        if (reader.Value == t.Name)
                            {
                                Class = t;
                                break;
                            }
                    break;
                }
            }
            //bool isEmptyElement = reader.IsEmptyElement; // (1)
            //reader.ReadStartElement();
            //if (!isEmptyElement) // (1)
            //{
            //    Birthday = DateTime.ParseExact(reader.
            //        ReadElementString("Birthday"), "yyyy-MM-dd", null);
            //    reader.ReadEndElement();
            //}
        }
        public void WriteXml(XmlWriter writer)
        {
            if (Name != null)
                writer.WriteAttributeString("Name", Name);
            if (PlayerName != null)
                writer.WriteAttributeString("PlayerName", PlayerName);
            if (Class != null)
                writer.WriteElementString("Class", Class.Name);
            if (Race != null)
                writer.WriteElementString("Race", Race.Name);
            writer.WriteElementString("Speed", Speed.ToString());
            writer.WriteElementString("Size", Size.ToString());
            writer.WriteElementString("MaxHealthPoints", MaxHealthPoints.ToString());
            writer.WriteElementString("CurrentHealthPoints", CurrentHealthPoints.ToString());
            writer.WriteElementString("Bruise", Bruise.ToString());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var otherSer = new XmlSerializer(typeof(Inventory));
            otherSer.Serialize(writer, Inventory, ns);
            writer.WriteElementString("Age", Age.ToString());
            writer.WriteElementString("Height", Height.ToString());
            writer.WriteElementString("Weight", Weight.ToString());
            if (Sex != null)
                writer.WriteElementString("Sex", Sex);
            if (EyesColor != null)
                writer.WriteElementString("EyesColor", EyesColor);
            if (HairColor != null)
                writer.WriteElementString("HairColor", HairColor);
        }
    }
    public enum CreatureSize
    {
        Fine,
        Diminutive,
        Tiny,
        Small,
        Medium,
        Large,
        Huge,
        Gargantuan,
        Colossal
    }
}
