﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Paladin : HeroClass
    {
        private static Paladin _singleton;
        private Paladin() { }
        public static Paladin Instance
        {
            get
            {
                if (_singleton == null)
                {
					Paladin tmp = new Paladin();
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
            get { return "Paladyn"; }
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
