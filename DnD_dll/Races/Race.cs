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
        private static Dictionary<string, Race> _races;
        static Race()
        {
            _races = new Dictionary<string, Race>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(Race)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Race))))
            {
                Race cl = (Race)(type.GetProperty("Instance").GetValue(null));
                _races.Add(cl.Name, cl);
            }
        }
        public static Race GetRaceByName(string Name)
        {
            Race result = null;
            _races.TryGetValue(Name, out result);
            return result;
        }
        public static IEnumerable<Race> AllRaces
        {
            get
            {
                return _races.Values;
            }
        }
        public abstract string Name { get; }
        public override string ToString()
        {
            return Name;
        }
    }
}
