
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

            // bubble sort test
            //Write("our array before bubble sort: ");
            //PrintArray(arr);
            //Sort.BubbleSort(arr);
            //Write("our array after bubble sort: ");
            //PrintArray(arr);

             //selection sort test
            Write("our array before selection sort: ");
            PrintArray(arr);
            Sort.SelectionSort(arr);
            Write("our array after selection sort: ");
            PrintArray(arr);


            var merge = Sort.MergeSort(arr);

            var inversion = UtilAlgorithms.CountInversionSort(arr);

            WriteLine(string.Join(", ", inversion.ReturnedArr));
            WriteLine(inversion.InversionCount);

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
