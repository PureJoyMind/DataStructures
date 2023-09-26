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
            _root = value == null ? null : new Node((int)value);
            _traverseList = new List<int>();
        }

        protected Node _root;
        protected List<int> _traverseList;
        
        public int? Root // In order to be able to read the root from the binary tree object without access to the tree
        {
            get
            {
                if(_root == null) return null;
                else return _root.Value;
            } 
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
                if (_root == null)
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

        public bool IsBinarySearchTree => CheckIfBinarySearchTree(_root, null, null);

        public bool Find(int value)
        {
            if (_root == null)
            {
                return false;
            }

            if (value == _root.Value) return true;

            var current = _root;
            while (true)
            {
                if (current == null)
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

        public virtual void Insert(int value) // Inserts in the first empty node in level order traversal
        {
            if(_root == null)
            {
                _root = new Node(value);
                return;
            };
            if(_root.Value == value) return;
            
            var q = new Queue<Node>(); 

            q.Enqueue(_root);

            while (q.Count != 0)
            {
                var tmp = q.Peek();
                q.Dequeue();

                if (tmp.LeftChild == null)
                {
                    tmp.LeftChild = new Node(value);
                    break;
                }

                q.Enqueue(tmp.LeftChild);

                if (tmp.RightChild == null)
                {
                    tmp.RightChild = new Node(value);
                    break;      
                }
                q.Enqueue(tmp.RightChild);

            }
        }

        protected void TraversePreOrder(Node root)
        {
            // Root, Left, Right
            if (root == null)
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
            if (root == null)
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
            if (root == null)
            {
                return;
            }

            TraversePostOrder(root.LeftChild);
            TraversePostOrder(root.RightChild);
            _traverseList.Add(root.Value);
        }

        protected void TraverseLevelOrder(Node root) // Breadth first traversal
        {
            if(root == null) return;

            for (int i = 0; i <= Height; i++)
            {
                _traverseList.AddRange(GetNodesAtDistance(i));
            }

        }

        protected int GetTreeHeight(Node root) // Returns -1 if root == null
        {
            if (root == null) return -1;
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
            if(root == null) return;
            if (distance < 0) throw new ArgumentException("Distance Cannot be negative");
            if (distance == 0) 
            {
                values.Add(root.Value);
                return;
            }


            GetNodesAtDistance(root.LeftChild, distance - 1, values);
            GetNodesAtDistance(root.RightChild, distance - 1, values);
        }

        protected bool CheckIfBinarySearchTree(Node root, int? leftBound = null, int? rightBound = null)
        {
            if (root == null) { return true; }
            //if (root.HasChild == false) return true;

            if (leftBound != null && root.Value < leftBound ) return false;
            if (rightBound != null && root.Value > rightBound ) return false;

            var left = CheckIfBinarySearchTree(root.LeftChild, leftBound, root.Value - 1);
            var right = CheckIfBinarySearchTree(root.RightChild, root.Value + 1, rightBound);

            return left && right;
        }

        public string GetTreeInfo()
        {
            StringBuilder info = new StringBuilder();
            info.Append("Binary Tree Info:");
            info.AppendLine();
            info.Append("\t");
            info.AppendFormat($"level: {LevelOrder,35}");
            info.AppendLine();
            info.Append("\t");
            info.AppendFormat($"pre:{null,2} {PreOrder,35}");
            info.AppendLine();
            info.Append("\t");
            info.AppendFormat($"in:{null,3} {InOrder,35}");
            info.AppendLine();
            info.Append("\t");
            info.AppendFormat($"post:{null,1} {PostOrder,35}");
            return info.ToString();
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
                string l;
                string r;
                if (LeftChild != null) l = LeftChild.Value.ToString();
                else l = "null";

                if (RightChild != null) r = RightChild.Value.ToString();
                else r = "null";
                
                return $"Node: {Value}, Left: {l}, Right: {r}";
            }
        }
    }
}
