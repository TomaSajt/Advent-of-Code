Console.WriteLine(File.ReadAllLines("input.txt").Select(l => l[(l.IndexOf('|') + 1)..]).Select(l => l.Split(' ').Count(s => s.Length > 1 && s.Length < 5 || s.Length == 7)).Sum());


Console.WriteLine(File.ReadAllLines("input.txt").Select(l => l.Split(" | ")).Select(s => Solve(s[0].Split(' ').Select(x => x.ToHashSet()).GroupBy(x => x.Count).ToDictionary(x => x.Key, x => x.ToList()), s[1].Split(' ').Select(x => x.ToHashSet()))).Sum());
static int Solve(Dictionary<int, List<HashSet<char>>> grouping, IEnumerable<HashSet<char>> digits)
{
    var sets = new HashSet<char>[10];
    sets[8] = grouping[7][0];
    sets[1] = grouping[2][0];
    sets[7] = grouping[3][0];
    sets[4] = grouping[4][0];
    var d = grouping[5][0].Intersect(grouping[5][1]).Intersect(grouping[5][2]).Intersect(sets[4]);
    sets[0] = grouping[6].Where(x => !x.Overlaps(d)).First();
    sets[6] = grouping[6].Where(x => x.Intersect(sets[1]).Count() != 2).First();
    sets[9] = grouping[6].Where(x => x != sets[6] && x != sets[0]).First();
    var c = sets[8].Except(sets[6]);
    var e = sets[8].Except(sets[9]);
    var f = sets[1].Except(c);
    sets[5] = grouping[5].Where(x => !x.Overlaps(c)).First();
    sets[2] = grouping[5].Where(x => !x.Overlaps(f)).First();
    sets[3] = grouping[5].Where(x => x != sets[2] && x != sets[5]).First();
    int n = 0;
    foreach (var di in digits)
    {
        for (int i = 0; i < 10; i++)
        {
            if (sets[i].SetEquals(di))
            {
                n += i;
                break;
            }
        }
        n *= 10;
    }
    return n / 10;
}