using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Ranger : HeroClass
    {
        private static readonly Ranger _singleton = new Ranger();
        private Ranger() { }
        public static Ranger Instance
        {
            get { return _singleton; }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k8; }
        }
        public override string Name
        {
            get { return "Tropiciel"; }
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
            get { return DefensiveRollRatio.High; }
        }
        protected override DefensiveRollRatio _drWill
        {
            get { return DefensiveRollRatio.Low; }
        }
    }
}
