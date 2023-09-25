
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
            BinaryTree bt = new BinaryTree(7);
            bt.Insert(7);
            bt.Insert(4);
            bt.Insert(9);
            bt.Insert(1);
            bt.Insert(6);
            bt.Insert(8);
            bt.Insert(10);
            var root = bt.Root;

            bt.Find(12);
            bt.Find(8);

            WriteLine(bt.PreOrder);
            WriteLine(bt.InOrder);
            WriteLine(bt.PostOrder);
        }
    }
}
