Console.WriteLine(File.ReadAllLines("input.txt").Select(l => l.Split('x')).Select(sp => (l: int.Parse(sp[0]), w: int.Parse(sp[1]), h: int.Parse(sp[2]))).Select(x =>
{
    List<int> sides = new() { x.l * x.w, x.l * x.h, x.w * x.h };
    sides.Sort();
    return 2 * sides.Sum() + sides[0];
}).Sum());


Console.WriteLine(File.ReadAllLines("input.txt").Select(l => l.Split('x')).Select(sp => (l: int.Parse(sp[0]), w: int.Parse(sp[1]), h: int.Parse(sp[2]))).Select(x =>
{
    List<int> lengths = new() { x.l, x.w, x.h };
    lengths.Sort();
    return 2 * (lengths[0] + lengths[1]) + x.l * x.w * x.h;
}).Sum());
