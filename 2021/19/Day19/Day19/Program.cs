Vec3D px = (1, 0, 0), nx = (-1, 0, 0), py = (0, 1, 0), ny = (0, -1, 0), pz = (0, 0, 1), nz = (0, 0, -1);

var orientations = new (Vec3D rx, Vec3D ry, Vec3D rz)[] {
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

var N = scanners.Count;
var unions = new HashSet<Vec3D>?[N, N];

for (int i = 0; i < N; i++)
{
    for (int j = 0; j < N; j++)
    {
        if (i == j || scanners[i].Count == 0 || scanners[j].Count == 0) continue;
        unions[i, j] = TryUnite(i, j);
    }
}


HashSet<Vec3D>? TryUnite(int i, int j)
{
    var offset0 = scanners[i].First();
    int oInd = 0;
    foreach (var orientation in orientations)
    {
        var tr = scanners[j].Select(x => x.Transform(orientation)); //mátrix-transzformáció az orientáció alapján
        foreach (var offset1 in tr)
        {
            var offsetSet = tr.Select(x => x - offset1 + offset0).ToHashSet(); // ráhelyezi az i. scanner első elemére a transzformált j. scanner jelenlegi elemét
            var c = scanners[i].Intersect(offsetSet).Count();
            if (c >= 12)
            {
                var union = scanners[i].Union(offsetSet).ToHashSet();
                Console.WriteLine($"i: {i,-3} j: {j,-3} orientation: {oInd,-3} intersect_size: {c,-3} union_size: {union.Count,-3}");
                return union;
            }
        }
        oInd++;
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