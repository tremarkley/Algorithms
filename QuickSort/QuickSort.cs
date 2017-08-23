using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class QuickSort
    {
        public static Tuple<long, int[]> doQuickSort(int[] array)
        {
            int og_left_boundary = 0;
            int og_right_boundary = array.Length - 1;
            return Partition(array, og_left_boundary, og_right_boundary);
        }

        public static int[] ChoosePivot(int[] array, int left_boundary, int right_boundary)
        {
            /*//if last element
            int og_first = array[left_boundary];
            int og_last = array[right_boundary];
            array[left_boundary] = og_last;
            array[right_boundary] = og_first;
            return array;*/

            //for median of three
            int middle_index;
            int first_index = left_boundary;
            int last_index = right_boundary;
            int median;
            //this means an even numbered array
            if ((left_boundary - right_boundary) % 2 != 0)
            {
                middle_index = left_boundary + (int)Math.Ceiling((double)(right_boundary - left_boundary) / 2) - 1;
            }
            else
            {
                middle_index = left_boundary + (right_boundary - left_boundary) / 2;
            }
            if ((array[first_index] >= array[middle_index] && array[first_index] <= array[last_index]) || (array[first_index] <= array[middle_index] && array[first_index] >= array[last_index]))
            {
                median = first_index;
            }
            else if ((array[middle_index] >= array[first_index] && array[middle_index] <= array[last_index]) || (array[middle_index] <= array[first_index] && array[middle_index] >= array[last_index]))
            {
                median = middle_index;
            }
            else
            {
                median = last_index;
            }
            Console.WriteLine("first_index: " + array[first_index]);
            Console.WriteLine("middle_index: " + array[middle_index]);
            Console.WriteLine("last_index: " + array[last_index]);
            Console.WriteLine("median: " + array[median]);
            int og_median = array[median];
            int og_first = array[left_boundary];
            array[left_boundary] = og_median;
            array[median] = og_first;

            return array;
        }

        public static Tuple<long, int[]> Partition(int[] A, int left_boundary, int right_boundary)
        {
            long comparisons = 0;
            if (left_boundary >= right_boundary)
            {
                return new Tuple<long, int[]>(0, A);
            }
            else
            {
                comparisons = right_boundary - left_boundary;
                //int pivot = A[ChoosePivot(A)];
                ChoosePivot(A, left_boundary, right_boundary);
                int pivot = A[left_boundary];
                int i = left_boundary + 1;
                for (int j = left_boundary + 1; j < right_boundary + 1; j++)
                {
                    if (A[j] < pivot)
                    {
                        int og_aj = A[j];
                        int og_ai = A[i];
                        A[j] = og_ai;
                        A[i] = og_aj;
                        i++;
                    }
                }
                //where the pivot is
                int og_al = A[left_boundary];
                //the furthest right index within < p
                int og_ai1 = A[i - 1];
                A[left_boundary] = og_ai1;
                //pivot is place in correct spot
                A[i - 1] = og_al;
                //left boundary of < p is still the same left boundary of original array
                int new_left_left_boundary = left_boundary;
                //since pivot is at i -1 we want to go one less than that as the right boundary to < p
                int new_left_right_boundary = i - 2;
                //since pivot is at i -1 we want to go one up from that to get left boundary of > p
                int new_right_left_boundary = i;
                //right boundary of > p is still same right boundary of original array
                int new_right_right_boundary = right_boundary;
                //call Partition subroutine on both sides
                Tuple<long, int[]> less_p_subarray = Partition(A, new_left_left_boundary, new_left_right_boundary);
                Tuple<long, int[]> greater_p_subarray = Partition(A, new_right_left_boundary, new_right_right_boundary);
                comparisons += less_p_subarray.Item1;
                comparisons += greater_p_subarray.Item1;
                return new Tuple<long, int[]>(comparisons, A);
            }
        }
    }
}
