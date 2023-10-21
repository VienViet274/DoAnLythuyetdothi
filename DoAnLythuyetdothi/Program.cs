// See https://aka.ms/new-console-template for more information
using DoAnLythuyetdothi;
using DoAnLythuyetdothi.Cau_3;
using DoAnLythuyetdothi.Cau_4;
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
    string[] lines = File.ReadAllLines(@"..\..\..\input.txt");
    int vertices = Convert.ToInt32(lines[0]);
    Graph graph = new Graph(vertices);

    for (int i = 1; i < vertices; i++)
    {
        string[] parts = lines[i].Split(' ');
        int vertex = i - 1;
        if (Convert.ToInt32(parts[0]) != 0)
        {
            for(int  j=0;j< parts.Length;j++)
            {
                if (j % 2 != 0)
                {
                    int neighbor = int.Parse(parts[j].Trim());
                    graph.AddEdge(vertex, neighbor);
                }
                
            }
            
        }
        
        
        
    }
    DepthFirstSearch dfs = new DepthFirstSearch();
    Console.WriteLine("Recursive Depth-First Search:");
    dfs.DFS(graph, 0);
    Console.WriteLine();
    BreathFirstSearch bfs = new BreathFirstSearch();
    Console.WriteLine("BFS Traversal:");
    bfs.BFS(graph, 0);
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
string filePath = @"..\..\..\input.txt";
try
{
    // Read the adjacency matrix from the input file
    string[] lines = File.ReadAllLines(filePath);
    int vertices = Convert.ToInt32(lines[0]);
    Graph graph = new Graph(vertices);

    for (int i = 1; i < vertices; i++)
    {
        string[] parts = lines[i].Split(' ');
        int vertex = i - 1;
        if (Convert.ToInt32(parts[0]) != 0)
        {
            for (int j = 0; j < parts.Length; j++)
            {
                if (j % 2 != 0)
                {
                    int neighbor = int.Parse(parts[j].Trim());
                    graph.AddEdge(vertex, neighbor);
                }

            }

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

//try
//{
    // Read the adjacency matrix from the input file
    string[] liness = File.ReadAllLines(filePath);
    DoThi gs = new DoThi();
    gs.TaoMaTranKe(@"..\..\..\input.txt");
    gs.XuatMaTranKe();
gs.Prim();
gs.Kruskal1();
    //int[][] graphs = new int[Convert.ToInt32(liness[0])][];
    //for (int i = 1; i <= Convert.ToInt32(liness[0]); i++)
    //{
    //    string[] values = liness[i].Split(' ');
    //    graphs[i-1] = new int[Convert.ToInt32(liness[0])];
    //for(int m = 0; m < graphs[i-1].Length; m++)
    //{
    //    graphs[i - 1][m] = 0;
    //}
    //  for (int j = 0; j < values.Length; j++)
    //    {
    //        bool flag = false;
    //        if (j % 2 != 0 && j <= graphs[i-1].Length)
    //        {
    //            graphs[i - 1][Convert.ToInt32(values[j])] = int.Parse(values[j+1]);
    //            flag = true;
    //        }
            
    //    }
        

    
    //}

    //// Create PrimMST object and run the Prim's MST algorithm
    //PrimAlgorithm primMST = new PrimAlgorithm(graphs);
    //primMST.PrimMSTAlgorithm();
//}
//catch (Exception ex)
//{
    //Console.WriteLine("An error occurred: " + ex.Message);
//}
//try
//{
//    // Read the adjacency matrix from the input file
//    string[] lines = File.ReadAllLines(filePath);
//    int[][] graph = new int[lines.Length][];
//    for (int i = 0; i < lines.Length; i++)
//    {
//        string[] values = lines[i].Split(' ');
//        graph[i] = new int[values.Length];
//        for (int j = 0; j < values.Length; j++)
//        {
//            graph[i][j] = int.Parse(values[j]);
//        }
//    }

//    KruskalAlgorithm kruskalMST = new KruskalAlgorithm(graph);
//    kruskalMST.KruskalMSTAlgorithm();
//}
//catch (Exception ex)
//{
//    Console.WriteLine("An error occurred: " + ex.Message);
//}
// Cau 4
try
{
    DoThi g = new DoThi();
    g.TaoMaTranKe(@"..\..\..\input.txt");
    g.XuatMaTranKe();
    Console.WriteLine("----------------------");
    //Câu 4:
    Console.Write($"Do thi co trong so duong: {g.DoThiCoTrongSoDuong()}\n");
    Console.WriteLine("----------------------");
    g.DuongDiNganNhatDijkstraToiTatCaCacDinh(0);
    Console.WriteLine("----------------------");
    g.DuongDiNganNhatBellmanToiTatCaCacDinh(0);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
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