using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
	internal class BinarySearchTree<T> where T : IComparable<T>
	{
		private Node root;

		public BinarySearchTree()
		{
			this.root = null;
		}
		
		public bool Add(T item)
		{
			Node newNode = new Node(item, null, null, null);

			if (root == null)
			{
				root = newNode;
				return true;
			}

			Node current = root;
			while (current != null)
			{
				if (item.CompareTo(current.Item) < 0)
				{
					if (current.Left != null)
					{
						current = current.Left;
					}
					else
					{
						current.Left = newNode;
						newNode.Parent = current;
						break;
					}
				}
				else if (item.CompareTo(current.Item) > 0)
				{
					if (current.Right != null)
					{
						current = current.Right;
					}
					else
					{
						current.Right = newNode;
						newNode.Parent = current;
						break;
					}
				}
				else
				{
					return false;
				}
			}
			return true;
		}

		public bool Remove(T item)
		{
			if (root == null)
				return false;

			Node findNode = FindNode(item);
			if (findNode == null)
			{
				return false;
			}
			else
			{
				EraseNode(findNode);
				return true;
			}
		}

		public void Clear()
		{
			root = null;
		}

		public bool TryGetValue(T item, out T outValue)
		{
			if (root == null)
			{
				outValue = default(T);
				return false;
			}

			Node findNode = FindNode(item);
			if (findNode == null)
			{
				outValue = default(T);
				return false;
			}
			else
			{
				outValue = findNode.Item;
				return true;
			}
		}

		private Node FindNode(T item)
		{
			if (root == null)
				return null;

			Node current = root;
			while (current != null)
			{
				if (item.CompareTo(current.Item) < 0)
				{
					current = current.Left;
				}
				else if (item.CompareTo(current.Item) > 0)
				{
					current = current.Right;
				}
				else
				{
					return current;
				}
			}

			return null;
		}

		private void EraseNode(Node node)
		{
			if (node.HasNoChild)
			{
				if (node.IsLeftChild)
					node.Parent.Left = null;
				else if (node.IsRightChild)
					node.Parent.Right = null;
				else
					root = null;
			}
			else if (node.HasLeftChild || node.HasRightChild)
			{
				Node parent = node.Parent;
				Node child = node.HasLeftChild ? node.Left : node.Right;

				if (node.IsLeftChild)
				{
					parent.Left = child;
					child.Parent = parent;
				}
				else if (node.IsRightChild)
				{
					parent.Right = child;
					child.Parent = parent;
				}
				else
				{
					root = child;
					child.Parent = null;
				}
			}
			else
			{
				Node nextNode = node.Right;
				while (nextNode.Left != null)
				{
					nextNode = nextNode.Left;
				}
				node.Item = nextNode.Item;
				EraseNode(nextNode);
			}
		}

		private class Node
		{
			private T item;
			private Node parent;
			private Node left;
			private Node right;

			public Node(T item, Node parent, Node left, Node right)
			{
				this.item = item;
				this.parent = parent;
				this.left = left;
				this.right = right;
			}

			public T Item { get { return item; } set { item = value; } }
			public Node Parent { get { return parent; } set { parent = value; } }
			public Node Left { get { return left; } set { left = value; } }
			public Node Right { get { return right; } set { right = value; } }

			public bool IsRootNode { get { return parent == null; } }
			public bool IsLeftChild { get { return parent != null && parent.left == this; } }
			public bool IsRightChild { get { return parent != null && parent.right == this; } }

			public bool HasNoChild { get { return left == null && right == null; } }
			public bool HasLeftChild { get { return left != null && right == null; } }
			public bool HasRightChild { get { return left == null && right != null; } }
			public bool HasBothChild { get { return left != null && right != null; } }
		}
	}
}
