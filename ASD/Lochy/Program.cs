using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading;



namespace Lochy
{
    class Program
    {
        static int wynik = 0;
        static Boolean Sprawdz(int poziom_max, int glebokosc_a, int glebokosc_b)     //Funkcja sprawdzająca czy istnieje możliwość przelania się wody do sąsiednich cel
        {
            if (glebokosc_b > glebokosc_a)
            {
                if (glebokosc_b - glebokosc_a < 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                    
            }
            else if (glebokosc_b < glebokosc_a)
            {
                if (glebokosc_a - glebokosc_b < 5 && glebokosc_b > poziom_max)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                    
            }
            else if (glebokosc_b == glebokosc_a)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        static void Zalej(int[,] tablica1, int[,] tablica2, int x, int y, int poziom_max, int x_max, int y_max) //Funkcja zalewająca wodą celę która została wywołana
        {
            int temp = 0;
            for (int pomocnicza = tablica1[x, y]; pomocnicza > poziom_max; pomocnicza--)
            {
                if (temp < 5)                              //Wysokość celi wynosi max 5 metrów
                {
                    temp++;
                }
                else
                {
                    break;
                }
            }
            wynik += temp;                                  //Aktualizacja metrów wody potrzebnych do zalania rozbójnika

            tablica2[x, y] = tablica1[x, y];                //Zaktualizuj celę jako sprawdzoną w celu uniknięcie sprawdzania jej ponownie

            if(x!=x_max-1 && tablica2[x + 1, y] == 0)                       //Jeżeli nie wykracza poza tablicę i nie był sprawdzany to:
            {
                if (Sprawdz(poziom_max, tablica1[x, y], tablica1[x + 1, y]) == true)    //Jeżeli woda może się przelać to:
                {
                    Zalej(tablica1, tablica2, x + 1, y, poziom_max, x_max, y_max);      //Zalej
                }
            }
            if (y != y_max - 1 && tablica2[x, y + 1] == 0)                  //Jeżeli nie wykracza poza tablicę i nie był sprawdzany to:
            {
                if (Sprawdz(poziom_max, tablica1[x, y], tablica1[x, y + 1]) == true)    //Jeżeli woda może się przelać to:
                {
                    Zalej(tablica1, tablica2, x, y + 1, poziom_max, x_max, y_max);      //Zalej
                }
            }
            if(x!=0 && tablica2[x - 1, y] == 0)                             //Jeżeli nie wykracza poza tablicę i nie był sprawdzany to:
            {
                if (Sprawdz(poziom_max, tablica1[x, y], tablica1[x - 1, y]) == true)    //Jeżeli woda może się przelać to:
                {
                    Zalej(tablica1, tablica2, x - 1, y, poziom_max, x_max, y_max);      //Zalej
                }
            }
            if(y!=0 && tablica2[x, y - 1] == 0)                             //Jeżeli nie wykracza poza tablicę i nie był sprawdzany to:
            {
                if (Sprawdz(poziom_max, tablica1[x, y], tablica1[x, y - 1]) == true)    //Jeżeli woda może się przelać to:
                {
                    Zalej(tablica1, tablica2, x, y - 1, poziom_max, x_max, y_max);      //Zalej
                }
            }
            if(x!=x_max-1 && y!=y_max-1 && tablica2[x + 1, y + 1] == 0)     //Jeżeli nie wykracza poza tablicę i nie był sprawdzany to:
            {
                if (Sprawdz(poziom_max, tablica1[x, y], tablica1[x + 1, y + 1]) == true)    //Jeżeli woda może się przelać to:
                {
                    Zalej(tablica1, tablica2, x + 1, y + 1, poziom_max, x_max, y_max);      //Zalej
                }
            }
            if(x!=0 && y!=0 && tablica2[x - 1, y - 1] == 0)                 //Jeżeli nie wykracza poza tablicę i nie był sprawdzany to:
            {
                if (Sprawdz(poziom_max, tablica1[x, y], tablica1[x - 1, y - 1]) == true)    //Jeżeli woda może się przelać to:
                {
                    Zalej(tablica1, tablica2, x - 1, y - 1, poziom_max, x_max, y_max);      //Zalej
                }
            }
            if(x!=x_max-1 && y!=0 && tablica2[x + 1, y - 1] == 0)           //Jeżeli nie wykracza poza tablicę i nie był sprawdzany to:
            {
                if (Sprawdz(poziom_max, tablica1[x, y], tablica1[x + 1, y - 1]) == true)    //Jeżeli woda może się przelać to:
                {
                    Zalej(tablica1, tablica2, x + 1, y - 1, poziom_max, x_max, y_max);      //Zalej
                }
            }
            if(x!=0 && y!=y_max-1 && tablica2[x - 1, y + 1] == 0)           //Jeżeli nie wykracza poza tablicę i nie był sprawdzany to:
            {
                if (Sprawdz(poziom_max, tablica1[x, y], tablica1[x - 1, y + 1]) == true)    //Jeżeli woda może się przelać to:
                {
                    Zalej(tablica1, tablica2, x - 1, y + 1, poziom_max, x_max, y_max);      //Zalej
                }
            }
                
            return;

            
        }

        static void Main()
        {
            int stackSize = 1024 * 1024 * 9;               //Zmienna przechowująca rozmiar w MB jaki chcemy ustawić dla stosu
            var plik_in = File.ReadLines("in.txt");            //Wczytanie pliku
            string[] linia1 = plik_in.First().Split(' ');          //Wczytaj rozmiar danych (pierwsza linia)
            int x_max = Int32.Parse(linia1[0]);                          //Ilość wierszy
            int y_max = Int32.Parse(linia1[1]);                          //Ilość kolumn
            string[] pozycja_rozbojnika = plik_in.Skip(x_max+1).Take(1).First().Split(' ');    //Wczytaj położenie rozbójnika (ostatnia linia)
            int poz_x = Int32.Parse(pozycja_rozbojnika[0])-1;                             //Wiersz w którym znajduje się rozbójnik
            int poz_y = Int32.Parse(pozycja_rozbojnika[1])-1;                             //Kolumna w której znajduje się rozbójnik
            int[,] tablica1 = new int[x_max,y_max];                         //Stworzenie tablicy dwuwymiarowej na dane
            int[,] tablica2 = new int[x_max,y_max];                   //Stworzenie dwuwymiarowej tablicy pomocniczej
            Stopwatch stopWatch = new Stopwatch();                 //Timer start
            stopWatch.Start();                                   
            for(int i=1; i<x_max+1; i++)                           //Pętle wypełniająca tablicę dwuwymiarową danymi
            {
                string[] liczby = File.ReadLines("in.txt").Skip(i).Take(1).First().Split(' ');     //Zacznij zczytywać od drugiej linii
                for (int j=0; j<y_max; j++)
                {
                    tablica1[i-1,j] = Convert.ToInt32(liczby[j]);
                }
            }
            Thread th = new Thread(() => 
            Zalej(tablica1, tablica2, poz_x, poz_y, tablica1[poz_x, poz_y] - 1, x_max, y_max) //Pierwsze wywołanie rekurencji
            , stackSize); //Zwiększ pamięć stosu do 9MB
            th.Start();
            th.Join();
            stopWatch.Stop();                                   //Timer stop   
            TimeSpan ts = stopWatch.Elapsed;                    
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            using (StreamWriter plik_out = new StreamWriter("out.txt"))
            {
                plik_out.WriteLine(wynik + "\n" + elapsedTime);                 

            }
            /*Console.WriteLine(wynik + "\n" + elapsedTime);                    //Dla szybszych testów                
            Console.ReadKey();*/
        }
    }
}
