using System;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace Algorytm3._3
{
    class Program
    {
        static int[] wynik;
        static int wynik_sila = 0;
        public static void znajdzOdpowiedz(Najemnik[] najemnicy, int zywnosc, int rozrywka)
        {
            wynik = new int[najemnicy.Length];
            int p = 0;
            int[,,] tablica = new int[najemnicy.Length + 1, zywnosc + 1, rozrywka + 1];

            for (int i = 0; i < najemnicy.Length + 1; i++)
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

            for (int j = 1; j < najemnicy.Length + 1; j++)
            {
                for (int i = 1; i < zywnosc + 1; i++)
                {
                    for(int z = 1; z < rozrywka + 1; z++)
                    {
                        if (i < najemnicy[j - 1].Posilek || z < najemnicy[j - 1].Rozrywka)
                        {
                            tablica[j, i, z] = tablica[j - 1, i, z];
                        }
                        else
                        {
                            tablica[j, i, z] = Math.Max(tablica[j - 1, i - najemnicy[j - 1].Posilek, z - najemnicy[j-1].Rozrywka] + najemnicy[j - 1].Sila, tablica[j - 1, i, z]);
                        }
                    }   
                }
            }

            wynik_sila = tablica[najemnicy.Length, zywnosc, rozrywka];
            int numer_najemnika = najemnicy.Length;
            int azywnosc = zywnosc;
            int arozrywka = rozrywka;
            int x = tablica[numer_najemnika, azywnosc, arozrywka];
            while (x != 0)
            {
                if (tablica[numer_najemnika - 1, azywnosc, arozrywka] != tablica[numer_najemnika, azywnosc, arozrywka])
                {
                    wynik[p] = numer_najemnika;
                    p++;
                    azywnosc -= najemnicy[numer_najemnika-1].Posilek;
                    arozrywka -= najemnicy[numer_najemnika-1].Rozrywka;
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
            string[] linia1 = plik_in.First().Split(' ');
            int ilosc_wojakow = Int32.Parse(plik_in.Skip(1).Take(1).First());
            int zywnosc = Int32.Parse(linia1[0]);
            int rozrywka = Int32.Parse(linia1[1]);
            Najemnik[] najemnicy = new Najemnik[ilosc_wojakow];
            Stopwatch stopWatch = new Stopwatch();                                          //TIMER START
            stopWatch.Start();
            for(int i = 0; i < ilosc_wojakow; i++)                                          //TWORZENIE NAJEMNIKÓW I WPISYWANIE DO TABLICY
            {
                string[] linia = plik_in.Skip(i + 2).Take(1).First().Split(' ');
                najemnicy[i] = new Najemnik(i, Int32.Parse(linia[1]), Int32.Parse(linia[0]), Int32.Parse(linia[2]));
                //Console.WriteLine("Id = " + najemnicy[i].Id + " Sila = " + najemnicy[i].Sila + " Cena = " + najemnicy[i].Posilek + " Długość tablicy = " + najemnicy.Length + " Rozrywka = " + najemnicy[i].Rozrywka);   //DO TESTOW
            }
            znajdzOdpowiedz(najemnicy, zywnosc, rozrywka);                                  //WYWOŁANIE FUNKCJI
            stopWatch.Stop();                                                               //TIMER STOP
            TimeSpan ts = stopWatch.Elapsed;                                                
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            using (StreamWriter plik_out = new StreamWriter("out.txt"))
            {
                plik_out.WriteLine(wynik_sila);
                for (int i = wynik.Length - 1; i>=0; i--)
                {
                    if(wynik[i] != 0)
                    {
                        plik_out.Write(wynik[i] + " ");                                      //ZAPIS DO PLIKU
                    }                                  
                }
                plik_out.WriteLine("\n" + elapsedTime);
            }

            Console.WriteLine(wynik_sila);
            for (int i = wynik.Length - 1; i>=0; i--)
            {
                if (wynik[i] != 0)
                {                                                                             //SZYBSZE TESTY
                    Console.Write(wynik[i] + " ");
                }                                  
            }
            Console.WriteLine("\n" + elapsedTime);
            Console.ReadKey();
        }
    }
}
