using DnD.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DnD
{
    public class Hero
    {
        private int[] _atr = new int[6];
        private int[] _marks = new int[Enum.GetValues(typeof(Skill.Type)).Length];
        private Pouch _pouch = new Pouch();
        public Hero()
        {
            Inventory = new List<Item>();
        }
        public int Speed { get; set; }
        public Pouch Pouch
        {
            get { return _pouch; }
        }
        public List<Item> Inventory { get; }
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
        public string Name { get; set; }
        public string PlayerName { get; set; }
#warning nk stworzy enuma do rasy
        public string Race { get; set; }
#warning nk stworzy klasy
        public string Class { get; set; }
        public int ClassLevel { get; set; }
        public int Modifier { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string EyesColor { get; set; }
        public string HairColor { get; set; }



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
