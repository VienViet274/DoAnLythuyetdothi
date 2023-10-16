using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau2
{
	public class DepthFirstSearch
	{
        public void DFSUtil(Graph graph,int v, bool[] visited)
        {
            visited[v] = true;
            Console.Write(v + " ");

            foreach (int neighbor in graph.adjacencyList[v])
            {
                if (!visited[neighbor])
                    DFSUtil(graph,neighbor, visited);
            }
        }

        public void DFS(Graph graph, int startVertex)
        {
            bool[] visited = new bool[graph.vertices];
            DFSUtil(graph, startVertex, visited);
        }
    }
}
