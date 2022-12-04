using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day5_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(File.ReadAllText("input.txt").Split("\r\n").Select(str => str.ToList().Select((ch, i) => ch == 'B' || ch == 'R' ? (int)Math.Pow(2, 9 - i) : 0).ToList().Sum()).Max());
            
            int[] arr = File.ReadAllText("input.txt").Split("\r\n").Select(str => str.ToList().Select((ch, i) => ch == 'B' || ch == 'R' ? (int)Math.Pow(2, 9 - i) : 0).ToList().Sum()).ToArray();
            Array.Sort(arr);
            int length = arr.Length, a = 1, b = 2, i;
            while (true)
            {
                i = a * length / b;
                if (arr[i] - arr[i - 1] != 1) break;
                a *= 2;
                a += arr[i] == i + arr[0] ? 1 : -1;
                b *= 2;
            }
            Console.WriteLine(arr[i] - 1);
            Console.ReadKey();
        }
    }
}
