using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCuts
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<int, List<int>> test_matrix = new Dictionary<int, List<int>>()
            {

                { 1, new List<int> { 2, 3 } },
                { 2, new List<int> { 1, 3, 4 } },
                { 3, new List<int> { 1, 2, 4 } },
                { 4, new List<int> { 2, 3 } },
            };

            int min_cut = 100000000;
            for (int j = 0; j < 500; j++)
            {
                string line;
                Dictionary<int, List<int>> AdjacentMatrix = new Dictionary<int, List<int>>();

                string path_file = "C:\\Users\\hmarkley\\Downloads\\kargerMinCut.txt";
                System.IO.StreamReader file = new System.IO.StreamReader(path_file);
                while ((line = file.ReadLine()) != null)
                {
                    var words = line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    List<int> edges = new List<int>();
                    for (int i = 1; i < words.Length; i++)
                    {
                        edges.Add(Int32.Parse(words[i]));
                    }
                    AdjacentMatrix[Int32.Parse(words[0])] = edges;
                }

                file.Close();

                int random_min_cut = MinCuts.doMinCut(AdjacentMatrix);
                if (random_min_cut < min_cut)
                {
                    min_cut = random_min_cut;
                }
            }

            Console.WriteLine(min_cut);

            Console.ReadLine();
        }
    }
}
