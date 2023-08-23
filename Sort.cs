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
    }
}
