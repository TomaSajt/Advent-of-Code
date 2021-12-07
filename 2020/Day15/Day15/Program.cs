using System;
using System.Collections.Generic;
using System.Linq;

namespace Day15
{
    class Program
    {
        static void Main(string[] args)
        {
            int turn = 1;
            int prev = -1;
            Dictionary<int, int> turnLastSpoken = new Dictionary<int, int>();
            int[] arr = new int[] { 5, 2, 8, 16, 18, 0, 1 };
            for (int i = 0; i < arr.Length; i++)
            {
                turnLastSpoken[arr[i]] = turn;
                prev = arr[i];
                turn++;
            }
            for (int i = 0; turn <= 30000000; i++)
            {
                int curr = turnLastSpoken.ContainsKey(prev) ? turn - turnLastSpoken[prev] - 1 : 0;
                turnLastSpoken[prev] = turn - 1;
                prev = curr;
                if (turn == 2020) Console.WriteLine("15.1: " + curr);
                if (turn == 30000000) Console.WriteLine("15.2: " + curr);
                turn++;
            }
            Console.ReadKey();
        }
    }
}
