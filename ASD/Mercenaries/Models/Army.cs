using System;
using System.Collections.Generic;
using System.Text;

namespace Mercenaries.Models
{
    class Army
    {
        private List<Mercenary> mercenaries;
        public int Strength;

        public Army()
        {
            mercenaries = new List<Mercenary>();
        }

        public List<Mercenary> Mercenaries
        {
            get => mercenaries;
            set => mercenaries = value;
        }

        public static Army FindBestArmy(List<Mercenary> mercenaries, int food, int joy)
        {
            Army optimalArmy = new Army();

            int p = 0;

            int[,,] tab = new int[mercenaries.Count + 1, food + 1, joy + 1];

            // Fill x dimension, first line with 0
            for (int i = 0; i < mercenaries.Count + 1; i++)
            {
                tab[i, 0, 0] = 0;
            }

            // Fill y dimension, first line with 0
            for (int i = 0; i < food + 1; i++)
            {
                tab[0, i, 0] = 0;
            }

            // Fill z dimension, first line with 0
            for (int i = 0; i < joy + 1; i++)
            {
                tab[0, 0, i] = 0;
            }

            // Fill 3-dimension table with strength values depending on availbility to take specific mercenary and his costs
            // x - available mercenaries
            for (int x = 1; x < mercenaries.Count + 1; x++)
            {
                // y - available food
                for (int y = 1; y < food + 1; y++)
                {
                    // z - available joy
                    for (int z = 1; z < joy + 1; z++)
                    {
                        // If available food is lower than needed OR available joy is lower than needed then rewrite same value from x - 1 position in table
                        if (y < mercenaries[x - 1].food || z < mercenaries[x - 1].joy)
                        {
                            tab[x, y, z] = tab[x - 1, y, z];
                        }
                        // Else check which option is more optimal. Take previous one (x - 1) OR new mercenary
                        else
                        {
                            tab[x, y, z] = Math.Max(tab[x - 1, y - mercenaries[x - 1].food, z - mercenaries[x - 1].joy] + mercenaries[x - 1].strength, tab[x - 1, y, z]);
                        }
                    }
                }
            }

            // Read results backwards, always start from last position in table, so start with adding that last option strength to results
            optimalArmy.Strength = tab[mercenaries.Count, food, joy];

            // Set params to start searching for warriors to hire
            int mercenaryNumber = mercenaries.Count;
            int availableFood = food;
            int availableJoy = joy;

            // Set pointer
            int pointer = tab[mercenaryNumber, availableFood, availableJoy];

            while (pointer != 0)
            {
                // If its worth to hire that mercenary then add him to army and decrease available food and joy
                if (tab[mercenaryNumber - 1, availableFood, availableJoy] != tab[mercenaryNumber, availableFood, availableJoy])
                {
                    // Add him to army
                    optimalArmy.mercenaries.Add(mercenaries.Find(x => x.Id == mercenaryNumber));
                    p++;

                    // Decrease available food and joy
                    availableFood -= mercenaries[mercenaryNumber - 1].food;
                    availableJoy -= mercenaries[mercenaryNumber - 1].joy;
                    mercenaryNumber--;

                    pointer = tab[mercenaryNumber, availableFood, availableJoy];
                }
                else
                {
                    mercenaryNumber--;
                    pointer = tab[mercenaryNumber, availableFood, availableJoy];
                }
            }
            return optimalArmy;
        }
    }
}
