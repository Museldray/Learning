using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeons
{
    class Dungeon
    {
        // Cells in dungeon
        private int[,] cells;
        public Boolean[,] visited;

        // Robber in specific cell inside the dungeon
        private Robber robber;

        public Dungeon(int x, int y)
        {
            this.cells = new int[x, y];
            this.visited = new bool[x, y];
        }

        public int[,] Cells
        {
            get => cells;
            set => cells = value;
        }

        public Robber Robber
        {
            get => robber;
            set => robber = value;
        }


        public static int wynik = 0;
        // Check if water can overflow to connected cells
        public static Boolean CheckIfCanOverflow(int poziom_max, int glebokosc_a, int glebokosc_b)
        {
            if (glebokosc_b > glebokosc_a)
            {
                return glebokosc_b - glebokosc_a < 5 ? true : false;
            }
            else if (glebokosc_b < glebokosc_a)
            {
                return glebokosc_a - glebokosc_b < 5 && glebokosc_b > poziom_max ? true : false;
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

        // Method that flood specific cell and check if water can overflow
        public static void FloodTheCell(Dungeon dungeon, int x, int y, int poziom_max, int x_max, int y_max)
        {
            int temp = 0;
            for (int poziom_wody = dungeon.Cells[x, y]; poziom_wody > poziom_max; poziom_wody--)
            {
                // Height of cell is 5 meters
                if (temp < 5)
                {
                    temp++;
                }
                else
                {
                    break;
                }
            }

            // Update how much water is needed to flood cell with robber
            wynik += temp;


            // Remember that this cell is checked by using visited table
            dungeon.visited[x, y] = true;


            // Check if water can overflow to nearby cells and if it can, flood that cells. Also check if nearby cells are not flooded already
            if (x != x_max - 1 && dungeon.visited[x + 1, y] == false)
            {
                if (CheckIfCanOverflow(poziom_max, dungeon.Cells[x, y], dungeon.Cells[x + 1, y]) == true)
                {
                    FloodTheCell(dungeon, x + 1, y, poziom_max, x_max, y_max);
                }
            }
            if (y != y_max - 1 && dungeon.visited[x, y + 1] == false)
            {
                if (CheckIfCanOverflow(poziom_max, dungeon.Cells[x, y], dungeon.Cells[x, y + 1]) == true)
                {
                    FloodTheCell(dungeon, x, y + 1, poziom_max, x_max, y_max);
                }
            }
            if (x != 0 && dungeon.visited[x - 1, y] == false)
            {
                if (CheckIfCanOverflow(poziom_max, dungeon.Cells[x, y], dungeon.Cells[x - 1, y]) == true)
                {
                    FloodTheCell(dungeon, x - 1, y, poziom_max, x_max, y_max);
                }
            }
            if (y != 0 && dungeon.visited[x, y - 1] == false)
            {
                if (CheckIfCanOverflow(poziom_max, dungeon.Cells[x, y], dungeon.Cells[x, y - 1]) == true)
                {
                    FloodTheCell(dungeon, x, y - 1, poziom_max, x_max, y_max);
                }
            }
            if (x != x_max - 1 && y != y_max - 1 && dungeon.visited[x + 1, y + 1] == false)
            {
                if (CheckIfCanOverflow(poziom_max, dungeon.Cells[x, y], dungeon.Cells[x + 1, y + 1]) == true)
                {
                    FloodTheCell(dungeon, x + 1, y + 1, poziom_max, x_max, y_max);
                }
            }
            if (x != 0 && y != 0 && dungeon.visited[x - 1, y - 1] == false)
            {
                if (CheckIfCanOverflow(poziom_max, dungeon.Cells[x, y], dungeon.Cells[x - 1, y - 1]) == true)
                {
                    FloodTheCell(dungeon, x - 1, y - 1, poziom_max, x_max, y_max);
                }
            }
            if (x != x_max - 1 && y != 0 && dungeon.visited[x + 1, y - 1] == false)
            {
                if (CheckIfCanOverflow(poziom_max, dungeon.Cells[x, y], dungeon.Cells[x + 1, y - 1]) == true)
                {
                    FloodTheCell(dungeon, x + 1, y - 1, poziom_max, x_max, y_max);
                }
            }
            if (x != 0 && y != y_max - 1 && dungeon.visited[x - 1, y + 1] == false)
            {
                if (CheckIfCanOverflow(poziom_max, dungeon.Cells[x, y], dungeon.Cells[x - 1, y + 1]) == true)
                {
                    FloodTheCell(dungeon, x - 1, y + 1, poziom_max, x_max, y_max);
                }
            }

            return;
        }
    }
}
