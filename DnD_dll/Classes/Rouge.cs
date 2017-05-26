using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Rouge : HeroClass
    {
        private static readonly Rouge _singleton = new Rouge();
        private Rouge() { }
        public static Rouge Instance
        {
            get { return _singleton; }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k6; }
        }
        public override string Name
        {
            get { return "Rouge"; }
        }
        protected override BaseAttackRatio _bar
        {
            get { return BaseAttackRatio.Avarage; }
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
