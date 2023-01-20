using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
	public class LinkedListNode<T>
	{
		internal LinkedList<T> list;
		internal LinkedListNode<T> prev;
		internal LinkedListNode<T> next;
		private T item;

		public LinkedListNode(T value)
		{
			this.list = null;
			this.prev = null;
			this.next = null;
			this.item = value;
		}

		public LinkedListNode(LinkedList<T> list, T value)
		{
			this.list = list;
			this.prev = null;
			this.next = null;
			this.item = value;
		}

		public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
		{
			this.list = list;
			this.prev = prev;
			this.next = next;
			this.item = value;
		}

		public LinkedList<T> List { get { return list; } }
		public LinkedListNode<T> Prev { get { return prev; } }
		public LinkedListNode<T> Next { get { return next; } }

		public T Item { get { return item; } set { item = value; } }
	}

	public class LinkedList<T> : IEnumerable<T>
	{
		private LinkedListNode<T> head;
		private LinkedListNode<T> tail;
		private int count;

		public LinkedList()
		{
			this.head = null;
			this.tail = null;
			count = 0;
		}

		public LinkedListNode<T> First { get { return head; } }
		public LinkedListNode<T> Last { get { return tail; } }
		public int Count { get { return count; } }

		public LinkedListNode<T> AddBefore(LinkedListNode<T> node, T value)
		{
			ValidateNode(node);
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
			InsertNodeBefore(node, newNode);
			if (node == head)
				head = newNode;
			return newNode;
		}

		public LinkedListNode<T> AddAfter(LinkedListNode<T> node, T value)
		{
			ValidateNode(node);
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
			InsertNodeAfter(node, newNode);
			if (node == tail)
				tail = newNode;
			return newNode;
		}

		public LinkedListNode<T> AddFirst(T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
			if (head != null)
			{
				InsertNodeBefore(head, newNode);
				head = newNode;
			}
			else
			{
				InsertNodeToEmptyList(newNode);
			}
			return newNode;
		}

		public LinkedListNode<T> AddLast(T value)
		{
			LinkedListNode<T> newNode = new LinkedListNode<T>(this, value);
			if (tail != null)
			{
				InsertNodeAfter(tail, newNode);
				tail = newNode;
			}
			else
			{
				InsertNodeToEmptyList(newNode);
			}
			return newNode;
		}

		public void Clear()
		{
			head = null;
			tail = null;
			count = 0;
		}

		public bool Contains(T value)
		{
			return Find(value) != null;
		}

		public LinkedListNode<T> Find(T value)
		{
			LinkedListNode<T>? node = head;
			EqualityComparer<T> c = EqualityComparer<T>.Default;
			if (value != null)
			{
				while (node != null)
				{
					if (c.Equals(node.Item, value))
						return node;
					else
						node = node.next;
				}
			}
			else
			{
				while (node != null)
				{
					if (node.Item == null)
						return node;
					else
						node = node.next;
				}
			}
			return null;
		}

		public bool Remove(T value)
		{
			LinkedListNode<T>? node = Find(value);
			if (node != null)
			{
				Remove(node);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Remove(LinkedListNode<T> node)
		{
			ValidateNode(node);
			if (head == node)
				head = node.next;
			if (tail == node)
				tail = node.prev;
			RemoveNode(node);
		}

		public void RemoveFirst()
		{
			if (head == null)
				throw new InvalidOperationException();

			LinkedListNode<T> headNode = head;
			Remove(headNode);
		}

		public void RemoveLast()
		{
			if (tail == null)
				throw new InvalidOperationException();

			LinkedListNode<T> tailNode = tail;
			Remove(tailNode);
		}

		private void ValidateNode(LinkedListNode<T> node)
		{
			if (node == null)
				throw new ArgumentNullException();
			if (node.list != this)
				throw new InvalidOperationException();
		}

		private void InsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
		{
			newNode.next = node;
			newNode.prev = node.prev;
			if (newNode.prev != null)
				newNode.prev.next = newNode;

			node.prev = newNode;

			count++;
		}

		private void InsertNodeAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
		{
			newNode.prev = node;
			newNode.next = node.next;
			if (newNode.next != null)
				newNode.next.prev = newNode;

			node.next = newNode;

			count++;
		}

		private void InsertNodeToEmptyList(LinkedListNode<T> newNode)
		{
			if (count != 0)
				throw new InvalidOperationException();

			head = newNode;
			tail = newNode;
			count++;
		}

		private void RemoveNode(LinkedListNode<T> node)
		{
			if (node.list != this)
				throw new InvalidOperationException();

			if (node.prev != null)
				node.prev.next = node.next;
			if (node.next != null)
				node.next.prev = node.prev;

			count--;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		public struct Enumerator : IEnumerator<T>
		{
			private LinkedList<T> list;
			private LinkedListNode<T> node;
			private int index;
			private T current;

			internal Enumerator(LinkedList<T> list)
			{
				this.list = list;
				this.node = null;
				this.index = -1;
				this.current = default(T);
			}

			public T Current { get { return current; } }

			object IEnumerator.Current
			{
				get
				{
					if (index < 0 || index >= list.Count)
						throw new InvalidOperationException();
					return Current;
				}
			}

			public void Dispose() { }

			public bool MoveNext()
			{
				if (index < 0)
				{
					node = list.head;
					current = node.Item;
					index++;
					return true;
				}
				else if (index < list.Count - 1)
				{
					node = node.next;
					current = node.Item;
					index++;
					return true;
				}
				else
				{
					node = null;
					current = default(T);
					index = list.Count;
					return false;
				}
			}

			public void Reset()
			{
				node = null;
				index = -1;
				current = default(T);
			}
		}
	}
}
