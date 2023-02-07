using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._MinimumSpanningTree
{
	internal class Prim
	{
		/******************************************************
		 * Prim 최소신장트리 (Prim Minumum Spanning Tree)
		 * 
		 * 시작 정점에서부터 시작하여 신장트리 집합을 단계적으로 확장 해나가는 방법
		 ******************************************************/

		// <Prim 알고리즘>
		// 1. 시작 정점만을 최소신장트리 집합에 포함
		// 2. 가장 낮은 가중치의 간선과 연결된 정점을 집합에 추가
		// 단, 정점을 집합에 추가하는 과정에서 순환구조가 생기는 경우는 제외

		const int INF = 99999;

		public static void MinimumSpanningTree(in int[,] graph, in int start, out bool[] known, out int[] cost, out int[] path)
		{
			int edgeCount = 0;

			known = new bool[graph.GetLength(0)];
			cost = new int[graph.GetLength(0)];
			path = new int[graph.GetLength(0)];
			for (int i = 0; i < graph.GetLength(0); i++)
			{
				known[i] = false;
				cost[i] = INF;
				path[i] = -1;
			}

			// 1. 시작 정점만을 최소신장트리 집합에 포함
			PriorityQueue<Edge, int> edgePQ = new PriorityQueue<Edge, int>();
			known[start] = true;
			cost[start] = 0;
			path[start] = -1;
			AddEdges(graph, edgePQ , start);

			// 2. 가장 낮은 가중치의 간선과 연결된 정점을 집합에 추가
			while (edgePQ.Count > 0)
			{
				// 2-1. 다음 간선 확인
				Edge nextEdge = edgePQ.Dequeue();

				// 2-2. 이미 추가된 정점일 경우 생략
				if (known[nextEdge.end])
					continue;

				// 2-3. 간선에 연결된 정점을 추가
				known[nextEdge.end] = true;
				path[nextEdge.end] = nextEdge.start;
				cost[nextEdge.end] = graph[nextEdge.start, nextEdge.end];

				// 2-4. 연결된 정점이 가지는 간선을 우선순위큐에 추가
				AddEdges(graph, edgePQ, nextEdge.end);

				// 2-5. 모든 정점이 최소신장트리에 추가된 경우 완료
				edgeCount++;
				if (edgeCount >= graph.GetLength(0) - 1)
					break;
			}
		}

		private static void AddEdges(in int[,] graph, in PriorityQueue<Edge, int> pq, int vertex)
		{
			for (int i = 0; i < graph.GetLength(0); i++)
			{
				if (graph[vertex, i] <= 0 || graph[vertex, i] >= INF)
					continue;

				Edge edge = new Edge(vertex, i, graph[vertex, i]);
				pq.Enqueue(edge, edge.distance);
			}
		}

		private struct Edge
		{
			public int start;
			public int end;
			public int distance;

			public Edge(int start, int end, int distance)
			{
				this.start = start;
				this.end = end;
				this.distance = distance;
			}
		}
	}
}
