using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using Mercenaries.Models;
using System.Collections.Generic;

namespace Mercenaries
{
    // Program to find best army with specific amount of food and "joy"
    class Program
    {
        static void Main()
        {
            // Initialize object Army
            Army bestArmy = new Army();

            // Read data from file
            string[] plik_in;
            try
            {
                plik_in = File.ReadAllLines("in.txt");
            }
            catch
            {
                Console.WriteLine("There's no file to read!");
                Console.ReadKey();
                return;
            }

            // Load available resources
            string[] resources = plik_in.First().Split(' ');
            int food = Int32.Parse(resources[0]);
            int joy = Int32.Parse(resources[1]);

            // Container for our mercenaries to exist in
            List<Mercenary> mercenaries = new List<Mercenary>();

            // Timer start
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Load data about available mercenaries from file and give them unique Id
            int id = 1;
            foreach (string line in plik_in.Skip(2))
            {
                string[] details = line.Split(' ');
                mercenaries.Add(new Mercenary(id, Int32.Parse(details[1]), Int32.Parse(details[0]), Int32.Parse(details[2])));
                id++;
            }

            // Find best mercs to build an army
            bestArmy = Army.FindBestArmy(mercenaries, food, joy);

            // Reverse whole list to write results in correct order
            bestArmy.Mercenaries.Reverse();

            // Stop timer and format elapsed time
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;                                                
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            // Save results to file
            using (StreamWriter plik_out = new StreamWriter("out.txt"))
            {
                plik_out.WriteLine(bestArmy.Strength);

                foreach(Mercenary merc in bestArmy.Mercenaries)
                {
                    plik_out.Write(merc.Id + " ");                            
                }
                plik_out.WriteLine("\n" + elapsedTime);
            }

            // Faster tests
            Console.WriteLine(bestArmy.Strength);
            foreach(Mercenary merc in bestArmy.Mercenaries)
            {        
                Console.Write(merc.Id + " ");
            }

            Console.WriteLine("\n" + elapsedTime);
            Console.ReadKey();
        }
    }
}
