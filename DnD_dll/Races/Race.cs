using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public abstract class Race
    {
        public static IEnumerable<Race> AllRaces
        {
            get
            {
                foreach (Type type in
                    Assembly.GetAssembly(typeof(Race)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Race))))
                {
                    yield return (Race)(type.GetProperty("Instance").GetValue(null));
                }
                yield break;
            }
        }
        public abstract string Name { get; }
        public override string ToString()
        {
            return Name;
        }
    }
}
