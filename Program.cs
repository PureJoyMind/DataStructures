
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
            bt1.Insert(5);
            //bt1.Insert(1);
            //bt1.Insert(6);
            //bt1.Insert(8);
            //bt1.Insert(10);

            BinaryTree bt2 = new BinaryTree();
            bt2.Insert(7);
            bt2.Insert(4);
            bt2.Insert(5);
            //bt2.Insert(1);
            //bt2.Insert(6);
            //bt2.Insert(8);
            //bt2.Insert(10);

            WriteLine($"bt1:\n\tlevel: {bt1.LevelOrder}\n\tpre: {bt1.PreOrder}\n\tin: {bt1.InOrder}");
            WriteLine($"bt1:\n\tlevel: {bt2.LevelOrder}\n\tpre: {bt2.PreOrder}\n\tin: {bt2.InOrder}");

        }
    }
}
