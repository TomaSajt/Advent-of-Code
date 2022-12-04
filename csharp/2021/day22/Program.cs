var inputR = File.ReadAllLines("input.txt").Reverse()
    .Select(l => (on: l[1] == 'n', sp: l[(l.IndexOf(' ') + 1)..].Split(',')))
    .Select(t => (t.on, xrsp: t.sp[0][2..].Split(".."), yrsp: t.sp[1][2..].Split(".."), zrsp: t.sp[2][2..].Split("..")))
    .Select(t => (
    t.on,
    x0: int.Parse(t.xrsp[0]),
    x1: int.Parse(t.xrsp[1]),
    y0: int.Parse(t.yrsp[0]),
    y1: int.Parse(t.yrsp[1]),
    z0: int.Parse(t.zrsp[0]),
    z1: int.Parse(t.zrsp[1])));
int res = 0;
for (int x = -50; x <= 50; x++)
{
    for (int y = -50; y <= 50; y++)
    {
        for (int z = -50; z <= 50; z++)
        {
            foreach (var (on, x0, x1, y0, y1, z0, z1) in inputR)
            {
                if (x >= x0 && y >= y0 && z >= z0 && x <= x1 && y <= y1 && z <= z1)
                {
                    if (on) res++;
                    break;

                }
                    
            }
        }
    }
}
Console.WriteLine(res);