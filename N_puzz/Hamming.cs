using System;
using System.Collections.Generic;
using System.Text;

namespace N_puzz
{
    class Hamming
    {
        // O(N^2)
        public int hamming_method(int[,] arr, int dimention_method)
        {
            int size = arr.Length;
            int[] result = new int[size];
            int write = 0;

            // O(N^2)
            for (int i = 0; i <= dimention_method-1; i++)
            {
                for (int z = 0; z <= dimention_method-1; z++)
                {
                    result[write++] = arr[i, z];
                }
            }

            int width = result.Length;
            int offset = 1;
            int sum = 0;

            // O(N)
            for (int i = 0; i < width; i++)
            {
                if (result[i] != i + offset && result[i] != 0)
                    sum++;
            }
            return sum;
        }
    }
}
