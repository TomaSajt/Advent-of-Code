var input = File.ReadAllText("input.txt").Trim()[13..].Split(", ").Select(x => x[2..].Split("..")).Select(x => (l: int.Parse(x[0]), u: int.Parse(x[1]))).ToList();
var (lx, ux) = input[0];
var (ly, uy) = input[1];
Console.WriteLine((ly + 1) * ly / 2);