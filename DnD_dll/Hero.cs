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
        private Weapon _mainWeapon;
        private Armor _mainArmor;
        private Armor _mainShield;
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
        public Weapon MainWeapon
        {
            get { return _mainWeapon; }
            set
            {
                if (value != null && !Inventory.Bag.Contains(value))
                    Inventory.Bag.Add(value);
                _mainWeapon = value;
            }
        }
        public Armor MainArmor
        {
            get { return _mainArmor; }
            set
            {
                if (value != null && !Inventory.Bag.Contains(value))
                    Inventory.Bag.Add(value);
                _mainArmor = value;
            }
        }
        public Armor MainShield
        {
            get { return _mainShield; }
            set
            {
                if (value != null && !Inventory.Bag.Contains(value))
                    Inventory.Bag.Add(value);
                _mainShield = value;
            }
        }
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
            {
                XmlSerializer sss;
                Pouch pppc = null;
                List<Item> lit = new List<Item>();
                XmlElement el;
                XmlElement inv = (XmlElement)root.SelectSingleNode("Inventory");
                sss = new XmlSerializer(typeof(Pouch));
                el = (XmlElement)inv.SelectSingleNode("Pouch");
                if (el != null)
                    pppc = (Pouch)sss.Deserialize(new XmlNodeReader(el));
                XmlElement bag = (XmlElement)inv.SelectSingleNode("Bag");
                if (bag != null)
                {
                    sss = new XmlSerializer(typeof(Item));
                    foreach (XmlElement it in bag.SelectNodes("Item"))
                        lit.Add((Item)sss.Deserialize(new XmlNodeReader(it)));
                    sss = new XmlSerializer(typeof(Weapon));
                    foreach (XmlElement it in bag.SelectNodes("Weapon"))
                        lit.Add((Item)sss.Deserialize(new XmlNodeReader(it)));
                    sss = new XmlSerializer(typeof(Armor));
                    foreach (XmlElement it in bag.SelectNodes("Armor"))
                        lit.Add((Item)sss.Deserialize(new XmlNodeReader(it)));
                }
                Inventory = new Inventory(lit, pppc);
                el = (XmlElement)inv.SelectSingleNode("MainWeapon")?.SelectSingleNode("Weapon");
                sss = new XmlSerializer(typeof(Weapon));
                if (el != null)
                    MainWeapon = (Weapon)sss.Deserialize(new XmlNodeReader(el));
                el = (XmlElement)inv.SelectSingleNode("MainArmor")?.SelectSingleNode("Armor");
                sss = new XmlSerializer(typeof(Armor));
                if (el != null)
                    MainArmor = (Armor)sss.Deserialize(new XmlNodeReader(el));
                el = (XmlElement)inv.SelectSingleNode("MainShield")?.SelectSingleNode("Armor");
                if (el != null)
                    MainShield = (Armor)sss.Deserialize(new XmlNodeReader(el));

            }
            xelm = (XmlElement)root.SelectSingleNode("Attributes");
            if (xelm != null)
                foreach (XmlElement el in xelm)
                {
                    HeroAttribute.Type ttt;
                    if (Enum.TryParse(el.Name, out ttt) && int.TryParse(el.GetAttribute("Value"), out tmp))
                        _atr[(int)ttt] = tmp;
                }
            xelm = (XmlElement)root.SelectSingleNode("SkillMarks");
            if (xelm != null)
                foreach (XmlElement el in xelm)
                {
                    Skill.Type ttt;
                    if (Enum.TryParse(el.Name, out ttt) && int.TryParse(el.GetAttribute("Value"), out tmp))
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
            XmlSerializer otherSer;
            {
                writer.WriteStartElement("Inventory");
                if (_mainWeapon != null)
                {
                    otherSer = new XmlSerializer(typeof(Weapon));
                    writer.WriteStartElement("MainWeapon");
                    otherSer.Serialize(writer, _mainWeapon, ns);
                    writer.WriteEndElement();
                }
                otherSer = new XmlSerializer(typeof(Armor));
                if (_mainArmor != null)
                {
                    writer.WriteStartElement("MainArmor");
                    otherSer.Serialize(writer, _mainArmor, ns);
                    writer.WriteEndElement();
                }
                if (_mainShield != null)
                {
                    writer.WriteStartElement("MainShield");
                    otherSer.Serialize(writer, _mainShield, ns);
                    writer.WriteEndElement();
                }
                otherSer = new XmlSerializer(typeof(Pouch));
                otherSer.Serialize(writer, Inventory.Pouch, ns);
                {
                    writer.WriteStartElement("Bag");
                    XmlSerializer serItem = new XmlSerializer(typeof(Item));
                    XmlSerializer serArmo = new XmlSerializer(typeof(Armor));
                    XmlSerializer serWeap = new XmlSerializer(typeof(Weapon));
                    foreach (object it in Inventory.Bag.Where((i) => i != MainWeapon && i != MainArmor && i != MainShield))
                    {
                        if (it.GetType() == typeof(Item))
                            serItem.Serialize(writer, it, ns);
                        else if (it.GetType() == typeof(Weapon))
                            serWeap.Serialize(writer, it, ns);
                        else if (it.GetType() == typeof(Armor))
                            serArmo.Serialize(writer, it, ns);
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteStartElement("Attributes");
            foreach(HeroAttribute.Type t in Enum.GetValues(typeof(HeroAttribute.Type)))
            {
                writer.WriteStartElement(t.ToString());
                writer.WriteAttributeString("Value", _atr[(int)t].ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteStartElement("SkillMarks");
            foreach (Skill.Type t in Enum.GetValues(typeof(Skill.Type)))
            {
                //writer.WriteComment(Skill.GetPolishName(t));
                writer.WriteStartElement(t.ToString());
                writer.WriteAttributeString("Value", _marks[(int)t].ToString());
                writer.WriteEndElement();
            }
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
