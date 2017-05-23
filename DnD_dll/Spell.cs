using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DnD
{
    public class Spell
    {
        protected string _name;
        protected string _castingTime;
        protected string _range;
        protected string _target;
        protected School _school;
        protected SubSchool[] _subschool;
        protected MagicClasses[] _classes;
        protected int[] _level;
        protected Component[] _components;
        protected Spell() { }
        public static Spell ConvertXmlElement(XmlElement element)
        {
            Spell result = new Spell();
            if (element.Name != "spell")
                throw new ArgumentException("Element nie jest czarem!");
            XmlNodeList tmp;
            //Nazwa
            tmp = element.GetElementsByTagName("name");
            if (tmp.Count == 0)
                result._name = "untitle";
            else
                result._name = tmp.Item(0).InnerText;
            //Szkołą
            tmp = element.GetElementsByTagName("school");
            string[] strtab = tmp.Item(0).InnerText.Split(' ', ',').Where((s) => s.Length > 1).ToArray();
            if (tmp.Count == 0)
                throw new Exception("Brak elementu szkoły!");
            else
            {
                if (!Enum.TryParse(strtab[0], out result._school))
                    throw new Exception($"Brak enuma szkoły {strtab[0]}");
                if (strtab.Length > 1)
                {
                    School second;
                    if (!Enum.TryParse(strtab[1], out second))
                        throw new Exception($"Brak enuma szkoły {strtab[1]}");
                    result = new EpicSpell(result, second);
                }
            }
            //Podszkoła
            tmp = element.GetElementsByTagName("subschool");
            if (tmp.Count == 0)
                result._subschool = new SubSchool[0];
            else
            {
                strtab = tmp.Item(0).InnerText.Split(' ', ',').Where((s) => s.Length > 2).ToArray();
                result._subschool = new SubSchool[strtab.Length];
                for (int i = 0; i < strtab.Length; ++i)
                {
                    if (!Enum.TryParse(strtab[i], out result._subschool[i]))
                        throw new Exception($"Brak enuma podszkoły {strtab[i]}");
                }
            }
            //Poziomy
            tmp = element.GetElementsByTagName("level");
            if (tmp.Count == 0)
            {
                result._level = new int[0];
                result._classes = new MagicClasses[0];
            }
            else
            {
                strtab = tmp.Item(0).InnerText.Split(' ', ',').Where((s) => s.Length > 0).Select((s) => s.Replace('/', '_')).ToArray();
                result._classes = new MagicClasses[strtab.Length / 2];
                result._level = new int[strtab.Length / 2];
                for (int i = 0; i < strtab.Length / 2; ++i)
                {
                    if (!Enum.TryParse(strtab[i * 2], out result._classes[i]))
                        throw new Exception($"Brak enuma klasy {strtab[i * 2]}");
                    result._level[i] = int.Parse(strtab[i * 2 + 1]);
                }
            }
            //Komponenty
            tmp = element.GetElementsByTagName("components");
            if (tmp.Count == 0)
                result._components = new Component[0];
            else
            {
                strtab = tmp.Item(0).InnerText.Split(' ', ',').Where((s) => s.Length > 0).TakeWhile((s) => s.Last() != ';').Select((s) => s.Replace('/', '_')).ToArray();
                result._components = new Component[strtab.Length];
                for (int i = 0; i < strtab.Length; ++i)
                {
                    if (!Enum.TryParse(strtab[i], out result._components[i]))
                        throw new Exception($"Brak enuma komponentu {strtab[i]}");
                }
            }
            //Czas rzucania
            tmp = element.GetElementsByTagName("casting_time");
            if (tmp.Count == 0)
                result._castingTime = null;
            else
            {
                result._castingTime = tmp.Item(0).InnerText;
            }
            //Zasieg
            tmp = element.GetElementsByTagName("range");
            if (tmp.Count == 0)
                result._range = null;
            else
            {
                result._range = tmp.Item(0).InnerText;
            }
            //Cel
            tmp = element.GetElementsByTagName("target");
            if (tmp.Count == 0)
                result._target = null;
            else
            {
                result._target = tmp.Item(0).InnerText;
            }
            return result;
        }
        public string Range
        {
            get { return _range; }
        }
        public string CastingTime
        {
            get { return _castingTime; }
        }
        public string Name
        {
            get { return _name; }
        }
        public School School
        {
            get { return _school; }
        }
        public IEnumerable<Component> Component
        {
            get { return _components; }
        }
        public IEnumerable<SubSchool> SubSchool
        {
            get { return _subschool; }
        }
        public IEnumerable<Tuple<MagicClasses, int>> Levels
        {
            get { return _classes.Zip(_level, (c, l) => new Tuple<MagicClasses, int>(c, l)); }
        }
        public override string ToString()
        {
            return $"{_name}: {_school}";
        }
    }
    public enum Component
    {
        V,
        V_Brd_only,
        S,
        M,
        F_DF,
        M_DF,
        F,
        DF,
        XP,
        Ritual
    }
    public enum School
    {
        Magic,
        Abjuration,
        Evocation,
        Enchantment,
        Conjuration,
        Transmutation,
        Necromancy,
        Divination,
        Illusion,
        Universal
    }
    public enum SubSchool
    {
        Paladin,
        Shadow,
        Calling,
        Creation,
        Compulsion,
        Healing,
        Summoning,
        Death,
        Evil,
        Glamer,
        Figment,
        Scrying,
        Charm,
        Pattern,
        Teleportation,
        Phantasm
    }
    public enum MagicClasses
    {
        Wizard,
        Sun,
        Earth,
        Healing,
        Blackguard,
        Destruction,
        Trickery,
        Knowledge,
        Law,
        Fire,
        Strength,
        Paladin,
        Evil,
        War,
        Travel,
        Protection,
        Magic,
        Plant,
        Chaos,
        Death,
        Animal,
        Ranger,
        Druid,
        Air,
        Luck,
        Good,
        Water,
        Bard,
        Mind,
        Cleric,
        Repose,
        Artifice,
        Darkness,
        Glory,
        Madness,
        Creation,
        Sorcerer_Wizard
    }
}
