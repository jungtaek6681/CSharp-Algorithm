namespace _11._ShortesPath
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

            Dijkstra.ShortestPath(graph, 0, out bool[] visited, out int[] distance, out int[] parents);
            PrintDijkstra(visited, distance, parents);
        }

        private static void PrintDijkstra(bool[] visited, int[] distance, int[] parents)
        {
            Console.WriteLine($"{"Vertex",-12}{"Visit",-12}{"Distance",-12}{"Parent",-12}");

            for (int i = 0; i < visited.Length; i++)
            {
                Console.Write($"{i,-12}");

                Console.Write($"{visited[i],-12}");

                if (distance[i] >= INF)
                {
                    Console.Write($"{"INF",-12}");
                }
                else
                {
                    Console.Write($"{distance[i],-12}");
                }

                Console.WriteLine($"{parents[i],-12}");
            }
        }
    }
}
