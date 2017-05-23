using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class EpicSpell : Spell
    {
        protected School _secondSchool;
        public EpicSpell(Spell s, School second)
        {
            this._name = s.Name;
            this._school = s.School;
            _secondSchool = second;
        }
        public School SecondSchool
        {
            get { return _secondSchool; }
        }
        public override string ToString()
        {
            return $"EPIC SPELL: {base.ToString()} + {_secondSchool}";
        }
    }
}
