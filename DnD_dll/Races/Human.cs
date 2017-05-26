﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD.Races
{
    public class Human : Race
    {
        private static readonly Human _singleton = new Human();
        private Human() { }
        public static Human Instance
        {
            get { return _singleton; }
        }
        public override string Name
        {
            get { return "Człowiek"; }
        }
    }
}
