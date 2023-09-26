using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.DataStructures
{
    public class BinarySearchTree : BinaryTree
    {
        public BinarySearchTree(int? value = null) : base(value) {}

        public override void Insert(int value) // Inserts in the right order
        {
            Node newValue = new Node(value);
            if (_root == null)
            {
                _root = newValue;
                return;
            }

            var current = _root;
            Node parent = null;
            while (current != null)
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
                    current = newValue;
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

        
    }
}
