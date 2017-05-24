using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD
{
    public static class Dice
    {
        private static int[] dices = new int[] { 2, 3, 4, 6, 8, 10, 12, 20, 100 };
        public static int Roll(Type type, int n = 1)
        {
            Random ran = new Random();
            int result = 0;
            for (int i = 0; i < n; ++i)
                result += ran.Next(dices[(int)type]) + 1;
            return result;
        }
        public static int Roll(int seed, Type type, int n = 1)
        {
            Random ran = new Random(seed);
            int result = 0;
            for (int i = 0; i < n; ++i)
                result += ran.Next(dices[(int)type]) + 1;
            return result;
        }
        public enum Type
        {
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
