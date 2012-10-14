using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sumsubset
{
    class Program
    {
        public static int[] arr;
        public static bool[] considered;
        public static void getsubsets(int startindex, int size, int sum)
        {
            if (size == 1)
            {
                for (int i = startindex; i < arr.Length; i++)
                {
                    if (arr[i] == sum)
                    {
                        considered[startindex] = false;
                        considered[i] = true;
                        for (int k = 0; k < arr.Length; k++)
                        {
                            if (considered[k] == true)
                            {
                                Console.Write(arr[k]+" ");
                            }
                        }
                        Console.WriteLine();
                        return;
                    }
                }
                return;            
            }
            else
            {
                for (int i = startindex; i <= arr.Length - size; i++)
                {
                    for (int j = startindex; j < i; j++)
                    { 
                        considered[j] = false;
                    }
                    for (int j = i; j < size + i; j++)
                    {
                        considered[j] = true;
                    }
                    for (int j = size + i; j < arr.Length; j++)
                    {
                        considered[j] = false;
                    }
                    getsubsets(i + 1, size - 1, sum - arr[i]);
                }
            }
        }
        public static void Main()
        {
            arr=new int[]{1,2,3,4,5,6};
            considered = new bool[arr.Length];
            for (int i = 1; i < arr.Length; i++)
            {
                getsubsets(0,i, 6);
            }
            Console.ReadLine();
        }
    }
}
