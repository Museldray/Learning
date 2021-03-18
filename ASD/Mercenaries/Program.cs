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
        static int[] wynik;
        static int wynik_sila = 0;
        public static void znajdzOdpowiedz(List<Mercenary> najemnicy, int zywnosc, int rozrywka)
        {
            wynik = new int[najemnicy.Count];
            int p = 0;
            int[,,] tablica = new int[najemnicy.Count + 1, zywnosc + 1, rozrywka + 1];

            for (int i = 0; i < najemnicy.Count + 1; i++)
            {
                tablica[i, 0, 0] = 0;
            }

            for (int i = 0; i < zywnosc + 1; i++)
            {
                tablica[0, i, 0] = 0;
            }

            for (int i = 0; i < rozrywka + 1; i++)
            {
                tablica[0, 0, i] = 0;
            }

            for (int j = 1; j < najemnicy.Count + 1; j++)
            {
                for (int i = 1; i < zywnosc + 1; i++)
                {
                    for(int z = 1; z < rozrywka + 1; z++)
                    {
                        if (i < najemnicy[j - 1].posilek || z < najemnicy[j - 1].rozrywka)
                        {
                            tablica[j, i, z] = tablica[j - 1, i, z];
                        }
                        else
                        {
                            tablica[j, i, z] = Math.Max(tablica[j - 1, i - najemnicy[j - 1].posilek, z - najemnicy[j-1].rozrywka] + najemnicy[j - 1].sila, tablica[j - 1, i, z]);
                        }
                    }   
                }
            }

            wynik_sila = tablica[najemnicy.Count, zywnosc, rozrywka];
            int numer_najemnika = najemnicy.Count;
            int azywnosc = zywnosc;
            int arozrywka = rozrywka;
            int x = tablica[numer_najemnika, azywnosc, arozrywka];
            while (x != 0)
            {
                if (tablica[numer_najemnika - 1, azywnosc, arozrywka] != tablica[numer_najemnika, azywnosc, arozrywka])
                {
                    wynik[p] = numer_najemnika;
                    p++;
                    azywnosc -= najemnicy[numer_najemnika-1].posilek;
                    arozrywka -= najemnicy[numer_najemnika-1].rozrywka;
                    numer_najemnika--;
                    x = tablica[numer_najemnika, azywnosc, arozrywka];
                }
                else
                {
                    numer_najemnika--;
                    x = tablica[numer_najemnika, azywnosc, arozrywka];
                }
            }
        }

        static void Main()
        {          
            var plik_in = File.ReadLines("in.txt");

            string[] resources = plik_in.First().Split(' ');

            int zywnosc = Int32.Parse(resources[0]);
            int rozrywka = Int32.Parse(resources[1]);

            List<Mercenary> najemnicy = new List<Mercenary>();

            // Timer start
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Load data about available mercenaries from file 
            foreach(string line in plik_in.Skip(2))
            {
                string[] details = line.Split(' ');
                najemnicy.Add(new Mercenary(Int32.Parse(details[1]), Int32.Parse(details[0]), Int32.Parse(details[2])));
            }

            znajdzOdpowiedz(najemnicy, zywnosc, rozrywka);

            // Stop timer and format elapsed time
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;                                                
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            // Save results to file
            using (StreamWriter plik_out = new StreamWriter("out.txt"))
            {
                plik_out.WriteLine(wynik_sila);
                for (int i = wynik.Length - 1; i>=0; i--)
                {
                    if(wynik[i] != 0)
                    {
                        plik_out.Write(wynik[i] + " ");
                    }                                  
                }
                plik_out.WriteLine("\n" + elapsedTime);
            }

            // Faster tests
            Console.WriteLine(wynik_sila);
            for (int i = wynik.Length - 1; i>=0; i--)
            {
                if (wynik[i] != 0)
                {                                                                             
                    Console.Write(wynik[i] + " ");
                }                                  
            }

            Console.WriteLine("\n" + elapsedTime);
            Console.ReadKey();
        }
    }
}
