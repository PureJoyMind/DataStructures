
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

            WriteLine(bt1.LevelOrder);

           
        }
    }
}
