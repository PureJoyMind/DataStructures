using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Sort
    {
        public static void BubbleSort(params int[] arr)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(arr));

            bool isSorted;

            for (int i = 0; i < arr.Length ; i++)
            {
                isSorted = true;
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    return; 
                }
            }
        }

        public static void SelectionSort(params int[] arr)
        {
            if (arr == null) throw new ArgumentNullException(nameof(arr));
            if (arr.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(arr));


            for (int i = 0; i < arr.Length; i++)
            {
                var min = i; // tracking the index of the minimum value in that iteration

                for (int j = i + 1 ; j < arr.Length; j++) // finding the current min value but not checking
                                                          // the already checked ones
                {
                    // for example the 3rd loop starts from the 4th index because the 
                    // first 3 indexes are already the minimum values
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                (arr[i], arr[min]) = (arr[min], arr[i]);
            }
        }

        public static int[] MergeSort(int[] arr)
        {
            if(arr.Length == 1) return arr;

            var arr1 = arr.Take(arr.Length / 2).ToArray();
            var arr2 = arr.Skip(arr.Length / 2).ToArray();

            var sorted = Merge(MergeSort(arr1), MergeSort(arr2));

            return sorted;
        }

        static int[] Merge(int[] arr1, int[] arr2) // expects sorted array
        {
            var k = 0;
            var merged = new int[arr2.Length + arr1.Length];
            if (arr2.Length + arr1.Length == 2)
            {
                merged[0] = arr1[0];
                merged[1] = arr2[0];
            }

            var i = 0;
            var j = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if(i >= arr1.Length) break;
                
                if (arr1[i] < arr2[j])
                {
                    merged[k++] = arr1[i++];
                }
                else
                {
                    merged[k++] = arr2[j++];
                }
            }

            while (i < arr1.Length)
            {
                merged[k++] = arr1[i++];
            }

            while (j < arr2.Length)
            {
                merged[k++] = arr2[j++];
            }

            return merged;
        }

    }
}
