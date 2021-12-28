var nums = File.ReadAllLines("input.txt");
Console.WriteLine(Magnitude(nums.Aggregate(Add)));
int max = -1;
for (int i = 0; i < nums.Length; i++)
    for (int j = 0; j < nums.Length; j++)
        if (i != j) max = Math.Max(max, Magnitude(Add(nums[i], nums[j])));
Console.WriteLine(max);

int Magnitude(string num)
{
    if (num.Length == 1 && char.IsDigit(num[0])) return int.Parse(num);
    int c = 0;
    for (int i = 1; i < num.Length - 1; i++)
        if (num[i] == '[') c++;
        else if (num[i] == ']') c--;
        else if (c == 0 && num[i] == ',') return 3 * Magnitude(num[1..i]) + 2 * Magnitude(num[(i + 1)..^1]);
    throw new Exception("This should never happen");
}

string Add(string num1, string num2)
{
    string num = $"[{num1},{num2}]";
    while (TryExplode(ref num) || TrySplit(ref num)) ;
    return num;
}

bool TryExplode(ref string N)
{
    int count = 0;
    for (int i = 0; i < N.Length; i++)
    {
        if (N[i] == '[') count++;
        else if (N[i] == ']') count--;
        if (count != 5) continue;
        int j = N.IndexOf(']', i);
        string L = N[..i], R = N[(j + 1)..];
        var sp = N[(i + 1)..j].Split(',');
        int CLV = int.Parse(sp[0]), CRV = int.Parse(sp[1]);
        int a = Array.FindLastIndex(L.ToCharArray(), char.IsDigit);
        if (a++ != -1)
        {
            int LLI = Array.FindLastIndex(L[..a].ToCharArray(), c => !char.IsDigit(c)) + 1;
            L = $"{L[..LLI]}{int.Parse(L[LLI..a]) + CLV}{L[a..]}";
        }
        a = Array.FindIndex(R.ToCharArray(), char.IsDigit);
        if (a != -1)
        {
            int RRI = Array.FindIndex(R.ToCharArray(), a, c => !char.IsDigit(c));
            R = $"{R[..a]}{int.Parse(R[a..RRI]) + CRV}{R[RRI..]}";
        }
        N = $"{L}0{R}";
        return true;
    }
    return false;
}
bool TrySplit(ref string num)
{
    for (int i = 0; i < num.Length - 1; i++)
    {
        if (!char.IsDigit(num[i]) || !char.IsDigit(num[i + 1])) continue;
        int j = i + 1;
        while (char.IsDigit(num[j])) j++;
        string Left = num[..i], Right = num[j..];
        int Value = int.Parse(num[i..j]);
        num = $"{Left}[{Value / 2},{(Value + 1) / 2}]{Right}";
        return true;
    }
    return false;
}