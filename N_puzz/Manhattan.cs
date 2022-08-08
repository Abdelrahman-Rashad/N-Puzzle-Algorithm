using System;
using System.Collections.Generic;
using System.Text;

namespace N_puzz
{
    class Manhattan
    {
        int manhatten;


        // O(1)
        public Manhattan()
        {

            manhatten = 0;

        }

        // O(N^2)
        public int Heuristics(int[,] puzzle, int num)
        {
            manhatten = 0;


            for (int x = 0; x < num; x++)
            {
                for (int y = 0; y < num; y++)
                {
                    if (puzzle[x, y] == 0)
                        continue;
                    manhatten += Math.Abs(x - (puzzle[x, y] - 1) / num) + Math.Abs(y - (puzzle[x, y] - 1) % num);
                }
            }
            return manhatten;
        }

    }
}
