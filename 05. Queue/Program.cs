using System;
using System.Collections.Generic;

namespace _05._Queue
{
	internal class Program
	{
		/******************************************************
		 * 큐 (Queue)
		 * 
		 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
		 * 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/

		void Queue()
		{
			Queue<int> queue = new Queue<int>();

			for (int i = 0; i < 5; i++) queue.Enqueue(i);					// 입력순서 : 0, 1, 2, 3, 4

			Console.WriteLine(queue.Peek());								// 최전방 : 0

			while (queue.Count > 0) Console.WriteLine(queue.Dequeue());		// 출력순서 : 0, 1, 2, 3, 4
		}

		static void Main(string[] args)
		{
			DataStructure.Queue<int> queue = new DataStructure.Queue<int>();

			for (int i = 0; i < 5; i++) queue.Enqueue(i);

			Console.WriteLine(queue.Peek());

			while (queue.Count > 0) Console.WriteLine(queue.Dequeue());     // 출력순서 : 0, 1, 2, 3, 4
		}
	}
}