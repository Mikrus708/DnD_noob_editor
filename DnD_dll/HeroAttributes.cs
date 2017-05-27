using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public static class HeroAttribute
    {
        public static int GetModifcator(int level)
        {
            return level / 2 - 5;
        }
        public enum Type
        {
            Strength,
            Dexterity,
            Constitution,
            Intelligence,
            Wisdom,
            Charisma
        }
    }
}
