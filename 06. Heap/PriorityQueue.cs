using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure
{
	internal class PriorityQueue<TElement, TPriority>
	{
		private struct Node
		{
			public TElement Element;
			public TPriority Priority;
		}

		private List<Node> nodes;
		private IComparer<TPriority> comparer;

		public PriorityQueue()
		{
			this.nodes = new List<Node>();
			this.comparer = Comparer<TPriority>.Default;
		}

		public PriorityQueue(IComparer<TPriority> comparer)
		{
			this.nodes = new List<Node>();
			this.comparer = comparer;
		}

		public int Count { get { return nodes.Count; } }
		public IComparer<TPriority> Comparer { get { return comparer; } }

		public void Enqueue(TElement element, TPriority priority)
		{
			Node newNode = new Node() { Element = element, Priority = priority };

			PushHeap(newNode);
		}

		public TElement Peek()
		{
			if (nodes.Count == 0)
				throw new InvalidOperationException();

			return nodes[0].Element;
		}

		public bool TryPeek(out TElement element, out TPriority priority)
		{
			if (nodes.Count == 0)
			{
				element = default(TElement);
				priority = default(TPriority);
				return false;
			}

			element = nodes[0].Element;
			priority = nodes[0].Priority;
			return true;
		}

		public TElement Dequeue()
		{
			if (nodes.Count == 0)
				throw new InvalidOperationException();

			Node rootNode = nodes[0];
			PopHeap();
			return rootNode.Element;
		}

		public bool TryDequeue(out TElement element, out TPriority priority)
		{
			if (nodes.Count == 0)
			{
				element = default(TElement);
				priority = default(TPriority);
				return false;
			}

			Node rootNode = nodes[0];
			element = rootNode.Element;
			priority = rootNode.Priority;
			PopHeap();
			return true;
		}

		private void PushHeap(Node newNode)
		{
			nodes.Add(newNode);
			int newNodeIndex = nodes.Count - 1;
			while (newNodeIndex > 0)
			{
				int parentIndex = GetParentIndex(newNodeIndex);
				Node parentNode = nodes[parentIndex];

				if (comparer.Compare(newNode.Priority, parentNode.Priority) < 0)
				{
					nodes[newNodeIndex] = parentNode;
					newNodeIndex = parentIndex;
				}
				else
				{
					break;
				}
			}
			nodes[newNodeIndex] = newNode;
		}

		private void PopHeap()
		{
			Node lastNode = nodes[nodes.Count - 1];
			nodes.RemoveAt(nodes.Count - 1);

			int index = 0;
			while (index < nodes.Count)
			{
				int leftChildIndex = GetLeftChildIndex(index);
				int rightChildIndex = GetRightChildIndex(index);

				if (rightChildIndex < nodes.Count)
				{
					int compareIndex = comparer.Compare(nodes[leftChildIndex].Priority, nodes[rightChildIndex].Priority) < 0 ?
					leftChildIndex : rightChildIndex;

					if (comparer.Compare(nodes[compareIndex].Priority, lastNode.Priority) < 0)
					{
						nodes[index] = nodes[compareIndex];
						index = compareIndex;
					}
					else
					{
						nodes[index] = lastNode;
						break;
					}
				}
				else if (leftChildIndex < nodes.Count)
				{
					if (comparer.Compare(nodes[leftChildIndex].Priority, lastNode.Priority) < 0)
					{
						nodes[index] = nodes[leftChildIndex];
						index = leftChildIndex;
					}
					else
					{
						nodes[index] = lastNode;
						break;
					}
				}
				else
				{
					nodes[index] = lastNode;
					break;
				}
			}
		}

		private int GetParentIndex(int childIndex)
		{
			return (childIndex - 1) / 2;
		}

		private int GetLeftChildIndex(int parentIndex)
		{
			return parentIndex * 2 + 1;
		}

		private int GetRightChildIndex(int parentIndex)
		{
			return parentIndex * 2 + 2;
		}
	}
}



/*private void PopHeap()
{
	Node lastNode = nodes[nodes.Count - 1];
	nodes.RemoveAt(nodes.Count - 1);

	int index = 0;
	while (index < nodes.Count)
	{
		int leftChildIndex = GetLeftChildIndex(index);
		int rightChildIndex = GetRightChildIndex(index);

		if (rightChildIndex < nodes.Count)
		{
			int compareIndex = comparer.Compare(nodes[leftChildIndex].Priority, nodes[rightChildIndex].Priority) < 0 ?
			leftChildIndex : rightChildIndex;

			if (comparer.Compare(nodes[compareIndex].Priority, lastNode.Priority) < 0)
			{
				nodes[index] = nodes[compareIndex];
				index = compareIndex;
			}
			else
			{
				break;
			}
		}
		else if (leftChildIndex < nodes.Count)
		{
			if (comparer.Compare(nodes[leftChildIndex].Priority, lastNode.Priority) < 0)
			{
				nodes[index] = nodes[leftChildIndex];
				index = leftChildIndex;
			}
			else
			{
				break;
			}
		}
		else
		{
			break;
		}

		if (comparer.Compare(lastNode.Priority, minChild.Priority) < 0)
			break;


	}
	nodes[index] = lastNode;
}*/