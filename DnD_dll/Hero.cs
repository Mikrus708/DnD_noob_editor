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
        private int[] _atr = new int[Enum.GetValues(typeof(HeroAttribute.Type)).Length];
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
                return 10 + HeroAttribute.GetModifcator(this[HeroAttribute.Type.Dexterity]);
            }
        }
        public int ArmorTouch
        {
            get
            {
                return 10 + HeroAttribute.GetModifcator(this[HeroAttribute.Type.Dexterity]);
            }
        }
        public int ArmorUnprepared
        {
            get
            {
                return 10;
            }
        }
        public int this[HeroAttribute.Type t]
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
        public string Name { get; set; }
        public string PlayerName { get; set; }
        public Race Race { get; set; }
        public HeroClass Class { get; set; }
        public int ClassLevel { get; set; }
        public HeroClass SecondaryClass { get; set; }
        public int SecondaryClassLevel { get; set; }
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
            XmlDocument doc = new XmlDocument();
            doc.AppendChild(doc.ReadNode(reader));
            XmlElement root = doc.DocumentElement;
            Name = root.GetAttribute("Name");
            PlayerName = root.GetAttribute("PlayerName");
            int tmp;
            CreatureSize cstmp;
            XmlElement xelm = (XmlElement)root.SelectSingleNode("Class");
            string stmp = xelm?.InnerText;
            if (stmp != null)
                foreach(HeroClass hc in HeroClass.AllClasses)
                    if (stmp == hc.Name)
                    {
                        Class = hc;
                        if (int.TryParse(xelm.GetAttribute("Level"), out tmp))
                            ClassLevel = tmp;
                        break;
                    }
            xelm = (XmlElement)root.SelectSingleNode("SecondaryClass");
            stmp = xelm?.InnerText;
            if (stmp != null)
                foreach (HeroClass hc in HeroClass.AllClasses)
                    if (stmp == hc.Name)
                    {
                        SecondaryClass = hc;
                        if (int.TryParse(xelm.GetAttribute("Level"), out tmp))
                            SecondaryClassLevel = tmp;
                        break;
                    }
            stmp = root.SelectSingleNode("Race")?.InnerText;
            if (stmp != null)
                foreach (Race r in Race.AllRaces)
                    if (stmp == r.Name)
                    {
                        Race = r;
                        break;
                    }
            if (int.TryParse(root.SelectSingleNode("Speed")?.InnerText, out tmp))
                Speed = tmp;
            if (Enum.TryParse(root.SelectSingleNode("Size")?.InnerText, out cstmp))
                Size = cstmp;
            if (int.TryParse(root.SelectSingleNode("MaxHealthPoints")?.InnerText, out tmp))
                MaxHealthPoints = tmp;
            if (int.TryParse(root.SelectSingleNode("CurrentHealthPoints")?.InnerText, out tmp))
                CurrentHealthPoints = tmp;
            XmlSerializer ser = new XmlSerializer(typeof(Inventory));
            Inventory = (Inventory)ser.Deserialize(new XmlNodeReader(root.SelectSingleNode("Inventory")));
            xelm = (XmlElement)root.SelectSingleNode("Attributes");
            if (xelm != null)
                foreach (XmlElement el in xelm)
                {
                    HeroAttribute.Type ttt;
                    if (Enum.TryParse(el.Name, out ttt) && int.TryParse(el.InnerText, out tmp))
                        _atr[(int)ttt] = tmp;
                }
            xelm = (XmlElement)root.SelectSingleNode("SkillMarks");
            if (xelm != null)
                foreach (XmlElement el in xelm)
                {
                    Skill.Type ttt;
                    if (Enum.TryParse(el.Name, out ttt) && int.TryParse(el.InnerText, out tmp))
                        _marks[(int)ttt] = tmp;
                }
            if (int.TryParse(root.SelectSingleNode("Age")?.InnerText, out tmp))
                Age = tmp;
            if (int.TryParse(root.SelectSingleNode("Height")?.InnerText, out tmp))
                Height = tmp;
            if (int.TryParse(root.SelectSingleNode("Weight")?.InnerText, out tmp))
                Weight = tmp;
            Sex = root.SelectSingleNode("Sex")?.InnerText;
            EyesColor = root.SelectSingleNode("EyesColor")?.InnerText;
            HairColor = root.SelectSingleNode("HairColor")?.InnerText;
        }
        public void WriteXml(XmlWriter writer)
        {
            //new XmlDocument().Save(writer);
            if (Name != null)
                writer.WriteAttributeString("Name", Name);
            if (PlayerName != null)
                writer.WriteAttributeString("PlayerName", PlayerName);
            if (Class != null)
            {
                writer.WriteStartElement("Class");
                writer.WriteAttributeString("Level", ClassLevel.ToString());
                writer.WriteString(Class.Name);
                writer.WriteEndElement();
            }
            if (SecondaryClass != null)
            {
                writer.WriteStartElement("SecondaryClass");
                writer.WriteAttributeString("Level", SecondaryClassLevel.ToString());
                writer.WriteString(SecondaryClass.Name);
                writer.WriteEndElement();
            }
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
            writer.WriteStartElement("Attributes");
            foreach(HeroAttribute.Type t in Enum.GetValues(typeof(HeroAttribute.Type)))
                writer.WriteElementString(t.ToString(), _atr[(int)t].ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("SkillMarks");
            foreach (Skill.Type t in Enum.GetValues(typeof(Skill.Type)))
                writer.WriteElementString(t.ToString(), _marks[(int)t].ToString());
            writer.WriteEndElement();
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
