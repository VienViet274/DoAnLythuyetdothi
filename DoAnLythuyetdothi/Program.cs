// See https://aka.ms/new-console-template for more information
using DoAnLythuyetdothi;
using DoAnLythuyetdothi.Cau1;
using DoAnLythuyetdothi.Cau2;
using DoAnLythuyetdothi.Entities;
//Cau 1
int LoaiDoThi = DocDoThi.XacDinhDoThi();


if (LoaiDoThi == 0)
{
    GiauCau1.SolveDoThiVoHuong();
}
else
{
    GiauCau1.SolveDoThiCoHuong();
}
//Cau 2
string[] lines = File.ReadAllLines("D:\\File C#\\fileLyThuyetdothiCau2.txt");
int vertices = lines.Length;
Graph graph = new Graph(vertices);

for (int i = 0; i < vertices; i++)
{
    string[] parts = lines[i].Split(' ');
    int vertex = int.Parse(parts[0].Trim());
    int neighbor = int.Parse(parts[1].Trim());
    graph.AddEdge(vertex, neighbor);
    //if (parts.Length > 1)
    //{
    //    string[] neighbors = parts[1].Trim();
    //    foreach (var neighbor in neighbors)
    //    {
    //        graph.AddEdge(vertex, int.Parse(neighbor.Trim()));
    //    }
    //}
}
DepthFirstSearch dfs= new DepthFirstSearch();
Console.WriteLine("Recursive Depth-First Search:");
dfs.DFS(graph,7);
Console.WriteLine();
BreathFirstSearch bfs = new BreathFirstSearch();
Console.WriteLine("BFS Traversal:");
bfs.BFS(graph, 7);
ConnectedComponents ConnectedComponents = new ConnectedComponents();
bool isUndirected = ConnectedComponents.IsUndirectedGraph(graph);
if (!isUndirected)
{
    Console.WriteLine("Đồ thị không phải là đồ thị vô hướng.");
    
}

// Tìm số lượng và danh sách các thành phần liên thông
Console.WriteLine("Following are connected components:");
ConnectedComponents.GetConnectedComponents(graph);