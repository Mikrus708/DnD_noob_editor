using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public static class Dice
    {
        private static int[] dices = new int[] { 1, 2, 3, 4, 6, 8, 10, 12, 20, 100 };
        public static int Roll(Type type)
        {
            Random ran = new Random();
            return ran.Next(dices[(int)type]) + 1;
        }
        public static int Roll(Type type, int seed)
        {
            Random ran = new Random(seed);
            return ran.Next(dices[(int)type]) + 1;
        }
        public enum Type
        {
            k1,
            k2,
            k3,
            k4,
            k6,
            k8,
            k10,
            k12,
            k20,
            k100
        }
    }
}
