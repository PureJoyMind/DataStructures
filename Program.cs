
using System;
using System.Linq;
using static System.Console;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var stack = new Stack(5);
            //stack.Implementation();

            var arr = new int[] {12, 5, 2, 8, 10, 0, 13, 5, 7, 6, 4};
            Write("our array before sort: ");
            PrintArray(arr);
            Sort.BubbleSort(arr);
            Write("our array after sort: ");
            PrintArray(arr);
        }


        public static void PrintArray(params int[] arr)
        {
            foreach (var i in arr)
            {
                Write(i + ", ");
            }
            WriteLine();
        }
    }
}
