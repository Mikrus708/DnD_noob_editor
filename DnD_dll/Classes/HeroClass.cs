using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Classes
{
    public abstract class HeroClass
    {
        private static Dictionary<string ,HeroClass> _classes;
        static HeroClass()
        {
            _classes = new Dictionary<string, HeroClass>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(HeroClass)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(HeroClass))))
            {
                HeroClass cl = (HeroClass)(type.GetProperty("Instance").GetValue(null));
                _classes.Add(cl.Name, cl);
            }
        }
        public static HeroClass GetClassByName(string Name)
        {
            HeroClass result = null;
            _classes.TryGetValue(Name, out result);
            return result;
        }
        public static IEnumerable<HeroClass> AllClasses
        {
            get
            {
                return _classes.Values;
            }
        }
        protected enum BaseAttackRatio
        {
            Low = 2,
            Avarage = 3,
            High = 4
        }
        protected enum DefensiveRollRatio
        {
            Low = 2,
            High = 3
        }
        protected abstract BaseAttackRatio _bar { get; }
        protected abstract DefensiveRollRatio _drEndur { get; }
        protected abstract DefensiveRollRatio _drReflx { get; }
        protected abstract DefensiveRollRatio _drWill { get; }
        public abstract string Name { get; }
        public virtual IEnumerable<int> BaseAttack(int Level)
        {
            float res = Level;
            while (res > 0)
            {
                yield return (int)(res * (int)_bar / 4);
                res -= (int)_bar / 4;
            }
            yield break;
        }
        public virtual int DefensiveRollEndurance(int Level)
        {
            return Level * (int)_drEndur / 6 + _drEndur == DefensiveRollRatio.High ? 2 : 0;
        }
        public virtual int DefensiveRollReflex(int Level)
        {
            return Level * (int)_drEndur / 6 + _drEndur == DefensiveRollRatio.High ? 2 : 0;
        }
        public virtual int DefensiveRollWill(int Level)
        {
            return Level * (int)_drEndur / 6 + _drEndur == DefensiveRollRatio.High ? 2 : 0;
        }
        public abstract Dice.Type HitDice { get; }
        public override string ToString()
        {
            return Name;
        }
    }
}
