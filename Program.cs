
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
            WriteLine(hashTable.GetValue(1));
            var x = hashTable.GetValue(5);
            WriteLine(x);
            hashTable.Add(1, "maz");
            WriteLine(hashTable.GetValue(1));
            hashTable.Add(4, "four");
            WriteLine(hashTable.GetValue(4));
            hashTable.Remove(4);
            WriteLine(hashTable.GetValue(4));
        }
    }
}
