using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Sorcerer : HeroClass
    {
        private static readonly Sorcerer _singleton = new Sorcerer();
        private Sorcerer() { }
        public static Sorcerer Instance
        {
            get { return _singleton; }
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
