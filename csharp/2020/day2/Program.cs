using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day2
{
	class Program
	{
		static void Main(string[] args)
		{
			string[][] arr = new List<string>(File.ReadAllLines("input.txt")).ConvertAll<string[]>((mes) => mes.Replace(":", "").Split(new string[] { "-", " " }, StringSplitOptions.None)).ToArray();
			int invalid = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				char ch = Convert.ToChar(arr[i][2]);
				if (arr[i][3][int.Parse(arr[i][0]) - 1] == ch ^ arr[i][3][int.Parse(arr[i][1]) - 1] == ch) invalid++;
			}
			Console.WriteLine(invalid);
			Console.ReadKey();
		}
	}
}
