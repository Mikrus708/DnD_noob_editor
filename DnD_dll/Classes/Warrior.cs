using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Warrior : HeroClass
    {
        private static Warrior _singleton;
        private Warrior() { }
        public static Warrior Instance
        {
            get
            {
                if (_singleton == null)
                {
					Warrior tmp = new Warrior();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k10; }
        }
        public override string Name
        {
            get { return "Wojownik"; }
        }
        protected override BaseAttackRatio _bar
        {
            get { return BaseAttackRatio.High; }
        }
        protected override DefensiveRollRatio _drEndur
        {
            get { return DefensiveRollRatio.High; }
        }
        protected override DefensiveRollRatio _drReflx
        {
            get { return DefensiveRollRatio.Low; }
        }
        protected override DefensiveRollRatio _drWill
        {
            get { return DefensiveRollRatio.Low; }
        }
    }
}
