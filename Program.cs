
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
            bt1.Insert(7);
            bt1.Insert(4);
            bt1.Insert(9);
            bt1.Insert(1);
            bt1.Insert(6);
            bt1.Insert(8);
            bt1.Insert(10);

            BinarySearchTree bt2 = new BinarySearchTree();
            //bt2.Insert(7);
            //bt2.Insert(4);
            //bt2.Insert(9);
            //bt2.Insert(1);
            //bt2.Insert(6);
            //bt2.Insert(8);
            //bt2.Insert(10);

            WriteLine(bt2.Equals(bt1));
        }
    }
}
