using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lexperm
{
    class Program
    {
        
        static List<Tuple<int,int>> GetListOfFactMul(int truenum)
        {
            List<Tuple<int,int>> listtuples=new List<Tuple<int,int>>();
            while (truenum > 0)
            {
                Tuple<int,int> t=FindLeastFactAndMul(truenum);
                listtuples.Add(t);
                truenum -= factfun(t.Item1) * t.Item2;
            }
            return listtuples;
        }

        static void lexperm(int[] remaining, int num, int[] output)
        {
            List<Tuple<int,int>> listtuples=GetListOfFactMul(num);
            if (listtuples.Count == 1)
            {
                if (listtuples[0].Item2 == 1)//if perfect factorial
                {
                    Array.Sort(remaining);
                    Array.Reverse(remaining, remaining.Length - listtuples[0].Item1, listtuples[0].Item1);
                    int i=0;
                    while (i<output.Length && output[i] != -1)
                    {
                        i++;
                    }
                    if (i < output.Length)
                    {
                        for (int j = 0; j < remaining.Length; j++)
                        {
                            output[i++] = remaining[j];
                        }
                    }
                }
                else //multiple of perfect factorial
                {
                    int firstptr = remaining.Length - listtuples[0].Item1 - 1;
                    int secondptr = firstptr + listtuples[0].Item2-1;
                    int temp = remaining[firstptr];
                    remaining[firstptr] = remaining[secondptr];
                    remaining[secondptr] = temp;
                    int i = 0;
                    while (i < output.Length && output[i] != -1)
                    {
                        i++;
                    }
                    if (i < output.Length)
                    {
                        for (int j = 0; j <= firstptr; j++)
                        {
                            output[i++] = remaining[j];
                            remaining[j] = -1;
                        }
                    }
                    List<int> l = remaining.ToList();
                    l.RemoveAll(nr => nr == -1);
                    remaining = l.ToArray();
                    Array.Sort(remaining);
                    Array.Reverse(remaining);
                    for (int j = 0; j < remaining.Length; j++)
                    {
                        output[i++] = remaining[j];
                    }
                }
            }
            else
            {
                int numdigsaffected = listtuples[0].Item1 + 1;
                int i=0;
                while (i < output.Length && output[i] != -1)
                {
                    i++;
                }
                if (i < output.Length)
                {
                    for (int j = 0; j < remaining.Length - numdigsaffected; j++)
                    {
                        output[i++] = remaining[j];
                        remaining[j] = -1;
                    }
                }
                List<int> l = remaining.ToList();
                l.RemoveAll(nr => nr == -1);
                remaining = l.ToArray();
                output[i] = remaining[listtuples[0].Item2];
                i++;
                remaining[listtuples[0].Item2] = -1;
                l = remaining.ToList();
                l.RemoveAll(nr => nr == -1);
                remaining = l.ToArray();
                Array.Sort(remaining);
                num-=factfun(listtuples[0].Item1)*listtuples[0].Item2;
                lexperm(remaining, num, output);
            }
        }

        static Tuple<int, int> FindLeastFactAndMul(int RemPer)
        {
            Tuple<int, int> factandmul;
            int i = 1;
            int fact = 1;
            while (fact <= RemPer)
            {
                i++;
                fact = fact * i;
            }
            fact = fact / i;
            i--;
            int j = 1;
            while (fact * j <= RemPer)
            {
                j++;
            }
            j--;
            factandmul = new Tuple<int, int>(i, j);
            return factandmul;
        }
        static int factfun(int num)
        {
            int f = 1;
            for (int i = 1; i <= num; i++)
            {
                f = f * i;
            }
            return f;
        }

        static void Main(string[] args)
        {
            int[] arrrem = { 0,1, 2, 3, 4,5,6,7,8,9 };
            int[] output = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            lexperm(arrrem, 1000000, output);
            for (int j = 0; j < output.Length; j++)
            {
                Console.Write(output[j]);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
