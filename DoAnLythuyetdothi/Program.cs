// See https://aka.ms/new-console-template for more information
using DoAnLythuyetdothi;
using DoAnLythuyetdothi.Cau_3;
using DoAnLythuyetdothi.Cau_5;
using DoAnLythuyetdothi.Cau1;
using DoAnLythuyetdothi.Cau2;
using DoAnLythuyetdothi.Entities;
//Cau 1
try
{
    int LoaiDoThi = DocDoThi.XacDinhDoThi();


    if (LoaiDoThi == 0)
    {
        GiauCau1.SolveDoThiVoHuong();
    }
    else
    {
        GiauCau1.SolveDoThiCoHuong();
    }
}
catch(Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}


//Cau 2
try
{
    string[] lines = File.ReadAllLines("D:\\File C#\\fileLyThuyetdothiCau2.txt");
    int vertices = lines.Length;
    Graph graph = new Graph(vertices);

    for (int i = 0; i < vertices; i++)
    {
        string[] parts = lines[i].Split(' ');
        int vertex = int.Parse(parts[0].Trim());
        int neighbor = int.Parse(parts[1].Trim());
        graph.AddEdge(vertex, neighbor);
        
    }
    DepthFirstSearch dfs = new DepthFirstSearch();
    Console.WriteLine("Recursive Depth-First Search:");
    dfs.DFS(graph, 7);
    Console.WriteLine();
    BreathFirstSearch bfs = new BreathFirstSearch();
    Console.WriteLine("BFS Traversal:");
    bfs.BFS(graph, 7);
    Console.WriteLine();
    ConnectedComponents ConnectedComponents = new ConnectedComponents();
    bool isUndirected = ConnectedComponents.IsUndirectedGraph(graph);
    if (!isUndirected)
    {
        Console.WriteLine("Do thi la do thi co huong");

    }
    else
    {
        Console.WriteLine("Do thi la do thi vo huong");
    }

    // Tìm số lượng và danh sách các thành phần liên thông
    Console.WriteLine("Following are connected components:");
    ConnectedComponents.GetConnectedComponents(graph);
}
catch(Exception ex)
{
    Console.WriteLine("An error occurred: "+ ex.Message);
}
//Cau 3
string filePath = "D:\\File C#\\fileLyThuyetdothiCau3.txt";
try
{
    // Read the adjacency matrix from the input file
    string[] lines = File.ReadAllLines(filePath);
    int vertices = lines.Length;

    Graph graph = new Graph(vertices);

    for (int i = 0; i < vertices; i++)
    {
        string[] values = lines[i].Split(' ');
        for (int j = 0; j < vertices; j++)
        {
            int weight = int.Parse(values[j]);
            if (weight != 0)
                graph.AddEdge(i, j);
        }
    }
    ConnectedComponents connectedComponents= new ConnectedComponents();
    bool isConnected =connectedComponents.IsUndirectedGraph(graph) ;
    Console.WriteLine("Is the graph connected: " + isConnected);
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}

try
{
    // Read the adjacency matrix from the input file
    string[] lines = File.ReadAllLines(filePath);
    int[][] graph = new int[lines.Length][];
    for (int i = 0; i < lines.Length; i++)
    {
        string[] values = lines[i].Split(' ');
        graph[i] = new int[values.Length];
        for (int j = 0; j < values.Length; j++)
        {
            graph[i][j] = int.Parse(values[j]);
        }
    }

    // Create PrimMST object and run the Prim's MST algorithm
    PrimAlgorithm primMST = new PrimAlgorithm(graph);
    primMST.PrimMSTAlgorithm();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
try
{
    // Read the adjacency matrix from the input file
    string[] lines = File.ReadAllLines(filePath);
    int[][] graph = new int[lines.Length][];
    for (int i = 0; i < lines.Length; i++)
    {
        string[] values = lines[i].Split(' ');
        graph[i] = new int[values.Length];
        for (int j = 0; j < values.Length; j++)
        {
            graph[i][j] = int.Parse(values[j]);
        }
    }

    KruskalAlgorithm kruskalMST = new KruskalAlgorithm(graph);
    kruskalMST.KruskalMSTAlgorithm();
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
//Cau 5
string fileName = "D:\\File C#\\fileLyThuyetdothiCau5.txt"; // Tên tệp văn bản chứa danh sách kề

try
{
	string[] lines = File.ReadAllLines(fileName);
	int V = lines.Length;
	Graph graph = new Graph(V);
    Euler euler = new Euler();

	for (int i = 0; i < V; i++)
	{
		int[] neighbors = lines[i].Split(' ').Select(int.Parse).ToArray(); ;
		foreach (int neighbor in neighbors)
		{
			graph.AddEdge(i, neighbor);
		}
	}
	if (euler.IsSimpleGraph(graph))
	{
		Console.WriteLine("Đồ thị là đơn đồ thị.");
	}
	else
	{
		Console.WriteLine("Đồ thị không phải là đơn đồ thị.");
	}

	if (euler.IsEulerian(graph))
	{
		Console.WriteLine("Đồ thị là Eulerian.");
		euler.FindEulerianPathCycle(graph);
	}
	else if (euler.IsSemiEulerian(graph))
	{
		Console.WriteLine("Đồ thị là nửa Euler.");
		euler.FindEulerianPathCycle(graph);
	}
	else
	{
		Console.WriteLine("Đồ thị không phải Eulerian hoặc nửa Euler.");
	}
}
catch (Exception e)
{
	Console.WriteLine("Lỗi: " + e.Message);
}