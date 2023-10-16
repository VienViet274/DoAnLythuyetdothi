using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau2
{
    public class ConnectedComponents
    {
        public bool IsUndirectedGraph(Graph graph)
        {
            for (int i = 0; i < graph.vertices; i++)
            {
                foreach (int neighbor in graph.adjacencyList[i])
                {
                    if (!graph.adjacencyList[neighbor].Contains(i))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void GetConnectedComponents(Graph graph)
        {
            // Mark all the vertices as not visited
            bool[] visited = new bool[graph.vertices];
            DepthFirstSearch dfs= new DepthFirstSearch();
            for (int v = 0; v < graph.vertices; ++v)
            {
                if (!visited[v])
                {
                    // print all reachable vertices
                    // from v
                    dfs.DFSUtil(graph,v, visited);
                    Console.WriteLine();
                }
            }
        }
    }
}
