
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = UtilAlgorithms.FirstRepeatedChar("rgenapple");
            WriteLine(c);

            var s = new HashSet<int>();
            var arr = new int[] { 1, 2, 3, 1, 1, 2, 3, 4 };
            foreach (var i in arr)
            {
                s.Add(i);
            }
            WriteLine(UtilAlgorithms.HashSetToString(s));


        }
    }
}
