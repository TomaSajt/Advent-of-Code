//WHY DOESNT THIS WORK???


Vec3D px = (1, 0, 0), nx = (-1, 0, 0), py = (0, 1, 0), ny = (0, -1, 0), pz = (0, 0, 1), nz = (0, 0, -1);

var orientations3D = new (Vec3D rx, Vec3D ry, Vec3D rz)[] {
    (px,py,pz),
    (pz,px,py),
    (py,pz,px),

    (px,pz,ny),
    (py,px,nz),
    (pz,py,nx),

    (px,nz,py),
    (py,nx,pz),
    (pz,ny,px),

    (px,ny,nz),
    (pz,nx,ny),
    (py,nz,nx),

    (nx,pz,py),
    (ny,px,pz),
    (nz,py,px),

    (nx,py,nz),
    (nz,px,ny),
    (ny,pz,nx),

    (nx,ny,pz),
    (nz,nx,py),
    (ny,nz,px),

    (nx,nz,ny),
    (ny,nx,nz),
    (nz,ny,nx),
};



var scanners = File.ReadAllText("input.txt").Trim().Split("\r\n\r\n").Select(sctext =>
{
    var sp = sctext.Split("\r\n").ToList();
    sp.RemoveAt(0);
    var t = sp.Select(l => l.Split(',')).ToList();
    return t.Select(s => (Vec3D)(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]))).ToHashSet();
}).ToList();
Console.WriteLine();

for (int k = 0; k < scanners.Count; k++)
{
    for (int i = 0; i < scanners.Count; i++)
    {
        for (int j = 0; j < scanners.Count; j++)
        {
            if (i == j || scanners[i].Count < 1 || scanners[j].Count < 1) continue;
            var res = TryUnite(i, j);
        }
    }

}


HashSet<Vec3D>? TryUnite(int i, int j)
{
    var offset0 = scanners[i].First();
    int orind = 0;
    foreach (var or in orientations3D)
    {
        var tr = scanners[j].Select(x => x.Transform(or));
        foreach (var offset1 in tr)
        {
            var set1 = tr.Select(x => x - offset1 + offset0).ToHashSet();
            var c = scanners[i].Intersect(set1).Count();
            if (c >= 12)
            {
                var union = scanners[i].Union(set1).ToHashSet();
                Console.WriteLine($"i:{i} j:{j} size(i)={scanners[i].Count} size(j)={scanners[j].Count} ori {orind} intersect size={c} union size={union.Count}");
                return union;
            }
        }
        orind++;
    }
    return null;
}

record struct Vec3D(int X, int Y, int Z)
{
    public static Vec3D operator -(Vec3D v) => new(-v.X, -v.Y, -v.Z);
    public static Vec3D operator +(Vec3D v1, Vec3D v2) => new(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    public static Vec3D operator -(Vec3D v1, Vec3D v2) => v1 + -v2;
    public static Vec3D operator *(Vec3D v, int n) => new(n * v.X, n * v.Y, n * v.Z);
    public static Vec3D operator *(int n, Vec3D v) => v * n;
    public static implicit operator Vec3D((int ih, int jh, int kh) t) => new(t.ih, t.jh, t.kh);
    public Vec3D Transform((Vec3D rx, Vec3D ry, Vec3D rz) orientation) => X * orientation.rx + Y * orientation.ry + Z * orientation.rz;
}
public static class Extensions
{
    public static void Log<T>(this IEnumerable<T> list) => Console.WriteLine(string.Join('\n', list.Select(x => $"{x}")));
}