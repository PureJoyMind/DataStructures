
using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.DataStructures;
using static System.Console;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree(new Node(7));
            bt.Insert(7);
            bt.Insert(4);
            bt.Insert(9);
            bt.Insert(1);
            bt.Insert(6);
            bt.Insert(8);
            bt.Insert(10);

            bt.Find(12);

            bt.PrintTree();
        }
    }
}
