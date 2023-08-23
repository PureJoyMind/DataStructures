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
    }
}
