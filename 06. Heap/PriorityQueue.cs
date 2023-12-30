using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class PriorityQueue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private struct Node
        {
            public TElement element;
            public TPriority priority;

            public Node(TElement element, TPriority priority)
            {
                this.element = element;
                this.priority = priority;
            }
        }

        private List<Node> nodes;

        public PriorityQueue()
        {
            nodes = new List<Node>();
        }

        public int Count { get { return nodes.Count; } }

        public void Enqueue(TElement element, TPriority priority)
        {
            Node node = new Node(element, priority);
            nodes.Add(node);

            int index = nodes.Count - 1;
            while (index > 0)
            {
                int parentIndex = GetParentIndex(index);
                Node parentNode = nodes[parentIndex];

                if (node.priority.CompareTo(parentNode.priority) >= 0)
                    break;

                nodes[index] = parentNode;
                nodes[parentIndex] = node;
                index = parentIndex;
            }
        }

        public TElement Peek()
        {
            if (nodes.Count == 0)
                throw new InvalidOperationException();

            return nodes[0].element;
        }

        public TElement Dequeue()
        {
            if (nodes.Count == 0)
                throw new InvalidOperationException();

            Node rootNode = nodes[0];
            Node node = nodes[nodes.Count - 1];
            nodes[0] = node;
            nodes.RemoveAt(nodes.Count - 1);

            int index = 0;
            while (index < nodes.Count)
            {
                int leftIndex = GetLeftChildIndex(index);
                int rightIndex = GetRightChildIndex(index);
                int targetIndex = index;

                if (leftIndex < Count &&
                    nodes[leftIndex].priority.CompareTo(nodes[targetIndex].priority) < 0)
                {
                    targetIndex = leftIndex;
                }
                if (rightIndex < Count &&
                    nodes[rightIndex].priority.CompareTo(nodes[targetIndex].priority) < 0)
                {
                    targetIndex = rightIndex;
                }

                if (index == targetIndex)
                    break;

                nodes[index] = nodes[targetIndex];
                nodes[targetIndex] = node;
                index = targetIndex;
            }

            return rootNode.element;
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return index * 2 + 2;
        }
    }
}
