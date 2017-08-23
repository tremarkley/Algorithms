using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversions
{
    class CountingInversions
    {
        public static Tuple<long, int[]> mergeSort(int[] array)
        {
            int n = array.Length;
            //inversion is when i < j AND A[i] > A[j]
            if (n < 2)
            {
                return new Tuple<long, int[]>(0, array);
            }
            else
            {
                long total_inversions = 0;
                int mid = n / 2;
                int[] left_array = array.Take(mid).ToArray();
                int[] right_array = array.Skip(mid).ToArray();
                int[] sorted_array = new int[n];
                Tuple<long, int[]> sorted_left_array_tuple = mergeSort(left_array);
                Tuple<long, int[]> sorted_right_array_tuple = mergeSort(right_array);
                int[] sorted_left_array = sorted_left_array_tuple.Item2;
                int[] sorted_right_array = sorted_right_array_tuple.Item2;
                total_inversions += sorted_left_array_tuple.Item1;
                total_inversions += sorted_right_array_tuple.Item1;
                Tuple<long, int[]> result = merge(sorted_left_array, sorted_right_array);
                total_inversions += result.Item1;
                return new Tuple<long, int[]>(total_inversions, result.Item2);
            }
        }

        private static Tuple<long, int[]> merge(int[] left_array, int[] right_array)
        {
            long count_inversions = 0;
            int[] sorted_array = new int[(left_array.Length + right_array.Length)];
            int n = sorted_array.Length;
            int j = 0;
            int i = 0;
            for (int m = 0; m < n; m++)
            {
                if (j < right_array.Length)
                {
                    if (i >= left_array.Length)
                    {
                        sorted_array[m] = right_array[j];
                        j++;
                    }
                    else if (right_array[j] < left_array[i])
                    {
                        sorted_array[m] = right_array[j];
                        j++;
                        count_inversions += left_array.Length - i;
                    }
                    else
                    {
                        sorted_array[m] = left_array[i];
                        i++;
                    }
                }
                else
                {
                    sorted_array[m] = left_array[i];
                    i++;
                }

            }
            return new Tuple<long, int[]>(count_inversions, sorted_array);
        }
    }
}
