using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._Searching
{
	internal class Search
	{
		// <깊이 우선 탐색 (Depth-First Search)>
		// 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
		// 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색
		// 분할정복을 통해 구현
		public static void DFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
		{
			visited = new bool[graph.GetLength(0)];
			parents = new int[graph.GetLength(0)];

			for (int i = 0; i < graph.GetLength(0); i++)
			{
				visited[i] = false;
				parents[i] = -1;
			}

			SearchNode(graph, start, visited, parents);
		}

		private static void SearchNode(in bool[,] graph, int start, bool[] visited, int[] parents)
		{
			visited[start] = true;
			for (int i = 0; i < graph.GetLength(0); i++)
			{
				if (graph[start, i] &&		// 연결되어 있는 정점이며,
					!visited[i])			// 방문한적 없는 정점
				{
					parents[i] = start;
					SearchNode(graph, i, visited, parents);
				}
			}
		}

		// <너비 우선 탐색 (Breadth-First Search)>
		// 그래프의 분기를 만났을 때 모든 분기를 저장한 뒤,
		// 저장한 분기를 하나씩 탐색
		// 동적계획법을 통해 구현
		public static void BFS(in bool[,] graph, int start, out bool[] visited, out int[] parents)
		{
			visited = new bool[graph.GetLength(0)];
			parents = new int[graph.GetLength(0)];

			for (int i = 0; i < graph.GetLength(0); i++)
			{
				visited[i] = false;
				parents[i] = -1;
			}

			Queue<int> bfsQueue = new Queue<int>();

			bfsQueue.Enqueue(start);
			while (bfsQueue.Count > 0)
			{
				int next = bfsQueue.Dequeue();
				visited[next] = true;

				for (int i = 0; i < graph.GetLength(0); i++)
				{ 
					if (graph[next, i] &&		// 연결되어 있는 정점이며,
						!visited[i])			// 방문한적 없는 정점
					{
						parents[i] = next;
						bfsQueue.Enqueue(i);
					}
				}
			}
		}
	}
}
