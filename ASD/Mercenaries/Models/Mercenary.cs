using System;
using System.Collections.Generic;
using System.Text;

namespace Mercenaries.Models
{
    class Mercenary
    {
        private int id;
        public int food;
        public int strength;
        public int joy;
        public Mercenary(int id, int posilek, int sila, int rozrywka)
        {
            this.id = id;
            this.food = posilek;
            this.strength = sila;
            this.joy = rozrywka;

        }
        public int Id
        {
            get => id;
            set => id++;
        }
    }
}
