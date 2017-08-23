using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCuts
{
    class MinCuts
    {
        public static int doMinCut(Dictionary<int, List<int>> AdjacentMatrix)
        {
            List<int> remaining_vertices = new List<int>();
            for (int i = 1; i <= 200; i++)
            {
                remaining_vertices.Add(i);
            }
            while (remaining_vertices.Count > 2)
            {
                int randomVertex = pickEdge(remaining_vertices);
                int randomAdjacentVertex = pickEdge(AdjacentMatrix[randomVertex]);
                //Remove all instances of adjacent vertex from random vertex since they are being combined
                AdjacentMatrix[randomVertex].RemoveAll(item => item == randomAdjacentVertex);
                //Remove all instances of random vertex from adjacent random vertex before adding it
                AdjacentMatrix[randomAdjacentVertex].RemoveAll(item => item == randomVertex);
                //go through all dictionary items and replace randomAdjacentVertex with randomVertex
                foreach (KeyValuePair<int, List<int>> entry in AdjacentMatrix)
                {
                    List<int> adjacentVertices = entry.Value;

                    for (int i = 0; i < adjacentVertices.Count; i++)
                        if (adjacentVertices[i] == randomAdjacentVertex)
                        {
                            adjacentVertices[i] = randomVertex;
                        }
                }
                //Append to Random Adjacent's vertices to Random Vertex's vertices 
                AdjacentMatrix[randomVertex].AddRange(AdjacentMatrix[randomAdjacentVertex]);
                //Remove Random Adjacent Vertex Entry from Dictionary
                AdjacentMatrix.Remove(randomAdjacentVertex);
                //remove randomly selected Adjacent Vertex from list of remaining vertices
                remaining_vertices.Remove(randomAdjacentVertex);
            }
            int final_count = AdjacentMatrix.Values.First().Count;
            return final_count;
        }

        public static int pickEdge(List<int> remaining_vertices)
        {
            Random r = new Random();
            IEnumerable<int> oneRandom = remaining_vertices.OrderBy(x => r.Next()).Take(1);
            return oneRandom.FirstOrDefault();
        }
    }
}
