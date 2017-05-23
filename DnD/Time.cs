using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public class Time
    {
        protected int _ammount;
    }
    public enum Action
    {
        Free,
        Move,
        Standard
    }
    public enum Period
    {
        Round,
        Second,
        Minute,
        Hour,
        Day,
        Week,
        Month,
        Year
    }
}
