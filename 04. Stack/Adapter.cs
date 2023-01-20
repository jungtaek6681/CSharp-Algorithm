using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	/******************************************************
	 * 어댑터 패턴 (Adapter)
	 * 
	 * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
	 ******************************************************/

	public class AdapterStack<T>
	{
		private LinkedList<T> container;

		public AdapterStack()
		{
			container = new LinkedList<T>();
		}

		public void Push(T item)
		{
			container.AddLast(item);
		}

		public T Pop()
		{
			T value = container.Last<T>();
			container.RemoveLast();
			return value;
		}
	}
}
