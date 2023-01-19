using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class List<T>
    {
        private const int DefaultCapacity = 4;

        private T[] items;
        private int count;

        public List()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        public int Capacity { get { return items.Length; } }
        public int Count { get { return count; } }

        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                Grow();
            }

            items[count] = item;
            count++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || count < index)
                throw new ArgumentOutOfRangeException();

            if (index == count)
            {
                Add(item);
                return;
            }

            if (count == items.Length)
            {
                Grow();
            }
            
            Array.Copy(items, index, items, index + 1, count - index);
            items[index] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || count <= index)
                throw new IndexOutOfRangeException();

            count--;
            Array.Copy(items, index + 1, items, index, count - index);
        }

        public int IndexOf(T item)
        {
            if (item != null)
            {
                for (int i = 0; i < count; i++)
                {
                    if (item.Equals(items[i]))
                    {
                        return i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (null == items[i])
                    {
                        return i;
                    }
                }
            }
            
            return -1;
        }

        public void Clear()
        {
            items = new T[DefaultCapacity];
            count = 0;
        }

        private void Grow()
        {
            T[] newItems = new T[items.Length * 2];
            Array.Copy(items, 0, newItems, 0, count);
            items = newItems;
        }
    }
}
