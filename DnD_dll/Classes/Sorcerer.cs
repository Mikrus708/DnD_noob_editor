using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Sorcerer : HeroClass
    {
        private static Sorcerer _singleton;
        private Sorcerer() { }
        public static Sorcerer Instance
        {
            get
            {
                if (_singleton == null)
                {
					Sorcerer tmp = new Sorcerer();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k4; }
        }
        public override string Name
        {
            get { return "Czarodziej"; }
        }
        protected override BaseAttackRatio _bar
        {
            get { return BaseAttackRatio.Low; }
        }
        protected override DefensiveRollRatio _drEndur
        {
            get { return DefensiveRollRatio.Low; }
        }
        protected override DefensiveRollRatio _drReflx
        {
            get { return DefensiveRollRatio.Low; }
        }
        protected override DefensiveRollRatio _drWill
        {
            get { return DefensiveRollRatio.High; }
        }
    }
}
