using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //int count_inversions;
            string line;
            List<int> list_int = new List<int>();
            string path_file = "C:\\Users\\hmarkley\\Documents\\QuickSort.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(path_file);
            while ((line = file.ReadLine()) != null)
            {
                list_int.Add(Int32.Parse(line));
            }

            int[] array_int = list_int.ToArray();
            file.Close();
            Tuple<long, int[]> sorted_tuple = QuickSort.doQuickSort(array_int);
            Console.ReadLine();
        }

        
    }
}
