////Part 1
//var input = File.ReadAllLines("input.txt");
//int g = 0, e = 0, w = input[0].Length, h = input.Length;
//for (int i = 0; i < w; i++)
//{
//    int ones = 0;
//    for (int j = 0; j < h; j++) if (input[j][i] == '1') ones++;
//    int v = 1 << (w - i - 1);
//    if (2 * ones >= h) g += v;
//    else e += v;
//}
//Console.WriteLine(g * e);

//Part 1
Console.WriteLine(" ".Select(_ => File.ReadAllLines("input.txt").SelectMany(x => x.Select((e, i) => (e, i))).GroupBy(x => x.i).Select(x => x.Select(y => y.e).ToList()).ToList()).Select(t => " ".Select(_ => t.Select(col => col.Count(c => c == '1')).Select((c, i) => 2 * c > t[0].Count ? 1 << (t.Count - i - 1) : 0).Sum()).Select(g => g * ((1 << t.Count) - g - 1)).First()).First());
////Part 2
//static int S(List<string> ls, bool b)
//{
//    int w = ls[0].Length;
//    for (int i = 0; i < w && ls.Count > 1; i++)
//    {
//        int ones = 0;
//        for (int j = 0; j < ls.Count; j++) if (ls[j][i] == '1') ones++;
//        char c = 2 * ones >= ls.Count == b ? '0' : '1';
//        ls = ls.Where(l => l[i] == c).ToList();
//    }
//    return Convert.ToInt32(ls.First(), 2);
//}
//List<string> ls1 = File.ReadAllLines("input.txt").ToList(), ls2 = new(ls1);
//Console.WriteLine(S(ls1, true) * S(ls2, false));

//static int S(List<string> ls, bool b)
//{
//    var transposed = ls.SelectMany(x => x.Select((e, i) => (e, i))).GroupBy(x => x.i).Select(x => x.Select(y => y.Item1).ToList()).ToList();
//    var sums = transposed.Select(col => col.Count(c => c == '1'));
//    int w = ls[0].Length;
//    for (int i = 0; i < w && ls.Count > 1; i++)
//    {
//        int ones = 0;
//        for (int j = 0; j < ls.Count; j++) if (ls[j][i] == '1') ones++;
//        char c = 2 * ones >= ls.Count == b ? '0' : '1';
//        ls = ls.Where(l => l[i] == c).ToList();
//    }
//    return Convert.ToInt32(ls.First(), 2);
//}
//List<string> ls = File.ReadAllLines("input.txt").ToList();
//Console.WriteLine(S(ls, true) * S(ls, false));