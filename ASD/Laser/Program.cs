using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections;

namespace Laser
{
    class Program
    {
        public static int[] Sortuj(int[] tablica)                                  //Dzielenie tablic do posortowania na mniejsze tablice
        {
            if (tablica.Length <= 1)
            {
                return tablica;
            }
            int[] pierwsza = new int[tablica.Length / 2];
            int[] druga = new int[tablica.Length - pierwsza.Length];
            for (int i = 0; i < pierwsza.Length; i++)
            {
                pierwsza[i] = tablica[i];
            }
            for (int i = 0; i < druga.Length; i++)
            {
                druga[i] = tablica[pierwsza.Length + i];
            }
            return Scal(Sortuj(pierwsza), Sortuj(druga));
        }

        public static int Szukaj(int min, int max, int szukana, int[] tablica)             //Wyszukiwanie binarne
        {
            int srodek = min + (max - min) / 2;
            if (min == max)
            {
                if (tablica[min] <= szukana)
                {
                    return -1;
                }
                else
                {
                    return min;
                }
            }
            else if (tablica[srodek] <= szukana)
            {
                return Szukaj(srodek + 1, max, szukana, tablica);
            }
            else
            {
                int wynik = Szukaj(0, srodek, szukana, tablica);
                if (wynik != -1)
                {
                    return wynik;
                }
                else
                {
                    return srodek;
                }
            }
        }

        public static int[] Scal(int[] pierwsza, int[] druga)                //Sortowanie danych w tabelach i scalanie jej w jedna
        {
            int[] do_scalenia = new int[pierwsza.Length + druga.Length];
            int i_pierwszy, i_drugi, i_scal;
            for (i_pierwszy = 0, i_drugi = 0, i_scal = 0; i_scal < do_scalenia.Length; i_scal++)
            {
                if (i_pierwszy >= pierwsza.Length)
                {
                    do_scalenia[i_scal] = druga[i_drugi++];
                }
                else if (i_drugi >= druga.Length)
                {
                    do_scalenia[i_scal] = pierwsza[i_pierwszy++];
                }
                else if (pierwsza[i_pierwszy] <= druga[i_drugi])
                {
                    do_scalenia[i_scal] = pierwsza[i_pierwszy++];
                }
                else
                {
                    do_scalenia[i_scal] = druga[i_drugi++];
                }
            }
            return do_scalenia;
        }


        static void Main()
        {
            var plik_in = File.ReadLines("in.txt");                //Wczytanie pliku
            string linia1 = plik_in.First();                     //Aktualizacja informacji o rozmiarze danych
            int rozmiar = Int32.Parse(linia1);
            int[] tablica1 = new int[rozmiar * 2];                 //Tworzenie tabeli o rozmiarze 2n gdzie n jest iloscia danych w pliku
            int i = 0, max_baz_ogolnie = 0, max_baz_aktualnie;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();                                   //Timer start
            foreach (string linia in plik_in.Skip(1))            //Wczytywanie danych z pliku i preprocessing danych, zamiana stopni na minuty i sumowanie jako int, wykonuje sie n razy
            {
                string[] liczby = linia.Split(' ');
                int x = 60 * Convert.ToInt32(liczby[0]);
                int y = Convert.ToInt32(liczby[1]);
                tablica1[i] = x + y;
                i++;
            }
            for (i = 0; i < rozmiar; i++)          //Pętla rozszerzająca tablicę z danymi o te same dane z dodatkowymi 360 stopniami, w celu uproszczenia wyszukiwania odpowiednich baz, wykonuje sie 2n razy
            {
                tablica1[i + rozmiar] = tablica1[i] + 21600;
            }
            tablica1 = Sortuj(tablica1);                           //Sortowanie tablicy metodą scalania
            for (i = 0; i < rozmiar; i++)                            //Glowna petla algorytmu wykonujaca sie n razy
            {
                max_baz_aktualnie = Szukaj(0, rozmiar * 2, tablica1[i] + 5400, tablica1);    //Wyszukiwanie binarne o zlozonosci logn
                max_baz_aktualnie -= i;

                if (max_baz_aktualnie > max_baz_ogolnie)           //Aktualizacja maksymalnej ilosci baz w zasiegu lasera
                {
                    max_baz_ogolnie = max_baz_aktualnie;
                }
            }
            stopWatch.Stop();                                     //Timer stop
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            // Save to file
            using (StreamWriter plik_out = new StreamWriter("out.txt"))
            {
                plik_out.WriteLine(max_baz_ogolnie + "\n" + elapsedTime);

            }
        }
    }
}
