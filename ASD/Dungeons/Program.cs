using System;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Threading;



namespace Dungeons
{
    class Program
    {
        public static void Main()
        {
            // Try to read file
            string[] file_in;
            try
            {
                file_in = File.ReadAllLines("in.txt");
            }
            catch
            {
                Console.WriteLine("There's no file to read!");
                Console.ReadKey();
                return;
            }

            // Load number of rows and cols (first line)
            string[] line = file_in.First().Split(' ');

            // Number of rows
            int x_max = Int32.Parse(line[0]);
            // Number of cols
            int y_max = Int32.Parse(line[1]);

            // Build new dungeon
            Dungeon dungeon = new Dungeon(x_max, y_max);

            // Load robber position (last line)
            line = file_in.Skip(x_max+1).Take(1).First().Split(' ');

            // Remember position of robber
            int x_robber = Int32.Parse(line[0])-1;
            int y_robber = Int32.Parse(line[1])-1;

            dungeon.Robber = new Robber(x_robber, y_robber);

            // Timer start
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();             
            
            // Create Dungeon that is built of N x M cells
            for(int i=1; i<x_max+1; i++)
            {
                string[] cells = File.ReadLines("in.txt").Skip(i).Take(1).First().Split(' ');

                for (int j=0; j<y_max; j++)
                {
                    dungeon.Cells[i-1,j] = Convert.ToInt32(cells[j]);
                }
            }

            // Increase memory for this operation to 15MB
            int memorySize = 1024 * 1024 * 15;
            Thread th = new Thread(() => 
            Dungeon.FloodTheCell(dungeon, x_robber, y_robber, dungeon.Cells[x_robber, y_robber] - 1, x_max, y_max)
            , memorySize);

            th.Start();
            th.Join();

            // Timer stop
            stopWatch.Stop();                                   //Timer stop   
            TimeSpan ts = stopWatch.Elapsed;                    
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

            // Write output to file
            using (StreamWriter plik_out = new StreamWriter("out.txt"))
            {
                plik_out.WriteLine(Dungeon.wynik + "\n" + elapsedTime);                 

            }
            
            // For faster tests
            Console.WriteLine(Dungeon.wynik + "\n" + elapsedTime);
            
            Console.ReadKey();
        }
    }
}
