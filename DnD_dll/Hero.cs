using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class Hero
    {
        private int[] _atr = new int[6];
        private int[] _marks = new int[Enum.GetValues(typeof(Skill.Type)).Length];
        public Hero() { }
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
    }
}
