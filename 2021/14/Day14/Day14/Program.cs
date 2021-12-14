var fileS = File.ReadAllText("input.txt").Trim().Split("\r\n\r\n");
var poly = fileS[0];
var pairCounts = new Dictionary<string, long>();
var map = fileS[1].Split("\r\n").ToDictionary(k => k[0..2], k => k[6]);
void Inc(string k, long v)
{
    if (!pairCounts.TryAdd(k, v)) pairCounts[k] += v;
}
for (int i = 0; i < poly.Length - 1; i++) Inc(poly[i..(i + 2)], 1);
for (int i = 0; i < 40; i++)
{
    var old = pairCounts;
    pairCounts = new Dictionary<string, long>();
    foreach (var (pair, count) in old)
    {
        if (map.ContainsKey(pair))
        {
            Inc($"{pair[0]}{map[pair]}", count);
            Inc($"{map[pair]}{pair[1]}", count);
        }
        else Inc(pair, count);
    }
}
var letterCounts = pairCounts.GroupBy(a => a.Key[0]).ToDictionary(g => g.Key, g => g.Sum(a => a.Value));
letterCounts[poly[^1]]++;
Console.WriteLine(letterCounts.Max(kvp => kvp.Value) - letterCounts.Min(kvp => kvp.Value));