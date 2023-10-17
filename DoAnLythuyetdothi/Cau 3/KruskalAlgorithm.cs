using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau_3
{
    public class KruskalAlgorithm
    {
        private int V; // Number of vertices in the graph
        private int[][] graph;

        public KruskalAlgorithm(int[][] g)
        {
            V = g.Length;
            graph = g;
        }

        private int Find(int[] parent, int vertex)
        {
            if (parent[vertex] != vertex)
                parent[vertex] = Find(parent, parent[vertex]);
            return parent[vertex];
        }

        private void Union(int[] parent, int[] rank, int x, int y)
        {
            int xRoot = Find(parent, x);
            int yRoot = Find(parent, y);

            if (xRoot == yRoot)
                return;

            if (rank[xRoot] < rank[yRoot])
                parent[xRoot] = yRoot;
            else if (rank[xRoot] > rank[yRoot])
                parent[yRoot] = xRoot;
            else
            {
                parent[yRoot] = xRoot;
                rank[xRoot]++;
            }
        }

        public void KruskalMSTAlgorithm()
        {
            int SumWeight = 0;
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < V; i++)
            {
                for (int j = i; j < V; j++)
                {
                    if (graph[i][j] != 0)
                    {
                        Edge edge = new Edge
                        {
                            Source = i,
                            Destination = j,
                            Weight = graph[i][j]
                        };
                        edges.Add(edge);
                    }
                }
            }

            edges = edges.OrderBy(e => e.Weight).ToList();
            int[] parent = new int[V];
            int[] rank = new int[V];

            for (int i = 0; i < V; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }

            List<Edge> minimumSpanningTree = new List<Edge>();

            foreach (Edge edge in edges)
            {
                int rootX = Find(parent, edge.Source);
                int rootY = Find(parent, edge.Destination);

                if (rootX != rootY)
                {
                    minimumSpanningTree.Add(edge);
                    Union(parent, rank, rootX, rootY);
                }
            }

            Console.WriteLine("Minimum Spanning Tree (Kruskal's algorithm):");
            foreach (Edge edge in minimumSpanningTree)
            {
                Console.WriteLine($"{edge.Source} - {edge.Destination} \tWeight: {edge.Weight}");
                SumWeight += edge.Weight;
            }
            
            Console.WriteLine(SumWeight);
        }
    }
}
