var lines = File.ReadAllLines("input.txt");
var pairs = lines.Select(x => new { a = x[0] - 'A', b = x[2] - 'X' });
var res1 = pairs.Sum(x => x.b + x.a + 3 * ((x.b - x.a + 4) % 3));
var res2 = pairs.Sum(x => (x.a + x.b + 2) % 3 + 1 + 3 * x.b);
Console.WriteLine($"{res1} {res2}");