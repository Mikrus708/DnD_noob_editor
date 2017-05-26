using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Wizard : HeroClass
    {
        private static readonly Wizard _singleton = new Wizard();
        private Wizard() { }
        public override HeroClass Instance
        {
            get { return _singleton; }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k4; }
        }
        public override string Name
        {
            get { return "Wizard"; }
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
