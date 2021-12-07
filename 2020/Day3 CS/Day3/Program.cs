using System;
using System.IO;

namespace Day3
{
	class Program
	{
		static string[] arr = File.ReadAllText("input2.txt").Split("\r\n");
		static int width = arr[0].Length;
		static void Main(string[] args)
		{
			Console.WriteLine("1.: " + CalcTree(3, 1));
			Console.WriteLine("2.: " + CalcTree(1, 1) * CalcTree(3, 1) * CalcTree(5, 1) * CalcTree(7, 1) * CalcTree(1, 2));
			Console.ReadLine();
		}
		static long CalcTree(int r, int d)
		{
			int trees = 0;
			for (int i = 0; i*d < arr.Length; i++)
			{
				if (arr[i * d][i * r % width] == '#') trees++;
			}
			return trees;
		}
	}
}
