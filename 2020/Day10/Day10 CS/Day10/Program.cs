using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = File.ReadAllLines("input.txt").Select(int.Parse).ToList();
            list.Sort();
            list.Insert(0, 0);
            list.Add(list[list.Count - 1] + 3);
            int _3 = 0;
            int _1 = 0;
            for (int i = 1; i < list.Count; i++)
            {
                switch (list[i] - list[i - 1])
                {
                    case 1:
                        _1++;
                        break;
                    case 3:
                        _3++;
                        break;
                }
            }
            Console.WriteLine(_1*_3);
            Console.ReadKey();
        }
    }
}
