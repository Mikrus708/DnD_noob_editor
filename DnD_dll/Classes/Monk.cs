using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Monk : HeroClass
    {
        private static readonly Monk _singleton = new Monk();
        private Monk() { }
        public static Monk Instance
        {
            get { return _singleton; }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k8; }
        }
        public override string Name
        {
            get { return "Monk"; }
        }
        protected override BaseAttackRatio _bar
        {
            get { return BaseAttackRatio.Avarage; }
        }
        protected override DefensiveRollRatio _drEndur
        {
            get { return DefensiveRollRatio.High; }
        }
        protected override DefensiveRollRatio _drReflx
        {
            get { return DefensiveRollRatio.High; }
        }
        protected override DefensiveRollRatio _drWill
        {
            get { return DefensiveRollRatio.High; }
        }
    }
}
