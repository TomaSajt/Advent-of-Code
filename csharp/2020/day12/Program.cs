using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day12
{
	class Ship
	{
		protected int posX = 0;
		protected int posY = 0;
		public int ManhattanDistance()
		{
			return Math.Abs(posX) + Math.Abs(posY);
		}
		static void Main(string[] args)
		{
			var list = File.ReadAllLines("input.txt").Select(str => new KeyValuePair<char, int>(str[0], int.Parse(str.Substring(1)))).ToList();
			Console.WriteLine(new Ship1(list).ManhattanDistance());
			Console.WriteLine(new Ship2(list).ManhattanDistance());
			Console.ReadKey();
		}
	}
	class Ship1 : Ship
	{
		private int dir; //East 0; South 1; West 2; North 3
		public int Dir { get { return dir; } set { dir = (value % 4 + 4) % 4; } }
		public Ship1(List<KeyValuePair<char, int>> list)
		{
			foreach (var currOp in list)
			{
				if (currOp.Key == 'N' || (currOp.Key == 'F' && dir == 3)) posX += currOp.Value;
				else if (currOp.Key == 'E' || (currOp.Key == 'F' && dir == 0)) posY += currOp.Value;
				else if (currOp.Key == 'S' || (currOp.Key == 'F' && dir == 1)) posX -= currOp.Value;
				else if (currOp.Key == 'W' || (currOp.Key == 'F' && dir == 2)) posY -= currOp.Value;
				else if (currOp.Key == 'R') Dir += currOp.Value / 90;
				else if (currOp.Key == 'L') Dir -= currOp.Value / 90;
			}
		}
	}
	class Ship2 : Ship
	{
		int waypointX = 10;
		int waypointY = 1;
		public Ship2(List<KeyValuePair<char, int>> list)
		{

			foreach (var currOp in list)
			{
				if (currOp.Key == 'N') waypointY += currOp.Value;
				else if (currOp.Key == 'E') waypointX += currOp.Value;
				else if (currOp.Key == 'S') waypointY -= currOp.Value;
				else if (currOp.Key == 'W') waypointX -= currOp.Value;
				else if (currOp.Key == 'R') RotateWaypoint(currOp.Value / 90);
				else if (currOp.Key == 'L') RotateWaypoint(-currOp.Value / 90);
				else if (currOp.Key == 'F') (posX, posY) = (posX + waypointX * currOp.Value, posY + waypointY * currOp.Value);
			}
		}
		private void RotateWaypoint(int val)
		{
			val = (val % 4 + 4) % 4;
			for (int i = 0; i < val; i++)
			{
				(waypointX, waypointY) = (waypointY, -waypointX);
			}
		}
	}
}
