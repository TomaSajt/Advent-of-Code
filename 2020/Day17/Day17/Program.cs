using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17
{
    class Program
    {
        static void Main(string[] args)
        {
            Mem4D mem = new Mem4D();
            StreamReader sr = new StreamReader("input.txt");
            for (int j = 0; !sr.EndOfStream; j++)
            {
                string line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++) mem[i, j, 0, 0] = line[i] == '#';
            }

            for (int step = 1; step <= 6; step++)
            {
                Mem4D buf = new Mem4D();
                for (int l = mem.minW - 1; l <= mem.maxW + 1; l++)
                    for (int k = mem.minZ - 1; k <= mem.maxZ + 1; k++)
                        for (int j = mem.minY - 1; j <= mem.maxY + 1; j++)
                            for (int i = mem.minX - 1; i <= mem.maxX + 1; i++)
                            {
                                int count = mem.neighbourCount(i, j, k, l);
                                if (mem[i, j, k, l])
                                    buf[i, j, k, l] = count == 2 || count == 3;
                                else
                                    buf[i, j, k, l] = count == 3;
                            }
                mem = buf;
            }
            Console.WriteLine(mem.Count);
            Console.ReadKey();
        }
    }
    class Mem4D
    {
        HashSet<(int, int, int, int)> set = new HashSet<(int, int, int, int)>();
        public static List<(int x, int y, int z, int w)> offsets = new List<(int, int, int, int)>();
        static Mem4D()
        {
            for (int l = -1; l <= 1; l++)
                for (int k = -1; k <= 1; k++)
                    for (int j = -1; j <= 1; j++)
                        for (int i = -1; i <= 1; i++)
                            offsets.Add((i, j, k, l));
            offsets.Remove((0, 0, 0, 0));
        }
        public bool this[int x, int y, int z, int w]
        {
            get { return set.Contains((x, y, z, w)); }
            set { if (value) set.Add((x, y, z, w)); else set.Remove((x, y, z, w)); }
        }
        public int neighbourCount(int x, int y, int z, int w)
        {
            int count = 0;
            foreach (var ofs in offsets) if (this[x + ofs.x, y + ofs.y, z + ofs.z, w + ofs.w]) count++;
            return count;
        }
        public int Count { get { return set.Count; } }
        public int minX { get { return set.Min(tuple => tuple.Item1); } }
        public int maxX { get { return set.Max(tuple => tuple.Item1); } }
        public int minY { get { return set.Min(tuple => tuple.Item2); } }
        public int maxY { get { return set.Max(tuple => tuple.Item2); } }
        public int minZ { get { return set.Min(tuple => tuple.Item3); } }
        public int maxZ { get { return set.Max(tuple => tuple.Item3); } }
        public int minW { get { return set.Min(tuple => tuple.Item4); } }
        public int maxW { get { return set.Max(tuple => tuple.Item4); } }
    }
    /*class Program
    {
        static void Main(string[] args)
        {
            Mem3D mem = new Mem3D();
            StreamReader sr = new StreamReader("input.txt");
            for (int j = 0; !sr.EndOfStream; j++)
            {
                string line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++) mem[i, j, 0] = line[i] == '#';
            }

            for (int step = 1; step <= 6; step++)
            {
                Mem3D buf = new Mem3D();
                for (int k = mem.minZ - 1; k <= mem.maxZ + 1; k++)
                    for (int j = mem.minY - 1; j <= mem.maxY + 1; j++)
                        for (int i = mem.minX - 1; i <= mem.maxX + 1; i++)
                        {
                            int count = mem.neighbourCount(i, j, k);
                            if (mem[i, j, k])
                                buf[i, j, k] = count == 2 || count == 3;
                            else
                                buf[i, j, k] = count == 3;
                        }
                mem = buf;
            }
            Console.WriteLine(mem.Count);
            Console.ReadKey();
        }
    }
    class Mem3D
    {
        HashSet<(int, int, int)> set = new HashSet<(int, int, int)>();
        public static List<(int x, int y, int z)> offsets = new List<(int, int, int)>();
        static Mem3D()
        {
            for (int k = -1; k <= 1; k++)
                for (int j = -1; j <= 1; j++)
                    for (int i = -1; i <= 1; i++)
                        offsets.Add((i, j, k));
            offsets.Remove((0, 0, 0));
        }
        public bool this[int x, int y, int z]
        {
            get { return set.Contains((x, y, z)); }
            set { if (value) set.Add((x, y, z)); else set.Remove((x, y, z)); }
        }
        public int neighbourCount(int x, int y, int z)
        {
            int count = 0;
            foreach (var ofs in offsets) if (this[x + ofs.x, y + ofs.y, z + ofs.z]) count++;
            return count;
        }
        public int Count { get { return set.Count; } }
        public int minX { get { return set.Min(tuple => tuple.Item1); } }
        public int maxX { get { return set.Max(tuple => tuple.Item1); } }
        public int minY { get { return set.Min(tuple => tuple.Item2); } }
        public int maxY { get { return set.Max(tuple => tuple.Item2); } }
        public int minZ { get { return set.Min(tuple => tuple.Item3); } }
        public int maxZ { get { return set.Max(tuple => tuple.Item3); } }
    }*/
}
