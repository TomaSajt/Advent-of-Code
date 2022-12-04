using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Day11
{
    class Program
    {
		static void Main(string[] args)
		{

			Console.WriteLine($"1: {Solution(false, 4)}, 2: {Solution(true, 5)}");
			Console.ReadKey();
		}
		private static int Solution(bool isRadar, int lim)
		{
			int[,] board = GetBoard();
			int[,] oldBoard;
			while (true)
			{
				oldBoard = (int[,])board.Clone();
				board = Step(oldBoard, isRadar, lim);
				if (oldBoard.Cast<int>().SequenceEqual(board.Cast<int>())) break;
			}
			return oldBoard.Cast<int>().Where(num => num == 2).Count();
		}
		private static int[,] GetBoard()
		{
			int[][] jagB = File.ReadAllLines("input.txt").Select(str => str.Select(ch => ch == 'L' ? 1 : 0).ToArray()).ToArray();
			int hgt = jagB.Length;
			int wdt = jagB[0].Length;
			int[,] board = new int[hgt, wdt];
			for (int j = 0; j < wdt; j++)
			{
				for (int i = 0; i < hgt; i++)
				{
					board[i, j] = jagB[i][j];
				}
			}
			return board;
		}
		private static int[,] Step(int[,] oldB, bool isRadar, int lim)
		{
			int wdt = oldB.GetLength(0);
			int hgt = oldB.GetLength(1);
			int[,] newB = new int[wdt, hgt];
			for (int j = 0; j < hgt; j++)
			{
				for (int i = 0; i < wdt; i++)
				{
					if (oldB[i, j] == 0) continue;
					int adj = 0;
					(int, int)[] offsets = { (1, 0), (1, 1), (0, 1), (-1, 1), (-1, 0), (-1, -1), (0, -1), (1, -1) };
					foreach (var offset in offsets)
					{
						int k = 1;
						do
						{
							int x = i + k * offset.Item1;
							int y = j + k * offset.Item2;
							if (x < 0 || y < 0 || x >= wdt || y >= hgt) break;
							if (oldB[x, y] > 0)
							{
								if (oldB[x, y] == 2) adj++;
								break;
							}
							k++;
						} while (isRadar);
					}
					if (adj == 0) newB[i, j] = 2;
					else if (adj >= lim) newB[i, j] = 1;
					else newB[i, j] = oldB[i, j];
				}
			}
			return newB;
		}
	}
}