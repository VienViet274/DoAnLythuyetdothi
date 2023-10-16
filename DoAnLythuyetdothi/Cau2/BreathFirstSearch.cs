using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau2
{
    public class BreathFirstSearch
    {
        private bool[] visited;
        private int[] parent;

        public void BFS(Graph graph, int source)
        {
            visited = new bool[graph.vertices];
            parent = new int[graph.vertices];

            Queue<int> queue = new Queue<int>();
            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                int vertex = queue.Dequeue();
                Console.Write(vertex + " ");

                foreach (int neighbor in graph.adjacencyList[vertex])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        parent[neighbor] = vertex;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
}
