using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(new List<string>(File.ReadAllText("input.txt").Split("\r\n\r\n")).Where(data => new List<string>(data.Split(new string[] { "\r\n", " " }, StringSplitOptions.RemoveEmptyEntries)).Where(str =>
			{
				string val = str.Substring(4);
				switch (str.Substring(0, 3))
				{
					case "byr":
						int byr = int.Parse(val);
						return byr >= 1920 && byr <= 2002;
					case "iyr":
						int iyr = int.Parse(val);
						return iyr >= 2010 && iyr <= 2020;
					case "eyr":
						int eyr = int.Parse(val);
						return eyr >= 2020 && eyr <= 2030;
					case "hgt":
						bool cms = val.Substring(val.Length - 2) == "cm";
						bool inches = val.Substring(val.Length - 2) == "in";
						if (!(cms || inches)) return false;
						int hgt = int.Parse(val.Substring(0, val.Length - 2));
						return cms ? hgt >= 150 && hgt <= 193 : hgt >= 59 && hgt <= 76;
					case "hcl":
						if (val[0] != '#') return false;
						try
						{
							int.Parse(val.Substring(1), System.Globalization.NumberStyles.HexNumber);
							return true;
						}
						catch { }
						return false;
					case "ecl":
						return new List<string>(new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }).Any(s => s == val);
					case "pid":
						int pid;
						return val.Length == 9 && int.TryParse(val, out pid);
				}
				return false;
			}).Count() == 7).Count());
			Console.ReadKey();
		}
	}
}
