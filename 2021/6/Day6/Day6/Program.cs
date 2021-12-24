var input = File.ReadAllText("input.txt").Split(',').Select(int.Parse);
var sol1 = Enumerable.Range(0, input.Max() + 1).Min(i => input.Select(d => Math.Abs(i - d)).Sum());
var sol2 = Enumerable.Range(0, input.Max() + 1).Min(i => input.Select(d => Math.Abs(i - d)).Select(n => n * (n + 1) / 2).Sum());
Console.WriteLine($"{sol1}\n{sol2}");