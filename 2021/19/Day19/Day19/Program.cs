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

    

    /*
    (nx,py,pz),
    (nz,px,py),
    (ny,pz,px),

    (nx,pz,ny),
    (ny,px,nz),
    (nz,py,nx),

    (nx,nz,py),
    (ny,nx,pz),
    (nz,ny,px),

    (nx,ny,nz),
    (nz,nx,ny),
    (ny,nz,nx),

    (px,pz,py),
    (py,px,pz),
    (pz,py,px),

    (px,py,nz),
    (pz,px,ny),
    (py,pz,nx),

    (px,ny,pz),
    (pz,nx,py),
    (py,nz,px),

    (px,nz,ny),
    (py,nx,nz),
    (pz,ny,nx)*/
};



var scanners = File.ReadAllText("input.txt").Split("\r\n\r\n").Select(sctext =>
{
    var sp = sctext.Split("\r\n").ToList();
    sp.RemoveAt(0);
    sp.RemoveAt(sp.Count - 1);
    var t = sp.Select(l => l.Split(',')).ToList();
    return t.Select(s => (Vec3D)(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]))).ToHashSet();
}).ToList();

scanners[0] = scanners[0].Select(x => x - scanners[0].First()).ToHashSet();

for (int i = 0; i < scanners.Count; i++)
{
    for (int j = 1; j < scanners.Count; j++)
    {
        var res = TryUnite(scanners[0], scanners[j]);
        if (res is null) continue;
        scanners[0] = res;
    }
}

/*
for (int k = 0; k < scanners.Count; k++)
{
    for (int i = 0; i < scanners.Count; i++)
    {
        for (int j = 0; j < scanners.Count; j++)
        {
            var res = TryUnite(scanners[i], scanners[j]);
            if (res is null) continue;
            scanners[i] = res;
        }
    }
}*/

HashSet<Vec3D>? TryUnite(HashSet<Vec3D> sc0, HashSet<Vec3D> sc1)
{
    var offset0 = sc0.First();
    var set0 = new List<Vec3D>(sc0).Select(v => v - offset0).ToHashSet();
    int i = 0;
    foreach (var ori in orientations3D)
    {
        var tr = sc1.Select(x => x.Transform(ori));
        foreach (var offset1 in tr)
        {
            var set1 = tr.Select(x => x - offset1).ToHashSet();
            var c = set0.Intersect(set1).Count();
            //Console.WriteLine(c);
            if (c >= 12)
            {
                Console.WriteLine($"Found intersection at ori {i} of size {c}");
                set1.Log();
                return set0.Union(set1).ToHashSet();
            }
        }
        i++;
    }
    Console.WriteLine("Didn't find an intersection :'(");
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