using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.CodingProblems.Sorting
{
    public class RandomQuickSort
    {
        public static int[] Sort(int[] input)
        {
            quickSort(input, 0, input.Length - 1);
            return input;
        }

        private static void quickSort(int[] A, int p, int r)
        {
            if (p < r)
            {
                int q = partition(A, p, r);
                quickSort(A, p, q - 1);
                quickSort(A, q + 1, r);
            }
        }

        private static int partition(int[]A ,int p, int r)
        {
            var i = random(p, r);
            var temp = A[r];
            A[r] = A[i];
            A[i] = temp;

            var x = A[r]; // pivot value


            var k = p - 1;

            

            for(int j= p; j<= r-1; j++)
            {
                if(A[j] <= x)
                {

                    k = k + 1; 

                    temp = A[j];
                    A[j] = A[k];
                    A[k] = temp;

                }
            }
            temp = A[k + 1];

            A[k + 1] = A[r];
            A[r] = temp;
            return k + 1;
        }

        private static int random (int p, int r)
        {
            var randomGen = new Random(p);
            return randomGen.Next(p, r);
        }
    }
}
