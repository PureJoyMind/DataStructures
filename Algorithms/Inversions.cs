using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DataStructures.Algorithms
{
    public static class Inversions
    {
        public static InversionCounter CountInversionSort(int[] arr) // count the number of inversions and sort the array
        {
            if (arr.Length == 1) return new InversionCounter { ReturnedArr = arr };

            var arr1Sorted = arr.Take(arr.Length / 2).ToArray();
            var arr2Sorted = arr.Skip(arr.Length / 2).ToArray();

            var arr1 = CountInversionSort(arr1Sorted);
            var arr2 = CountInversionSort(arr2Sorted);

            var k = 0;
            var merged = new int[arr2.ReturnedArr.Length + arr1.ReturnedArr.Length];
            if (arr2.ReturnedArr.Length + arr1.ReturnedArr.Length == 2)
            {
                merged[0] = arr1.ReturnedArr[0];
                merged[1] = arr2.ReturnedArr[0];
            }

            int sorted = 0;
            var i = 0;
            var j = 0;
            while (i < arr1.ReturnedArr.Length && j < arr2.ReturnedArr.Length)
            {
                //if (i >= arr1.Length) break;

                if (arr1.ReturnedArr[i] < arr2.ReturnedArr[j])
                {
                    merged[k++] = arr1.ReturnedArr[i++];
                }
                else
                {
                    sorted += (arr2.ReturnedArr.Length + arr1.ReturnedArr.Length) / 2;
                    merged[k++] = arr2.ReturnedArr[j++];
                }
            }

            while (i < arr1.ReturnedArr.Length)
            {
                merged[k++] = arr1.ReturnedArr[i++];
            }

            while (j < arr2.ReturnedArr.Length)
            {
                merged[k++] = arr2.ReturnedArr[j++];
            }
            var returning = new InversionCounter
            {
                ReturnedArr = merged,
                InversionCount = arr1.InversionCount + arr2.InversionCount + sorted
            }; // Left inversion + Right inversion + Split inversion(merge)

            return returning;
        }

        public static void ImplementInversionCount(int[] arr = null)
        {
            // counting inversions test
            Write($"{"Our array: ",-50}");
            WriteLine(string.Join(", ", arr));

            var inversion = CountInversionSort(arr);

            WriteLine(string.Join(", ", inversion.ReturnedArr));
            Write($"{"The number of inversions in this array: ",-50}");
            WriteLine(inversion.InversionCount);
        }

        public class InversionCounter
        {
            public int InversionCount { get; set; }
            public int[] ReturnedArr { get; set; }
        }

    }
}
