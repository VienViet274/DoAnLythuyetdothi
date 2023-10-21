using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau2
{
	public class Graph
	{
        public int vertices;              // Number of vertices
        public List<int>[] adjacencyList; // Adjacency list representation

        public Graph(int v)
        {
            vertices = v;
            adjacencyList = new List<int>[v];
            for (int i = 0; i < v; i++)
                adjacencyList[i] = new List<int>();
        }

        public void AddEdge(int v, int w)
        {
            adjacencyList[v].Add(w);
            adjacencyList[w].Add(v);
		}

        
    }
}
