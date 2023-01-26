using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _07._BinarySearchTree
{
	internal class Program
	{
		/******************************************************
		 * 트리 (Tree)
		 * 
		 * 계층적인 자료를 나타내는데 자주 사용되는 자료구조
		 * 부모노드가 0개 이상의 자식노드들을 가질 수 있음
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없음
		 ******************************************************/

		/******************************************************
		 * 이진탐색트리 (BinarySearchTree)
		 * 
		 * 이진속성과 탐색속성을 적용한 트리
		 * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
		 * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
		 * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치
		 ******************************************************/

		// <이진탐색트리의 시간복잡도>
		// 접근			탐색			삽입			삭제
		// O(log n)		O(log n)	O(log n)	O(log n)

		// <이진탐색트리의 주의점>
		// 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
		// 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
		// 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
		// 대표적인 방식으로 Red-Black Tree, AVL Tree 등이 있음

		void BinarySearchTree()
		{
			// value 이진탐색트리
			SortedSet<int> sortedSet = new SortedSet<int>();

			sortedSet.Add(1);
			sortedSet.Add(2);
			sortedSet.Add(3);
			sortedSet.Add(4);
			sortedSet.Add(5);

			int searchValue1;
			sortedSet.TryGetValue(3, out searchValue1);				// 탐색 시도
			
			// key, value 이진탐색트리
			SortedDictionary<int, string> sortedDictionary = new SortedDictionary<int, string>();

			sortedDictionary.Add(1, "a");
			sortedDictionary.Add(2, "b");
			sortedDictionary.Add(3, "c");
			sortedDictionary.Add(4, "d");
			sortedDictionary.Add(5, "e");

			string searchValue2;
			sortedDictionary.TryGetValue(3, out searchValue2);		// 탐색 시도
			string indexerValue2 = sortedDictionary[3];				// 인덱서를 통한 탐색


			// 이진탐색 검색효율
			int[] array = new int[10000000];
			SortedSet<int> set = new SortedSet<int>();

			Random random = new Random();
			int rand;
			for (int i = 0; i < 1000000; i++)
			{
				rand = random.Next();
				array[i] = rand;
				set.Add(rand);
			}
			array[9999999] = -1;
			set.Add(-1);

			Stopwatch stopwatch = new Stopwatch();

			stopwatch.Start();
			Array.Find(array, (x) => x == -1);
			stopwatch.Stop();
			Console.WriteLine("배열 time : {0}", stopwatch.ElapsedTicks);

			stopwatch.Restart();
			int value;
			set.TryGetValue(-1, out value);
			stopwatch.Stop();
			Console.WriteLine("트리 time : {0}", stopwatch.ElapsedTicks);
		}

		static void Main(string[] args)
		{
			DataStructure.BinarySearchTree<int> bst = new DataStructure.BinarySearchTree<int>();

			bst.Add(3);
			bst.Add(1);
			bst.Add(5);
			bst.Add(2);
			bst.Add(4);
			bst.Add(6);

			bst.Remove(3);
			bst.Remove(4);
		}
	}
}