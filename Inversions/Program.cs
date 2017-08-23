using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversions
{
    class Program
    {
        //testing github
        static void Main(string[] args)
        {
            //int count_inversions;
            string line;
            List<int> list_int = new List<int>();
            string path_file = "C:\\Users\\hmarkley\\Downloads\\IntegerArray.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(path_file);
            while ((line = file.ReadLine()) != null)
            {
               list_int.Add(Int32.Parse(line));
            }

            int[] array_int = list_int.ToArray();

            file.Close();

            Tuple<long, int[]> sorted_tuple = CountingInversions.mergeSort(array_int);
            int[] sorted_array = sorted_tuple.Item2;
            long count_inversions = sorted_tuple.Item1;
            
            // Suspend the screen.
            Console.WriteLine(count_inversions);
            Console.ReadLine();
        }
    }
}
