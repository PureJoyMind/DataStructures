
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
            var hashTable = new CustomHashTable(10);
            hashTable.Add(1, "john");
            WriteLine(hashTable.Get(1));
            var x = hashTable.Get(5);
            WriteLine(x);
            hashTable.Add(1, "maz");
            WriteLine(hashTable.Get(1));
        }
    }
}
