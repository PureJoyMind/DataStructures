
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
            BinarySearchTree bt1 = new BinarySearchTree();
            bt1.Insert(20);
            bt1.Insert(10);
            bt1.Insert(30);
            bt1.Insert(6);
            bt1.Insert(14);
            bt1.Insert(24);
            bt1.Insert(3);
            bt1.Insert(8);
            bt1.Insert(26);
            
            WriteLine(bt1.GetTreeInfo());
        }
    }
}
