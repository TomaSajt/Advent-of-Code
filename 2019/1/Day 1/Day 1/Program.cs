Console.Write(File.ReadAllLines("input.txt").Select(int.Parse).Select(n => n / 3 - 2).Sum());

Console.Write(File.ReadAllLines("input.txt").Select(int.Parse).Select(CalcFuel).Sum());

int CalcFuel(int n)
{
    int f = n / 3 - 2;
    if (f <= 0) return 0;
    return f + CalcFuel(f);
}