using DoAnLythuyetdothi.Cau2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLythuyetdothi.Cau_5
{
	public class Euler
	{
		public bool IsSimpleGraph(Graph graph)
		{
			for (int i = 0; i < graph.vertices; i++)
			{
				if (graph.adjacencyList[i].Contains(i) || graph.adjacencyList[i].Count != graph.adjacencyList[i].Distinct().Count())
				{
					return false;
				}
			}
			return true;
		}
		public bool IsEulerian(Graph graph)
		{
			// Kiểm tra xem tất cả các đỉnh có bậc chẵn hay không
			for (int i = 0; i < graph.vertices; i++)
			{
				if (graph.adjacencyList[i].Count % 2 != 0)
				{
					return false;
				}
			}
			return true;
		}
		public bool IsSemiEulerian(Graph graph)
		{
			// Kiểm tra xem có chính xác 2 đỉnh với bậc lẻ
			int oddDegreeCount = 0;
			for (int i = 0; i < graph.vertices; i++)
			{
				if (graph.adjacencyList[i].Count % 2 != 0)
				{
					oddDegreeCount++;
				}
			}
			return oddDegreeCount == 2;
		}
		public void FindEulerianPathCycle(Graph graph)
		{
			int V = graph.vertices;
			int startVertex = 0;
			for (int i = 0; i < V; i++)
			{
				if (graph.adjacencyList[i].Count % 2 != 0)
				{
					startVertex = i;
					break;
				}
			}

			Stack<int> stack = new Stack<int>();
			List<int> result = new List<int>();
			int currentVertex = startVertex;

			while (stack.Count > 0 || graph.adjacencyList[currentVertex].Count > 0)
			{
				if (graph.adjacencyList[currentVertex].Count == 0)
				{
					result.Add(currentVertex);
					currentVertex = stack.Pop();
				}
				else
				{
					int nextVertex = graph.adjacencyList[currentVertex][0];
					stack.Push(currentVertex);
					graph.adjacencyList[currentVertex].Remove(nextVertex);
					graph.adjacencyList[nextVertex].Remove(currentVertex);
					currentVertex = nextVertex;
				}
			}

			// Kiểm tra xem có chu trình Euler hay đường đi Euler
			if (result[0] == result[result.Count - 1])
			{
				Console.WriteLine("Chu trình Euler:");
				foreach (int vertex in result)
				{
					Console.Write(vertex + " ");
				}
			}
			else
			{
				Console.WriteLine("Đường đi Euler:");
				foreach (int vertex in result)
				{
					Console.Write(vertex + " ");
				}
			}
		}
	}

}
