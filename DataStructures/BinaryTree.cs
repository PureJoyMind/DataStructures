using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    public class BinaryTree
    {
        private Node _root;
        public int Root // In order to be able to read the root from the binary tree object without access to the tree
        {
            get => _root.Value;
            set => _root.Value = value;
        }

        private List<int> _traverseList;

        public string PreOrder {
            get
            {
                TraversePreOrder(_root);
                var ret = string.Join(", ", _traverseList);
                _traverseList.Clear();
                return ret;
            }
        }

        public string InOrder
        {
            get
            {
                TraverseInOrder(_root);
                var ret = string.Join(", ", _traverseList);
                _traverseList.Clear();
                return ret;
            }
        }

        public string PostOrder
        {
            get
            {
                TraversePostOrder(_root);
                var ret = string.Join(", ", _traverseList);
                _traverseList.Clear();
                return ret;
            }
        }


        public BinaryTree(int? value = null)
        {
            _root = value is null ? null : new Node((int)value);
            _traverseList = new List<int>();
        }

        public bool Find(int value)
        {
            if (_root is null)
            {
                return false;
            }

            if (value == _root.Value) return true;

            var current = _root;
            while (true)
            {
                if (current is null)
                {
                    return false;
                }
                if (value == current.Value) return true;

                if (value < current.Value)
                {
                    current = current.LeftChild;
                    
                }
                else if (value > current.Value)
                {
                    current = current.RightChild;
                }
            }
        }

        public void Insert(int value)
        {
            Node newValue = new Node(value);
            if (_root == null)
            {
                _root = new Node(value);
                return;
            }

            var current = _root;
            Node parent = null;
            while (current is not null)
            {
                if (value == current.Value) return;
                if (value < current.Value)
                {
                    parent = current;
                    current = current.LeftChild;
                    
                }
                else if (value > current.Value)
                {
                    parent = current;
                    current = current.RightChild;
                }

                if (current == null)
                {
                    current = new Node(value);
                    if (current.Value > parent?.Value)
                    {
                        parent.RightChild = current;
                    }
                    else if (current.Value < parent?.Value)
                    {
                        parent.LeftChild = current;
                    }
                    return;
                }
            }

        }

        private void TraversePreOrder(Node root)
        {
            // Root, Left, Right
            if (root is null)
            {
                return;
            }

            _traverseList.Add(root.Value);
            TraversePreOrder(root.LeftChild);
            TraversePreOrder(root.RightChild);
        }

        private void TraverseInOrder(Node root)
        {
            // Left, Root, Right
            if (root is null)
            {
                return;
            }

            TraverseInOrder(root.LeftChild);
            _traverseList.Add(root.Value);
            TraverseInOrder(root.RightChild);
        }

        private void TraversePostOrder(Node root)
        {
            // Left, Right, Root
            if (root is null)
            {
                return;
            }

            TraversePostOrder(root.LeftChild);
            TraversePostOrder(root.RightChild);
            _traverseList.Add(root.Value);
        }

        private class Node
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }

            public bool HasChild => LeftChild != null || RightChild != null;

            public Node(int value, Node leftChild = null, Node rightChild = null)
            {
                Value = value;
                LeftChild = leftChild;
                RightChild = rightChild;
            }

            public override string ToString()
            {
                return $@"Node: {Value}, Left: {(LeftChild is not null ? LeftChild.Value : "null")}, Right: {(RightChild is not null ? RightChild.Value : "null")}";
            }
        }

    }

    
}
