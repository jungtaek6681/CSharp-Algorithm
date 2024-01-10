namespace _10._Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 순차탐색
            int index1;
            int index2;
            int[] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };
            Console.Write("배열 : ");
            foreach (int i in array)
            {
                Console.Write($"{i,2}");
            }
            Console.WriteLine();

            index1 = Array.IndexOf(array, 2);
            index2 = Searching.SequentialSearch(array, 2);
            Console.WriteLine($"순차탐색 결과 위치 : {index1}");
            Console.WriteLine($"구현한 순차탐색 결과 위치 : {index2}");
            Console.WriteLine();


            // 이진탐색
            index1 = Array.BinarySearch(array, 2);
            index2 = Searching.BinarySearch(array, 2);
            Console.WriteLine("정렬 전 결과");
            Console.WriteLine($"이진탐색 결과 위치 : {index1}");
            Console.WriteLine($"구현한 이진탐색 결과 위치 : {index2}");
            Console.WriteLine();

            Array.Sort(array);  // 이진탐색의 경우 우선 정렬이 필요
            Console.Write("정렬된 배열 : ");
            foreach (int i in array)
            {
                Console.Write($"{i,2}");
            }
            Console.WriteLine();

            index1 = Array.BinarySearch(array, 2);
            index2 = Searching.BinarySearch(array, 2);
            Console.WriteLine("정렬 후 결과");
            Console.WriteLine($"이진탐색 결과 위치 : {index1}");
            Console.WriteLine($"구현한 이진탐색 결과 위치 : {index2}");
            Console.WriteLine();


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
            Console.WriteLine("<DFS>");
            Searching.DFS(graph, 0, out bool[] dfsVisited, out int[] dfsParents);
            PrintGraphSearch(dfsVisited, dfsParents);
            Console.WriteLine();


            // BFS 탐색
            Console.WriteLine("<BFS>");
            Searching.BFS(graph, 0, out bool[] bfsVisited, out int[] bfsParents);
            PrintGraphSearch(bfsVisited, bfsParents);
            Console.WriteLine();
        }

        private static void PrintGraphSearch(bool[] visited, int[] parents)
        {
            Console.WriteLine($"{"Vertex",8}{"Visit",8}{"Parent",8}");

            for (int i = 0; i < visited.Length; i++)
            {
                Console.WriteLine($"{i,8}{visited[i],8}{parents[i],8}");
            }
        }
    }
}
