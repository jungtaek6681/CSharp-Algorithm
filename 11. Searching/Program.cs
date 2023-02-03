using System;

namespace _11._Searching
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool[,] graph = new bool[8, 8]
			{
				{ false,  true, false, false, false, false, false, false },
				{  true, false,  true, false, false,  true, false, false },
				{ false,  true, false, false,  true,  true, false, false },
				{ false, false, false, false, false,  true, false, false },
				{ false, false,  true, false, false, false,  true,  true },
				{ false,  true,  true,  true, false, false, false, false },
				{ false, false, false, false,  true, false, false, false },
				{ false, false, false, false,  true, false, false, false },
			};

			// DFS 탐색
			bool[] dfsVisited;
			int[] dfsPath;
			Search.DFS(in graph, 0, out dfsVisited, out dfsPath);
			Console.WriteLine("<DFS>");
			PrintResult(dfsVisited, dfsPath);
			Console.WriteLine();

			// BFS 탐색
			bool[] bfsVisited;
			int[] bfsPath;
			Search.BFS(in graph, 0, out bfsVisited, out bfsPath);
			Console.WriteLine("<BFS>");
			PrintResult(bfsVisited, bfsPath);
			Console.WriteLine();
		}

		private static void PrintResult(bool[] dfsVisited, int[] dfsPath)
		{
			Console.Write("Vertex");
			Console.Write("\t");
			Console.Write("Visit");
			Console.Write("\t");
			Console.WriteLine("Path");

			for (int i = 0; i < dfsVisited.Length; i++)
			{
				Console.Write(i);
				Console.Write("\t");
				Console.Write(dfsVisited[i]);
				Console.Write("\t");
				Console.WriteLine(dfsPath[i]);
			}
		}
	}
}