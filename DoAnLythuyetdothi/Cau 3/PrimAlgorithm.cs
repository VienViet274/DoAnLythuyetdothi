using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau_3
{
    public class PrimAlgorithm
    {


        private int V; // Number of vertices in the graph
        private int[][] graph;

        public PrimAlgorithm(int[][] g)
        {
            V = g.Length;
            graph = g;
        }

        // Find the minimum weighted edge
        private int MinKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int v = 0; v < V; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        public void PrimMSTAlgorithm()
        {
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {
                int u = MinKey(key, mstSet);

                mstSet[u] = true;

                for (int v = 0; v < V; v++)
                {
                    if (graph[u][v] != 0 && !mstSet[v] && graph[u][v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u][v];
                    }
                }
            }

            PrintMST(parent);
        }

        private void PrintMST(int[] parent)
        {
            int SumWeight = 0;
            Console.WriteLine("Edge \tWeight");

            for (int i = 1; i < V; i++)
            {
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i][parent[i]]);
                SumWeight += graph[i][parent[i]];
            }
            Console.WriteLine(SumWeight);
        }

    }
}
