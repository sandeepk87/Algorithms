using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.CodingProblems.Sorting
{
    public class MergeSort
    {
        public static int[] Sort(int[] input)
        {

            mergeSort(input, 0, input.Length - 1);
            return input;

        }

        private static void mergeSort(int[] input,int p, int r)
        {
            int q;
            if(p < r)
            {
                q = (p + r) / 2;
                mergeSort(input, p, q);
                mergeSort(input, q + 1, r);
                merge(input, p, q, r);

            }
           
        }

        private static void merge(int[] input,int p, int q, int r)
        {
            var n1 = q - p + 1;
            var n2 = r - q;
            int[] L = new int[n1];
            int[] R = new int[n2];

            int i = 0;
            int j = 0;
            int k = p;

            for(i = 0; i < n1; i++)
            {
                L[i] = input[p + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = input[q+1+j];
            }
            i = 0;
            j = 0;

            //L[n1] = int.MaxValue;
            //R[n2] = int.MaxValue;
            while(k <= r && i<n1 && j<n2)
            {
                if (L[i] <= R[j])
                {
                    input[k] = L[i];
                    i++;
                }

                else
                {
                    input[k] = R[j];
                    j++;
                }
                k++;
            }

            while(i < n1)
            {
                input[k] = L[i];
                k++;
                i++;
            }

            while (j < n2)
            {
                input[k] = R[j];
                k++;
                j++;
            }

          

        }
    }
}
