using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.CodingProblems.Sorting
{
    public class QuickSort
    {
        /// <summary>
        /// Quick Sort First Create partition (q) with pivot point and then recursively calls quicksort for input from p to q-1 and q +1 to r
        /// the partion here uses last index as pivot
        /// While doing partion, it divides array to 4 regions -> 
        /// 1.p to i which is less than or equal to x (pivot point)
        /// 2.i+1 to j-1 which is greated that pivot point x
        /// 3. A[r] = x the pivot point
        /// 4. j to r -1 which can take any values
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>

        public static int[] Sort(int[] input)
        {
            quickSort(input, 0, input.Length-1);
            return input;
        }

        private static void quickSort(int[] A, int p, int r)
        {
            if(p < r)
            {
                int q = partition(A, p, r);
                quickSort(A, p, q - 1);
                quickSort(A, q + 1, r);
            }
        }

        private static int partition(int[] A, int p, int r)
        {
            int x = A[r];//pivot point

            int i = p - 1;
            int temp;

            for(int j = p; j <= r-1; j++)
            {
                if(A[j] <= x)
                {
                    i = i + 1;
                    // if A[j] is less than pivot point
                    //Exchange A[i] and A[j]

                    temp = A[i];
                    A[i] = A[j];
                    A[j] = temp;
                }
            }

            //Exchange A[i+1] with A[r] (current pivot)
            temp = A[i + 1];
            A[i + 1] = A[r];
            A[r] = temp;

            return i + 1;

        }
    }
}
