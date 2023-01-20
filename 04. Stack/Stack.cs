using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	public class Stack<T>
	{
		private const int DefaultCapacity = 4;

		private T[] array;
		private int topIndex;

		public Stack()
		{
			array = new T[DefaultCapacity];
			topIndex = -1;
		}

		public int Count { get { return topIndex + 1; } }

		public void Clear()
		{
			array = new T[DefaultCapacity];
			topIndex = -1;
		}

		public T Peek()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[topIndex];
		}

		public bool TryPeek(out T result)
		{
			if (IsEmpty())
			{
				result = default(T);
				return false;
			}
			else
			{
				result = array[topIndex];
				return true;
			}
		}

		public T Pop()
		{
			if (IsEmpty())
				throw new InvalidOperationException();

			return array[topIndex--];
		}

		public bool TryPop(out T result)
		{
			if (IsEmpty())
			{
				result = default(T);
				return false;
			}
			else
			{
				result = array[topIndex--];
				return true;
			}
		}

		public void Push(T item)
		{
			if (IsFull())
			{
				Grow();
			}
			array[++topIndex] = item;
		}

		private void Grow()
		{
			int newCapacity = array.Length * 2;
			T[] newArray = new T[newCapacity];
			Array.Copy(array, 0, newArray, 0, Count);
			array = newArray;
		}

		private bool IsEmpty()
		{
			return Count == 0;
		}

		private bool IsFull()
		{
			return Count == array.Length;
		}
	}
}
