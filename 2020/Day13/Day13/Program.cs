using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day13
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            int earliest = int.Parse(sr.ReadLine());
            List<int> buses = sr.ReadLine().Split(",").Where(str => str != "x").Select(int.Parse).ToList();
            List<int> waitTimes = buses.Select(period => (earliest-1)/period*period+period-earliest).ToList();
            int minWaitTime = waitTimes.Min();
            Console.WriteLine(buses[waitTimes.IndexOf(minWaitTime)]*minWaitTime);
            Console.ReadKey();
        }
    }
}
