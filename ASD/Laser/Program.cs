using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Collections;

namespace Laser
{
    class Program
    {
        // Sort
        public static int[] Sort(int[] table)
        {
            if (table.Length <= 1)
            {
                return table;
            }
            int[] first = new int[table.Length / 2];
            int[] second = new int[table.Length - first.Length];
            for (int i = 0; i < first.Length; i++)
            {
                first[i] = table[i];
            }
            for (int i = 0; i < second.Length; i++)
            {
                second[i] = table[first.Length + i];
            }
            return Merge(Sort(first), Sort(second));
        }

        // Merge
        private static int[] Merge(int[] first, int[] second)
        {
            int[] toMerge = new int[first.Length + second.Length];
            int indexFirst, indexSecond, indexMerge;
            for (indexFirst = 0, indexSecond = 0, indexMerge = 0; indexMerge < toMerge.Length; indexMerge++)
            {
                if (indexFirst >= first.Length)
                {
                    toMerge[indexMerge] = second[indexSecond++];
                }
                else if (indexSecond >= second.Length)
                {
                    toMerge[indexMerge] = first[indexFirst++];
                }
                else if (first[indexFirst] <= second[indexSecond])
                {
                    toMerge[indexMerge] = first[indexFirst++];
                }
                else
                {
                    toMerge[indexMerge] = second[indexSecond++];
                }
            }
            return toMerge;
        }

        // Binary search
        private static int Search(int min, int max, int target, int[] table)
        {
            int middle = min + (max - min) / 2;
            if (min == max)
            {
                return table[min] <= target ? -1 : min;
            }
            else if (table[middle] <= target)
            {
                return Search(middle + 1, max, target, table);
            }
            else
            {
                int wynik = Search(0, middle, target, table);

                return wynik != -1 ? wynik : middle;
            }
        }


        static void Main()
        {
            // Read File and check if it exists
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

            // All bases in total
            int rozmiar = Int32.Parse(plik_in.First());

            // Create table 2 times larger than amount of bases
            int[] tablica1 = new int[rozmiar * 2];

            int maxBasesTotal = 0, 
                maxBasesTmp,
                i = 0;

            // Timer start
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Read and insert preprocessed data into table
            foreach (string linia in plik_in.Skip(1))
            {
                string[] liczby = linia.Split(' ');
                int x = 60 * Convert.ToInt32(liczby[0]);
                int y = Convert.ToInt32(liczby[1]);
                tablica1[i] = x + y;
                i++;
            }
            
            // Create new bases with position = actual base + 360 degrees in order to check all possible angle
            for (i = 0; i < rozmiar; i++)
            {
                tablica1[i + rozmiar] = tablica1[i] + 21600;
            }

            // Sort bases with merge sort
            tablica1 = Sort(tablica1);

            for (i = 0; i < rozmiar; i++)
            {
                // Binary search for bases in range of lazer (90 degrees)
                maxBasesTmp = Search(0, rozmiar * 2, tablica1[i] + 5400, tablica1);
                maxBasesTmp -= i;

                // Update new max amount of bases in range of our lazer if found better option
                if (maxBasesTmp > maxBasesTotal)
                {
                    maxBasesTotal = maxBasesTmp;
                }
            }
            
            // Timer stop
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            // Save to file
            using (StreamWriter plik_out = new StreamWriter("out.txt"))
            {
                plik_out.WriteLine(maxBasesTotal + "\n" + elapsedTime);

            }
            Console.WriteLine(maxBasesTotal + "\n" + elapsedTime);
        }
    }
}
