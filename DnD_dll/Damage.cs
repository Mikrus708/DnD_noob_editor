using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class Damage
    {
        private int[] diceNum = new int[Enum.GetValues(typeof(Dice.Type)).Length];
        public int Base { get; set; }
        public int this[Dice.Type t]
        {
            get
            {
                return diceNum[(int)t];
            }
            set
            {
                diceNum[(int)t] = value;
            }
        }
        public void Add(Dice.Type t, int ammount = 1)
        {
            diceNum[(int)t] += ammount;
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
        public enum DamageType
        {
            Slashing,       //Cięte
            Bludgeoning,    //Miażdżone
            Piercing        //Kłute
        }
    }
}
