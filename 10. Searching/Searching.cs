using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Searching
{
    internal class Searching
    {
        // <순차 탐색>
        // 자료구조에서 순차적으로 찾고자 하는 데이터를 탐색
        // 시간복잡도 - O(n)
        public static int SequentialSearch<T>(IList<T> list, in T item) where T : notnull
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }


        // <이진 탐색>
        // 정렬이 되어있는 자료구조에서 2분할을 통해 데이터를 탐색
        // 단, 이진 탐색은 정렬이 되어 있는 자료에만 적용 가능
        // 시간복잡도 - O(logn)
        public static int BinarySearch<T>(IList<T> list, in T item) where T : IComparable<T>
        {
            int low = 0;
            int high = list.Count - 1;
            while (low <= high)
            {
                int middle = (low + high) / 2;
                int compare = list[middle].CompareTo(item);

                if (compare < 0)
                {
                    low = middle + 1;
                }
                else if (compare > 0)
                {
                    high = middle - 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }


        // <깊이 우선 탐색 (Depth-First Search)>
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤,
        // 분기의 탐색을 마쳤을 때 다음 분기를 탐색
        // 스택을 통해 구현
        public static void DFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            parents = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            SearchNode(graph, start, visited, parents);
        }

        private static void SearchNode(bool[,] graph, int vertex, bool[] visited, int[] parents)
        {
            int size = graph.GetLength(0);
            visited[vertex] = true;
            for (int i = 0; i < size; i++)
            {
                if (graph[vertex, i] &&     // 연결되어 있는 정점이며,
                    !visited[i])            // 방문한적 없는 정점
                {
                    parents[i] = vertex;
                    SearchNode(graph, i, visited, parents);
                }
            }
        }


        // <너비 우선 탐색 (Breadth-First Search)>
        // 그래프의 분기를 만났을 때 모든 분기들을 탐색한 뒤,
        // 다음 깊이의 분기들을 탐색
        // 큐를 통해 탐색
        public static void BFS(bool[,] graph, int start, out bool[] visited, out int[] parents)
        {
            int size = graph.GetLength(0);
            visited = new bool[size];
            parents = new int[size];

            for (int i = 0; i < size; i++)
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int next = queue.Dequeue();

                for (int i = 0; i < size; i++)
                {
                    if (graph[next, i] &&       // 연결되어 있는 정점이며,
                        !visited[i])            // 방문한적 없는 정점
                    {
                        visited[i] = true;
                        parents[i] = next;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
