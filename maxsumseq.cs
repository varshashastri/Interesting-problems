using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace MaxSubSeqSum
{
    class Program
    {
        public static int[] arr;
        public static void MaxSubsequenceSum()
        {
            int startIndex=0, length=0,sum=arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (sum <= 0)
                {
                    startIndex =i;
                    length = 0;
                    sum = arr[i];
                }
                else
                {
                    length++;
                    sum += arr[i];
                }
            }
            Console.WriteLine(sum);
        }
        static void Main(string[] args)
        {
            arr=new int[]{3,1,-5,4,-15,5,6,-2,50};
            MaxSubsequenceSum();
            Console.ReadLine();
        }
    }
}