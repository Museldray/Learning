using System;
using System.Collections.Generic;
using System.Text;

namespace Mercenaries.Models
{
    class Mercenary
    {
        private int id = 0;
        public int posilek;
        public int sila;
        public int rozrywka;
        public Mercenary(int posilek, int sila, int rozrywka)
        {
            this.id = id;
            this.posilek = posilek;
            this.sila = sila;
            this.rozrywka = rozrywka;

        }
        public int Id
        {
            get => id;
            set => id++;
        }
    }
}
