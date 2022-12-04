using System.Collections;

string[] lines = File.ReadAllLines("input.txt");
for (int i = 1; i < 9; i++)
{
    ALU alu = new(new DigitSupplier($"{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}{i}"));
    foreach (var line in lines) alu.Execute(line.Split(' '));
    Console.WriteLine(alu['z']);
}

abstract class Supplier<T> : IEnumerable<T>
{
    readonly T[] arr;
    int ptr = 0;
    protected Supplier(T[] arr) => this.arr = arr;
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public IEnumerator<T> GetEnumerator()
    {
        while (ptr < arr.Length) yield return arr[ptr++];
    }
}
class DigitSupplier : Supplier<char>
{
    public DigitSupplier(string text) : base(text.ToCharArray()) { }
}
class ALU
{
    readonly DigitSupplier digitSupplier;
    readonly long[] mem = new long[4];
    public ALU(DigitSupplier digitSupplier) => this.digitSupplier = digitSupplier;
    public long this[char index]
    {
        get => mem[index - 'w'];
        set => mem[index - 'w'] = value;
    }
    public void Execute(params string[] args)
    {
        string inst = args[0];
        string arg1 = args[1];
        if (inst == "inp")
        {
            this[arg1[0]] = digitSupplier.First() - '0';
            return;
        }
        string arg2 = args[2];
        long second = arg2[0] >= 'w' ? this[arg2[0]] : long.Parse(arg2);
        char fi = args[1][0];
        this[fi] = inst switch
        {
            "add" => this[fi] + second,
            "mul" => this[fi] * second,
            "div" => this[fi] / second,
            "mod" => this[fi] % second,
            "eql" => this[fi] == second ? 1 : 0,
            _ => throw new NotSupportedException("Unknown instruction"),
        };
    }
}