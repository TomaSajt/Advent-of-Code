using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            FerryMemory mem1 = new FerryMemory(false);
            FerryMemory mem2 = new FerryMemory(true);
            StreamReader sr = new StreamReader("input.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.StartsWith("mem"))
                {
                    long adr = long.Parse(line.Substring(4, line.IndexOf(']') - 4));
                    long val = long.Parse(line.Substring(line.IndexOf(']') + 4));
                    mem1[adr] = val;
                    mem2[adr] = val;
                }
                if (line.StartsWith("mask"))
                {
                    string mask = line.Substring(7);
                    mem1.Mask = mask;
                    mem2.Mask = mask;
                }
            }
            Console.WriteLine($"14.1: {mem1.Sum()}\n14.2: {mem2.Sum()}");
            Console.ReadKey();
        }
    }
    class FerryMemory
    {
        private Dictionary<long, long> mem = new Dictionary<long, long>();
        private string mask;
        private bool ver2;
        public FerryMemory(bool ver2)
        {
            this.ver2 = ver2;
        }
        public string Mask
        {
            get { return mask; }
            set
            {
                if (value.Length == 36) mask = value;
                else throw new ArgumentException("Bitmap length is not 36");
            }
        }
        public long this[long i]
        {
            get { try { return mem[i]; } catch { return 0; } }
            set
            {
                if (!ver2)
                {
                    long setBits = Convert.ToInt64(mask.Replace('X', '0'), 2);
                    long unsetBits = Convert.ToInt64(mask.Replace('1', 'X').Replace('0', '1').Replace('X', '0'), 2);
                    value |= setBits;
                    value = ~(~value | unsetBits);
                    mem[i] = value;
                }
                else
                {
                    long setBits = Convert.ToInt64(mask.Replace('X', '0'), 2);
                    long floatingBits = Convert.ToInt64(mask.Replace('1', '0').Replace('X', '1'), 2);
                    i |= setBits;
                    i = ~(~i | floatingBits);
                    long temp = floatingBits;
                    var list = new List<long>();
                    for (int j = 0; temp > 0; j++)
                    {
                        int bit = (int)(temp % 2);
                        temp /= 2;
                        if (bit == 1)
                        {
                            list.Add((long)1 << j);
                        }
                    }
                    for (long j = 0; j < (long)1 << list.Count; j++)
                    {
                        long sum = 0;
                        long t = j;
                        for (int k = 0; t > 0; k++)
                        {
                            if (t % 2 == 1) sum += list[k];
                            t /= 2;
                        }
                        mem[i + sum] = value;
                    }
                }
            }
        }
        public long Sum()
        {
            long sum = 0;
            foreach (var val in mem.Values) sum += val;
            return sum;
        }
    }
}
