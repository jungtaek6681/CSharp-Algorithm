using System;

namespace _14._MinimumSpanningTree
{
	internal class Program
	{
		/******************************************************
		 * 최소신장트리 (Minumum Spanning Tree)
		 * 
		 * 그래프 내의 모든 정점을 포함하는 트리 중 사용된 간선들의 가중치 합이 최소인 트리
		 * 신장트리는 N개의 정점을 N-1개의 간선으로 연결하며 순환구조가 없음
		 ******************************************************/

		const int INF = 99999;

		static void Main(string[] args)
		{
			int[,] graph =
			{
				{   0, INF, INF,   4, INF, INF, INF, INF },
				{ INF,   0, INF,   9, INF, INF, INF, INF },
				{ INF, INF,   0, INF,   6,   8,   8, INF },
				{   4,   9, INF,   0, INF,   4, INF,   4 },
				{ INF, INF,   6, INF,   0, INF,   5, INF },
				{ INF, INF,   8,   4, INF,   0, INF,   1 },
				{ INF, INF,   8, INF,   5, INF,   0,   2 },
				{ INF, INF, INF,   4, INF,   1,   2,   0 },
			};

			int[,] kruskalMST = Kruskal.MinimumSpanningTree(graph);
			Console.WriteLine("<Kruskal MST>");
			PrintKruskalResult(kruskalMST);
			Console.WriteLine();

			bool[] known;
			int[] cost;
			int[] path;
			Prim.MinimumSpanningTree(graph, 0, out known, out cost, out path);
			Console.WriteLine("<Prim MST>");
			PrintPrimResult(known, cost, path);
			Console.WriteLine();
		}

		private static void PrintKruskalResult(int[,] mst)
		{
			for (int y = 0; y < mst.GetLength(0); y++)
			{
				for (int x = 0; x < mst.GetLength(1); x++)
				{
					if (mst[y, x] >= INF)
						Console.Write(" INF ");
					else
						Console.Write(" {0:D3} ", mst[y, x]);
				}
				Console.WriteLine();
			}
		}

		private static void PrintPrimResult(bool[] known, int[] cost, int[] path)
		{
			Console.Write("Vertex");
			Console.Write("\t");
			Console.Write("Known");
			Console.Write("\t");
			Console.Write("Cost");
			Console.Write("\t");
			Console.WriteLine("Path");

			for (int i = 0; i < known.Length; i++)
			{
				Console.Write(i);
				Console.Write("\t");
				Console.Write(known[i]);
				Console.Write("\t");
				Console.Write(cost[i]);
				Console.Write("\t");
				Console.WriteLine(path[i]);
			}
		}
	}
}