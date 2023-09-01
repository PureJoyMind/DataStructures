
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

            var arr = new int[] {12, 5, 2, 8, 10, 0, 13, 5, 7, 6, 4, 1};

            // bubble sort test
            //Write($"{"our array before bubble sort:",-50}");
            //WriteLine(string.Join(", ", arr));
            //Sort.BubbleSort(arr);
            //Write($"{"our array after bubble sort:", -50}");
            //WriteLine(string.Join(", ", arr));

            //selection sort test
            //Write($"{"our array before selection sort:", -50}");
            //WriteLine(string.Join(", ", arr));
            //Sort.SelectionSort(arr);
            //Write($"{"our array after selection sort:",-50}");
            //WriteLine(string.Join(", ", arr));

            //merge sort test
            Write($"{"our array before merge sort: ",-50}");
            WriteLine(string.Join(", ", arr));
            var merge = Sort.MergeSort(arr);
            Write($"{"our array after merge sort: ",-50}");
            WriteLine(string.Join(", ", merge));

            //counting inversions test
            Write($"{"Our array: ",-50}");
            WriteLine(string.Join(", ", arr));

            var inversion = UtilAlgorithms.CountInversionSort(arr);

            //WriteLine(string.Join(", ", inversion.ReturnedArr));
            Write($"{"The number of inversions in this array: ",-50}");
            WriteLine(inversion.InversionCount);

        }
    }
}
