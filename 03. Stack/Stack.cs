using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    /******************************************************************
     * 어댑터 패턴 (Adapter)
     * 
     * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
     ******************************************************************/

    public class Stack<T>
    {
        private List<T> container;
        
        public Stack()
        {
            container = new List<T>();
        }
        
        public int Count { get { return container.Count; } }
        
        public void Push(T item)
        {
            container.Add(item);
        }
        
        public T Pop()
        {
            if (container.Count == 0)
                throw new InvalidOperationException();

            T item = container[container.Count - 1];
            container.RemoveAt(container.Count - 1);
            return item;
        }
        
        public T Peek()
        {
            if (container.Count == 0)
                throw new InvalidOperationException();

            return container[container.Count - 1];
        }
    }
}
