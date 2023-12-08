using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private Node root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public bool Add(T item)
        {
            if (root == null)
            {
                Node newNode = new Node(item, null, null, null);
                root = newNode;
                return true;
            }

            Node current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)
                {
                    if (current.left == null)
                    {
                        Node newNode = new Node(item, null, null, null);
                        current.left = newNode;
                        newNode.parent = current;
                        break;
                    }

                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    if (current.right == null)
                    {
                        Node newNode = new Node(item, null, null, null);
                        current.right = newNode;
                        newNode.parent = current;
                        break;
                    }

                    current = current.right;
                }
                else // if (item.CompareTo(current.item) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Remove(T item)
        {
            Node findNode = FindNode(item);
            if (findNode != null)
            {
                EraseNode(findNode);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Contains(T item)
        {
            Node findNode = FindNode(item);
            return findNode != null ? true : false;
        }

        public void Clear()
        {
            root = null;
        }

        private Node FindNode(T item)
        {
            if (root == null)
            {
                return null;
            }

            Node current = root;
            while (current != null)
            {
                if (item.CompareTo(current.item) < 0)
                {
                    current = current.left;
                }
                else if (item.CompareTo(current.item) > 0)
                {
                    current = current.right;
                }
                else // if (item.CompareTo(current.item) == 0)
                {
                    return current;
                }
            }

            return null;
        }

        private void EraseNode(Node node)
        {
            if (node.left == null && node.right == null)
            {
                Node parent = node.parent;

                if (parent == null)
                {
                    root = null;
                }
                else if (parent.left == node)
                {
                    parent.left = null;
                }
                else if (parent.right == node)
                {
                    parent.right = null;
                }
            }
            else if (node.left == null || node.right == null)
            {
                Node parent = node.parent;
                Node child = node.left != null ? node.left : node.right;

                if (parent == null)
                {
                    root = child;
                    child.parent = null;
                }
                else if (parent.left == node)
                {
                    parent.left = child;
                    child.parent = parent;
                }
                else if (parent.right == node)
                {
                    parent.right = child;
                    child.parent = parent;
                }
            }
            else // if (node.left != null && node.right != null)
            {
                Node nextNode = node.right;
                while (nextNode.left != null)
                {
                    nextNode = nextNode.left;
                }
                node.item = nextNode.item;
                EraseNode(nextNode);
            }
        }

        private class Node
        {
            public T item;
            public Node parent;
            public Node left;
            public Node right;

            public Node(T item, Node parent, Node left, Node right)
            {
                this.item = item;
                this.parent = parent;
                this.left = left;
                this.right = right;
            }
        }
    }
}