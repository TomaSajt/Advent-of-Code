using System;
using System.Collections.Generic;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[200];
            int pos1 = -1;
            int pos2 = -1;
            int pos3 = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    for (int k = j + 1; k < arr.Length; k++)
                    {
                        if (arr[i] + arr[j] + arr[k] == 2020)
                        {
                            pos1 = i;
                            pos2 = j;
                            pos3 = k;
                            goto End;
                        }
                    }

                }
            }
        End:
            Console.Clear();
            Console.WriteLine(arr[pos1] * arr[pos2] * arr[pos3]);
            Console.ReadKey();
        }
    }
}
