using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14._MinimumSpanningTree
{
	internal class Kruskal
	{
		/******************************************************
		 * Kruskal 최소신장트리 (Kruskal Minumum Spanning Tree)
		 * 
		 * 그래프 내의 모든 간선의 가중치를 확인하고,
		 * 가장 작은 가중치부터 최소신장트리에 포함
		 ******************************************************/

		// <Kruskal 알고리즘>
		// 1. 그래프 내의 모든 간선의 가중치를 오름차순으로 정렬
		// 2. 오름차순으로 정렬된 간선을 순서대로 최소신장트리에 추가
		// 단, 간선을 최소신장트리에 추가하는 과정에서 순환구조가 생기는 경우는 제외

		const int INF = 99999;

		public static int[,] MinimumSpanningTree(in int[,] graph)
		{
			int edgeCount = 0;

			// 0. 최소신장트리의 집합 초기화
			int[,] mst = new int[graph.GetLength(0), graph.GetLength(1)];
			for (int i = 0; i < mst.GetLength(0); i++)
				for (int j = 0; j < mst.GetLength(1); j++)
					mst[i, j] = i == j ? 0 : INF;

			// 트리의 순환구조를 체크하기 위한 배열
			int[] disjointSet = new int[mst.GetLength(0)];
			for (int i = 0; i < disjointSet.Length; i++)
				disjointSet[i] = -1;

			// 1. 그래프 내의 모든 간선의 가중치를 오름차순으로 정렬
			PriorityQueue<Edge, int> edgePQ = new PriorityQueue<Edge, int>();
			for (int start = 0; start < graph.GetLength(0); start++)
			{
				for (int end = 0; end < graph.GetLength(1); end++)
				{
					if (graph[start, end] <= 0 || graph[start, end] >= INF)
						continue;

					Edge edge = new Edge(start, end, graph[start, end]);
					edgePQ.Enqueue(edge, edge.distance);
				}
			}

			// 2. 오름차순으로 정렬된 간선을 순서대로 최소신장트리에 추가
			while (edgePQ.Count > 0)
			{
				// 2-1. 다음 간선 확인
				Edge nextEdge = edgePQ.Dequeue();

				// 2-2. 동일한 트리에 있는 경우 생략
				if (Find(disjointSet, nextEdge.start) == Find(disjointSet, nextEdge.end))
					continue;

				// 2-3. 간선을 연결하여 두 정점이 같은 트리 집합으로 연결
				Union(disjointSet, nextEdge.start, nextEdge.end);

				// 2-4. 연결한 간선을 최소신장트리에 추가
				mst[nextEdge.start, nextEdge.end] = graph[nextEdge.start, nextEdge.end];
				mst[nextEdge.end, nextEdge.start] = graph[nextEdge.start, nextEdge.end];

				// 2-5. 모든 정점이 최소신장트리에 추가된 경우 완료
				edgeCount++;
				if (edgeCount >= graph.GetLength(0) - 1)
					break;
			}

			return mst;
		}

		private static int Find(int[] disjointSet, int vertex)
		{
			int index = vertex;
			while (true)
			{
				if (disjointSet[index] < 0)
					break;
				index = disjointSet[index];
			}

			return index;
		}

		private static void Union(int[] disjointSet, int vertex1, int vertex2)
		{
			int left = Find(disjointSet, vertex1);
			int right = Find(disjointSet, vertex2);

			disjointSet[left] = right;
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
