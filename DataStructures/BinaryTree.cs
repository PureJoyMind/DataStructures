using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    public class BinaryTree
    {

        public BinaryTree(int? value = null)
        {
            _root = value is null ? null : new Node((int)value);
            _traverseList = new List<int>();
        }

        protected Node _root;
        protected List<int> _traverseList;
        
        public int? Root // In order to be able to read the root from the binary tree object without access to the tree
        {
            get => _root is null ? null : _root.Value;
            set => _root.Value = (int)value;
        }

        public string PreOrder
        {
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

        public string LevelOrder
        {
            get
            {
                TraverseLevelOrder(_root);
                var ret = string.Join(", ", _traverseList);
                _traverseList.Clear();
                return ret;
            }
        }

        public int Height => GetTreeHeight(_root);

        public int Min
        {
            get
            {
                if (_root is null)
                {
                    throw new InvalidOperationException("The Binary search tree is empty.");
                }

                var current = _root;
                var last = current;
                while (current != null)
                {
                    last = current;
                    current = current.LeftChild;
                }
                return last.Value;
            }
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

        public virtual void Insert(int value)
        {

        }


        protected void TraversePreOrder(Node root)
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

        protected void TraverseInOrder(Node root)
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

        protected void TraversePostOrder(Node root)
        {
            // Left, Right, Root
            if (root is null)
            {
                return;
            }

            
        }

        protected void TraverseLevelOrder(Node root) // Breadth first traversal
        {
            if(root is null) return;

            for (int i = 0; i <= Height; i++)
            {
                _traverseList.AddRange(GetNodesAtDistance(i));
            }

        }

        protected int GetTreeHeight(Node root) // Returns -1 if root is null
        {
            if (root is null) return -1;
            if (root.HasChild == false) return 0;

            return 1 + Math.Max(GetTreeHeight(root.LeftChild), GetTreeHeight(root.RightChild));
        }


        public List<int> GetNodesAtDistance(int distance) // We can change the method to return the list and not a string 
        {
            var values = new List<int>();
            GetNodesAtDistance(_root, distance, values);

            return values;
        }
        protected void GetNodesAtDistance(Node root, int distance, List<int> values)
        {
            if(root is null) return;
            if (distance < 0) throw new ArgumentException("Distance Cannot be negative");
            if (distance == 0) 
            {
                values.Add(root.Value);
                return;
            }


            GetNodesAtDistance(root.LeftChild, distance - 1, values);
            GetNodesAtDistance(root.RightChild, distance - 1, values);
        }

        public override bool Equals(object obj)
        {
            var t2 = obj as BinaryTree;

            if (t2 == null) return false;

            var traverse1 = this.PreOrder;
            var traverse2 = t2.PreOrder;

            return traverse1 == traverse2;
        }

        protected class Node
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
