//1
Console.WriteLine(((Func<(int, int), int>)(((int x, int y) t) => t.x * t.y))(File.ReadAllLines("input.txt").Select(line => line.Split(' ')).Select(sp => (name: sp[0], count: int.Parse(sp[1]))).Aggregate((x: 0, y: 0), (val, inst) => inst.name == "down" ? (val.x, val.y + inst.count) : inst.name == "up" ? (val.x, val.y - inst.count) : (val.x + inst.count, val.y))));
Console.WriteLine(" ".Select(_ => File.ReadAllLines("input.txt").Select(line => line.Split(' ')).Select(sp => (name: sp[0], count: int.Parse(sp[1]))).Aggregate((x: 0, y: 0), (val, inst) => inst.name == "down" ? (val.x, val.y + inst.count) : inst.name == "up" ? (val.x, val.y - inst.count) : (val.x + inst.count, val.y))).Select(t => t.x * t.y).First());
//Kókusz
Console.WriteLine(" ".Select(_ => new StreamReader("input.txt").ReadToEnd().Split('\n')).Select(f => f.Sum(x => x.Split(' ')[0] == "down" ? int.Parse(x.Split(' ')[1]) : x.Split(' ')[0] == "up" ? -int.Parse(x.Split(' ')[1]) : 0) * f.Sum(x => x.Split(' ')[0] == "forward" ? int.Parse(x.Split(' ')[1]) : 0)).First());
//Kombó
Console.WriteLine(" ".Select(_ => File.ReadAllLines("input.txt").Select(x => (k: x.Split(' ')[0], v: int.Parse(x.Split(' ')[1])))).Select(f => f.Sum(x => x.k switch { "down" => x.v, "up" => -x.v, _ => 0 }) * f.Sum(x => x.k == "forward" ? x.v : 0)).First());



//2
Console.WriteLine(((Func<(int, int, int), int>)(((int x, int y, int aim) t) => t.x * t.y))(File.ReadAllLines("input.txt").Select(line => line.Split(' ')).Select(sp => (name: sp[0], count: int.Parse(sp[1]))).Aggregate((x: 0, y: 0, a: 0), (val, inst) => inst.name == "down" ? (val.x, val.y, val.a + inst.count) : inst.name == "up" ? (val.x, val.y, val.a - inst.count) : (val.x + inst.count, val.y + val.a * inst.count, val.a))));
Console.WriteLine(" ".Select(_ => File.ReadAllLines("input.txt").Select(line => line.Split(' ')).Select(sp => (name: sp[0], count: int.Parse(sp[1]))).Aggregate((x: 0, y: 0, a: 0), (val, inst) => inst.name == "down" ? (val.x, val.y, val.a + inst.count) : inst.name == "up" ? (val.x, val.y, val.a - inst.count) : (val.x + inst.count, val.y + val.a * inst.count, val.a))).Select(a => a.x * a.y).First());

//Kókusz
Console.WriteLine(" ".Select(_ => new StreamReader("input.txt").ReadToEnd().Split('\n')).Select(f => Enumerable.Range(1, f.Length - 1).Sum(x => f[x].Split(' ')[0] == "forward" ? Enumerable.Range(0, x).Select(y => f[y].Split(' ')).Sum(z => z[0] == "down" ? int.Parse(z[1]) : z[0] == "up" ? -int.Parse(z[1]) : 0) * int.Parse(f[x].Split(' ')[1]) : 0) * f.Sum(x => x.Split(' ')[0] == "forward" ? int.Parse(x.Split(' ')[1]) : 0)).First());

//Kombó
Console.WriteLine(" ".Select(_ => File.ReadAllLines("input.txt"))
    .Select(lines =>
    Enumerable.Range(1, lines.Length - 1)
    .Sum(x =>
    lines[x].Split(' ')[0] == "forward" ?
        Enumerable.Range(0, x)
            .Select(i => lines[i].Split(' '))
            .Sum(line =>
                line[0] == "down" ? int.Parse(line[1])
                : line[0] == "up" ? -int.Parse(line[1])
                : 0)
            * int.Parse(lines[x].Split(' ')[1]) : 0)

    * lines.Sum(line => line.Split(' ')[0] == "forward" ? int.Parse(line.Split(' ')[1]) : 0)).First());
Console.WriteLine(" ".Select(_ => File.ReadAllLines("input.txt").Select(x => (k: x.Split(' ')[0], v: int.Parse(x.Split(' ')[1]))).Aggregate((x: 0, y: 0, a: 0), (p, i) => i.k switch { "down" => (p.x, p.y, p.a + i.v), "up" => (p.x, p.y, p.a - i.v), _ => (p.x + i.v, p.y + p.a * i.v, p.a) })).Select(a => a.x * a.y).First());






Console.WriteLine(" ".Select(_ => File.ReadAllLines("input.txt").Select(x => (k: x.Split(' ')[0], v: int.Parse(x.Split(' ')[1])))).Select(f => f.Sum(x => x.k switch { "down" => x.v, "up" => -x.v, _ => 0 }) * f.Sum(x => x.k == "forward" ? x.v : 0)).First());
Console.WriteLine(" ".Select(_ => File.ReadAllLines("input.txt").Select(x => (k: x.Split(' ')[0], v: int.Parse(x.Split(' ')[1]))).Aggregate((x: 0, y: 0, a: 0), (p, i) => i.k switch { "down" => (p.x, p.y, p.a + i.v), "up" => (p.x, p.y, p.a - i.v), _ => (p.x + i.v, p.y + p.a * i.v, p.a) })).Select(a => a.x * a.y).First());
