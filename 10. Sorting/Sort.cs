using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._Sorting
{
	internal class Sort
	{
		/******************************************************
		 * 선형 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n개를 확인하는 정렬
		 * 시간복잡도 : O(N^2)
		 ******************************************************/

		// <선택정렬>
		// 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
		public static void SelectionSort(IList<int> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				int minIndex = i;
				for (int j = i + 1; j < list.Count; j++)
				{
					if (list[j] < list[minIndex])
						minIndex = j;
				}
				Swap(list, i, minIndex);
			}
		}

		// <삽입정렬>
		// 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
		public static void InsertionSort(IList<int> list)
		{
			for (int i = 1; i < list.Count; i++)
			{
				int key = list[i];
				int j;
				for (j = i - 1; j >= 0 && key < list[j]; j--)
				{
					list[j + 1] = list[j];
				}
				list[j + 1] = key;
			}
		}

		// <버블정렬>
		// 서로 인접한 데이터를 비교하여 정렬
		public static void BubbleSort(IList<int> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 1; j < list.Count; j++)
				{
					if (list[j - 1] > list[j])
						Swap(list, j - 1, j);
				}
			}
		}

		/******************************************************
		 * 분할정복 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체의 1/2를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n/2개를 확인하는 정렬
		 * 시간복잡도 : O(NlogN)
		 ******************************************************/

		// <합병정렬>
		// 데이터를 2분할하여 정렬 후 합병
		public static void MergeSort(IList<int> list, int left, int right)
		{
			if (left == right) return;

			int mid = (left + right) / 2;
			MergeSort(list, left, mid);
			MergeSort(list, mid + 1, right);
			Merge(list, left, mid, right);
		}

		public static void Merge(IList<int> list, int left, int mid, int right)
		{
			List<int> sortedList = new List<int>();
			int leftIndex = left;
			int rightIndex = mid + 1;

			// 분할 정렬된 List를 병합
			while (leftIndex <= mid && rightIndex <= right)
			{
				if (list[leftIndex] < list[rightIndex])
					sortedList.Add(list[leftIndex++]);
				else
					sortedList.Add(list[rightIndex++]);
			}

			if (leftIndex > mid)    // 왼쪽 List가 먼저 소진 됐을 경우
			{
				for (int i = rightIndex; i <= right; i++)
					sortedList.Add(list[i]);
			}
			else  // 오른쪽 List가 먼저 소진 됐을 경우
			{
				for (int i = leftIndex; i <= mid; i++)
					sortedList.Add(list[i]);
			}

			// 정렬된 sortedList를 list로 재복사
			for (int i = left; i <= right; i++)
			{
				list[i] = sortedList[i - left];
			}
		}

		// <퀵정렬>
		// 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
		public static void QuickSort(IList<int> list, int start, int end)
		{
			if (start >= end) return;

			int pivotIndex = start;
			int leftIndex = pivotIndex + 1;
			int rightIndex = end;

			while (leftIndex <= rightIndex) // 엇갈릴때까지 반복
			{
				// pivot보다 큰 값을 만날때까지
				while (list[leftIndex] <= list[pivotIndex] && leftIndex < end)
					leftIndex++;
				while (list[rightIndex] >= list[pivotIndex] && rightIndex > start)
					rightIndex--;

				if (leftIndex < rightIndex)     // 엇갈리지 않았다면
					Swap(list, leftIndex, rightIndex);
				else	// 엇갈렸다면
					Swap(list, pivotIndex, rightIndex);
			}

			QuickSort(list, start, rightIndex - 1);
			QuickSort(list, rightIndex + 1, end);
		}


		private static void Swap(IList<int> list, int left, int right)
		{
			int temp = list[left];
			list[left] = list[right];
			list[right] = temp;
		}
	}
}
