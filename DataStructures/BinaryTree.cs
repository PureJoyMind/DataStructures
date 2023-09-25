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
        public Node Root { get; set; }
        public BinaryTree(Node root)
        {
            Root = root;
        }

        public bool Find(int value)
        {
            if (Root is null)
            {
                return false;
            }

            if (value == Root.Value) return true;

            var current = Root;
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
            if (Root == null)
            {
                Root = new Node(value);
                return;
            }

            var current = Root;
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

        public void PrintTree()
        {
            PrintTree(Root, "");
        }

        private void PrintTree(Node node, string indent)
        {
            if (node == null)
                return;

            // Print the right subtree with proper indentation
            PrintTree(node.RightChild, indent + "      ");

            // Print the current node with the current indentation
            Console.WriteLine($"{indent}{node.Value}");

            // Print the left subtree with proper indentation
            PrintTree(node.LeftChild, indent + "      ");
        }

    }

    public class Node
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
