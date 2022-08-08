using System;
using System.Collections.Generic;
using System.Text;

namespace N_puzz
{
    class IsSolvable
    {

        // O(N^2)
        public static bool isSolvable(int[,] puzzle, int N)
        {
            int[] puzzle1d = new int[N * N];
            int x = 0;

            // O(N^2)
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    x = i * N + j;
                    puzzle1d[x] = puzzle[i, j];
                    //Console.WriteLine(puzzle1d[x]);
                }
            }

            // O(NlogN)
            int invCount = Count(puzzle1d, N);

            //O(1)
            if ((N & 1) != 0)
            {
                return (invCount & 1) == 0;
            }


            else
            {
                // O(N^2)
                int pos = findpos(puzzle, N);

                // O(1)
                if ((pos & 1) != 0)
                {
                    return (invCount & 1) == 0;//even
                }

                // O(1)
                else
                {
                    return (invCount & 1) != 0;//odd
                }
            }
        }

        //O(NlogN)
        public static int Count(int[] arr, int N)
        {
            int counter = 0;
            for (int i = 0; i < N * N - 1; i++)
            {
                for (int j = i + 1; j < N * N; j++)
                {
                    if (arr[j] != 0 && arr[i] != 0 && arr[i] > arr[j])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        // O(N^2)
        static int findpos(int[,] puzzle, int N)
        {
            for (int i = N - 1; i >= 0; i--)
                for (int j = N - 1; j >= 0; j--)
                    if (puzzle[i, j] == 0)

                        return N - i;

            return 0;
        }

    }
}
