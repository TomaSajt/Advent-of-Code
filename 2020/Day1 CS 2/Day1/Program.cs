using System;
using System.Collections.Generic;
using System.IO;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new List<string>(File.ReadAllLines("input.txt")).ConvertAll<int>(int.Parse).ToArray();
            for (int i = 0; i < arr.Length; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    for (int k = j + 1; k < arr.Length; k++)
                        if (arr[i] + arr[j] + arr[k] == 2020)
                        {
                            Console.WriteLine(arr[i] * arr[j] * arr[k]);
                            return;
                        }
            Console.WriteLine("Nem felelt meg semmi a feltételnek.");
        }
    }
}
