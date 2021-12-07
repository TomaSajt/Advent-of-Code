var input = File.ReadAllLines("input.txt").Select(l => l.Split(" -> ").Select(s => s.Split(',').Select(int.Parse).ToList()).ToList()).Select(l => (x1: l[0][0], y1: l[0][1], x2: l[1][0], y2: l[1][1]));
int[,] board1 = new int[input.Max(l => Math.Max(l.x1, l.x2)) + 1, input.Max(l => Math.Max(l.y1, l.y2)) + 1], board2 = new int[board1.GetLength(0), board1.GetLength(1)];
foreach (var (x1, y1, x2, y2) in input)
{
    int sx = Math.Sign(x2 - x1), sy = Math.Sign(y2 - y1), n = Math.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));
    if (sx == 0 || sy == 0) for (int k = 0, i = x1, j = y1; k <= n; k++, i += sx, j += sy) board1[i, j]++;
    for (int k = 0, i = x1, j = y1; k <= n; k++, i += sx, j += sy) board2[i, j]++;
}
Console.WriteLine($"{board1.Cast<int>().Count(n => n >= 2)}\n{board2.Cast<int>().Count(n => n >= 2)}");