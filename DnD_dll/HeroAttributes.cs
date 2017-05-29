using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public static class HeroAttribute
    {
        private static string[] _pol;
        static HeroAttribute()
        {
            _pol = new string[Enum.GetValues(typeof(Type)).Length];
            #region Polskie nazwy
            _pol[(int)Type.Strength] = "Siła";
            _pol[(int)Type.Dexterity] = "Zręczność";
            _pol[(int)Type.Constitution] = "Wytrzymałość";
            _pol[(int)Type.Intelligence] = "Inteligencja";
            _pol[(int)Type.Wisdom] = "Wiedza";
            _pol[(int)Type.Charisma] = "Charyzma";
            #endregion
        }
        public static string GetPolishName(Type t)
        {
            return _pol[(int)t];
        }
        public static int GetModifcator(int level)
        {
            return level / 2 - 5;
        }
        public enum Type
        {
            Strength,       //Siła
            Dexterity,      //Zręczność
            Constitution,   //Wytrzymałość
            Intelligence,   //Inteligencja
            Wisdom,         //Wiedza
            Charisma        //Charyzma
        }
    }
}
