namespace _09._Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int count = 20;

            List<int> selectionList = new List<int>(count);
            List<int> insertionList = new List<int>(count);
            List<int> bubbleList = new List<int>(count);
            List<int> mergeList = new List<int>(count);
            List<int> quickList = new List<int>(count);
            List<int> heapList = new List<int>(count);
            List<int> introList = new List<int>(count);

            Console.WriteLine("랜덤 데이터 : ");
            for (int i = 0; i < count; i++)
            {
                int rand = random.Next() % 100;
                Console.Write($"{rand,3}");

                selectionList.Add(rand);
                insertionList.Add(rand);
                bubbleList.Add(rand);
                heapList.Add(rand);
                mergeList.Add(rand);
                quickList.Add(rand);
                introList.Add(rand);
            }
            Console.WriteLine();


            Console.WriteLine("선택 정렬 결과 : ");
            Sorting.SelectionSort(selectionList);
            foreach (int i in selectionList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("삽입 정렬 결과 : ");
            Sorting.InsertionSort(insertionList);
            foreach (int i in insertionList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("버블 정렬 결과 : ");
            Sorting.BubbleSort(bubbleList);
            foreach (int i in bubbleList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("합병 정렬 결과 : ");
            Sorting.MergeSort(mergeList);
            foreach (int i in mergeList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("퀵 정렬 결과 : ");
            Sorting.QuickSort(quickList);
            foreach (int i in quickList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("힙 정렬 결과 : ");
            Sorting.HeapSort(heapList);
            foreach (int i in heapList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();


            Console.WriteLine("인트로 정렬 결과 : ");
            introList.Sort();
            foreach (int i in introList)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();
        }
    }
}
