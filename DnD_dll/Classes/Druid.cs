﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public class Druid : HeroClass
    {
        private static Druid _singleton;
        private Druid() { }
        public static Druid Instance
        {
            get
            {
                if (_singleton == null)
                {
					Druid tmp = new Druid();
					if (_singleton == null)
						_singleton = tmp;
				}
                return _singleton;
            }
        }
        public override Dice.Type HitDice
        {
            get { return Dice.Type.k8; }
        }
        public override string Name
        {
            get { return "Druid"; }
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
            get { return DefensiveRollRatio.Low; }
        }
        protected override DefensiveRollRatio _drWill
        {
            get { return DefensiveRollRatio.High; }
        }
    }
}
