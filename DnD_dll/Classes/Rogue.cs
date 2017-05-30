using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Rogue : HeroClass
    {
        private static Rogue _singleton;
        private Rogue() { }
        public static Rogue Instance
        {
            get
            {
                if (_singleton == null)
                {
                    Rogue tmp = new Rogue();
                    if (_singleton == null)
                        _singleton = tmp;
                }
                return _singleton;
            }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k6; }
        }
        public override string Name
        {
            get { return "Łotrzyk"; }
        }
        protected override BaseAttackRatio _bar
        {
            get { return BaseAttackRatio.Average; }
        }
        protected override DefensiveRollRatio _drEndur
        {
            get { return DefensiveRollRatio.Low; }
        }
        protected override DefensiveRollRatio _drReflx
        {
            get { return DefensiveRollRatio.High; }
        }
        protected override DefensiveRollRatio _drWill
        {
            get { return DefensiveRollRatio.Low; }
        }
    }
}
