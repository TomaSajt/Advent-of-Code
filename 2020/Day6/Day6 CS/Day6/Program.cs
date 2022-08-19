using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            //Console.WriteLine(File.ReadAllText("input.txt").Split("\r\n\r\n").Select(group => group.Replace("\r\n", "").ToCharArray().Distinct().Count()).Sum());
            Console.WriteLine(File.ReadAllText("input.txt").Split("\r\n\r\n").Select(group =>group.Split("\r\n").Select(str => str.ToHashSet()).Aggregate((set1, set2) => set1.Intersect(set2).ToHashSet()).Count()).Sum());
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds +" milliseconds elapsed");
            Console.ReadKey();
        }
    }
}
