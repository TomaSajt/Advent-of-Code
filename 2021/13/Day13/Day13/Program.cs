using System.Text;

var board = new HashSet<(int x, int y)>();
using (var sr = new StreamReader("input.txt"))
{
    string l;
    while (true)
    {
        l = sr.ReadLine();
        if (l == "") break;
        board.Add((int.Parse(l.Split(',')[0]), int.Parse(l.Split(',')[1])));
    }
    while (!sr.EndOfStream)
    {
        l = sr.ReadLine();
        Fold(int.Parse(l[13..]), l[11] == 'x');
    }
}
Log();

void Fold(int pos, bool alongX)
{
    var old = board;
    board = new HashSet<(int, int)>();
    foreach (var (x, y) in old)
    {
        if (alongX) board.Add((pos - Math.Abs(x - pos), y));
        else board.Add((x, pos - Math.Abs(y - pos)));
    }
}
void Log()
{
    int w = board.Max(t => t.x), h = board.Max(t=>t.y);
    var sb = new StringBuilder();
    for (int j = 0; j <= h; j++)
    {
        for (int i = 0; i <= w; i++)
        {
            sb.Append(board.Contains((i, j)) ? "#" : ".");
        }
        sb.AppendLine();
    }
    Console.WriteLine(sb);
}