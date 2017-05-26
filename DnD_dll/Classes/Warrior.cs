using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Warrior : HeroClass
    {
        private static readonly Warrior _singleton = new Warrior();
        private Warrior() { }
        public static Warrior Instance
        {
            get { return _singleton; }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k10; }
        }
        public override string Name
        {
            get { return "Warrior"; }
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
