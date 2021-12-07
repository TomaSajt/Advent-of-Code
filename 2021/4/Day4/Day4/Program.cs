
using var f = new StreamReader("input.txt");
var draws = f.ReadLine().Split(',').Select(int.Parse);
f.ReadLine();
var boards = f.ReadToEnd().Split("\r\n\r\n").Select(b => b.Split("\r\n").Select(l => l.Split(' ').Where(s => s != "").Select(int.Parse).ToArray()).ToArray()).ToArray();
var colss = new int[boards.Length, 5];
var rowss = new int[boards.Length, 5];
foreach (var draw in draws)
{
    for (int i = 0; i < boards.Length; i++)
    {
        if (MarkBoard(i, draw))
        {
            Console.WriteLine(BS(i) * draw);
            return;
        }
    }
}
int BS(int ind)
{
    int s = 0;
    for (int i = 0; i < 5; i++) for (int j = 0; j < 5; j++) if (boards[ind][i][j] != -1) s += boards[ind][i][j];
    return s;
}
bool MarkBoard(int ind, int draw)
{
    for (int i = 0; i < 5; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            if (boards[ind][i][j] == draw)
            {
                rowss[ind, i]++;
                colss[ind, j]++;
                boards[ind][i][j] = -1;
                if (rowss[ind, i] == 5 || colss[ind, j] == 5) return true;
            }
        }
    }
    return false;
}

//using var f = new StreamReader("input.txt");
//var draws = f.ReadLine().Split(',').Select(int.Parse);
//f.ReadLine();
//var boards = f.ReadToEnd().Split("\r\n\r\n").Select(b => b.Split("\r\n").Select(l => l.Split(' ').Where(s => s != "").Select(int.Parse).ToArray()).ToArray()).ToArray();
//var colss = new int[boards.Length, 5];
//var rowss = new int[boards.Length, 5];
//var done = new HashSet<int>();
//foreach (var draw in draws)
//{
//    for (int i = 0; i < boards.Length; i++)
//    {
//        if (!done.Contains(i) && MarkBoard(i, draw))
//        {
//            done.Add(i);
//            if (done.Count == boards.Length)
//            {
//                Console.WriteLine(BS(i) * draw);
//                return;
//            }
//        }
//    }
//}
//int BS(int ind)
//{
//    int s = 0;
//    for (int i = 0; i < 5; i++) for (int j = 0; j < 5; j++) if (boards[ind][i][j] != -1) s += boards[ind][i][j];
//    return s;
//}
//bool MarkBoard(int ind, int draw)
//{
//    for (int i = 0; i < 5; i++)
//    {
//        for (int j = 0; j < 5; j++)
//        {
//            if (boards[ind][i][j] == draw)
//            {
//                rowss[ind, i]++;
//                colss[ind, j]++;
//                boards[ind][i][j] = -1;
//                if (rowss[ind, i] == 5 || colss[ind, j] == 5) return true;
//            }
//        }
//    }
//    return false;
//}
