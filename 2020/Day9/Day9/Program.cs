using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long[] data = File.ReadAllLines("input.txt").Select(long.Parse).ToArray();
            long invalid = findInvalid(data);
            Console.WriteLine("9.1: " + invalid);
            Console.WriteLine("9.2: " + encryptionWeakness(data, invalid));
            sw.Stop();
            Console.WriteLine("Elapsed milliseconds: "+sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
        static long findInvalid(long[] arr)
        {
            for (int i = 25; i < arr.Length; i++)
            {
                if (!twoSum(arr, i, 25))
                {
                    return arr[i];
                }
            }
            return -1;
        }

        static bool twoSum(long[] arr, int pos, int pre)
        {
            HashSet<long> idk = new HashSet<long>();
            long S = arr[pos];
            for (int i = 1; i <= pre; i++)
            {
                long sumMinusElement = S - arr[pos - i];
                if (idk.Contains(sumMinusElement))
                {
                    return true;
                }
                idk.Add(arr[pos - i]);
            }
            return false;
        }

        static long encryptionWeakness(long[] arr, long invalid)
        {
            int[] endpoints = subArraySum(arr, invalid);
            int maxInd = endpoints[0];
            int minInd = endpoints[0];
            for (int i = endpoints[0] + 1; i <= endpoints[1]; i++)
            {
                if (arr[i] > arr[maxInd]) maxInd = i;
                if (arr[i] < arr[minInd]) minInd = i;
            }
            return arr[minInd] + arr[maxInd];
        }

        static int[] subArraySum(long[] arr, long sum)
        {
            long currSum = arr[0];
            int start = 0;
            int length = arr.Length;
            int i;
            for (i = 1; i <= length; i++)
            {
                while (currSum > sum && start < i - 1)
                {
                    currSum -= arr[start];
                    start++;
                }
                if (currSum == sum)
                {
                    return new int[] { start, i - 1 };
                }
                if (i < length) currSum += arr[i];
            }
            return new int[] { -1, -1 };
        }
    }
}
