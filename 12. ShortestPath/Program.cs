namespace _12._ShortestPath
{
	internal class Program
	{
		const int INF = 99999;

		static void Main(string[] args)
		{
			int[,] graph = new int[9, 9]
			{
				{   0, INF,   1,   7, INF, INF, INF,   5, INF},
				{ INF,   0, INF, INF, INF,   4, INF, INF, INF},
				{ INF, INF,   0, INF, INF, INF, INF, INF, INF},
				{   5, INF, INF,   0, INF, INF, INF, INF, INF},
				{ INF, INF,   9, INF,   0, INF, INF, INF,   2},
				{   1, INF, INF, INF, INF,   0, INF,   6, INF},
				{ INF, INF, INF, INF, INF, INF,   0, INF, INF},
				{   1, INF, INF, INF,   4, INF, INF,   0, INF},
				{ INF,   5, INF,   2, INF, INF, INF, INF,   0}
			};

			int[] distance;
			int[] path;
			Dijkstra.ShortestPath(in graph, 0, out distance, out path);
			Console.WriteLine("<Dijkstra>");
			PrintResult(distance, path);
		}

		private static void PrintResult(int[] distance, int[] path)
		{
			Console.Write("Vertex");
			Console.Write("\t");
			Console.Write("dist");
			Console.Write("\t");
			Console.WriteLine("path");

			for (int i = 0; i < distance.Length; i++)
			{
				Console.Write(i);
				Console.Write("\t");
				if (distance[i] >= INF)
					Console.Write("INF");
				else
					Console.Write("{0:D3}", distance[i]);
				Console.Write("\t");
				Console.WriteLine(path[i]);
			}
		}
	}
}