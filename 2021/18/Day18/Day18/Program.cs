// *TODO* Actually do this


{

    string num1 = "[[[42012,[4,3]],4],[7,[[8,4],9]]]";
    string num2 = "[1,1]";
    Console.WriteLine(Add(num1, num2));
}

string Add(string num1, string num2)
{
    string num = $"[{num1},{num2}]";
    if (TryExplode(num, out var res)) num = res!;
    return num;
    /*
while (true)
{
    if (TryExplode(ref num)) continue;
    if (TrySplit(ref num)) continue;
    break;
}*/

}

// LeftLeftLeft LeftLeftNum LeftLeftRight LeftVal , RightVal


bool TryExplode(string num, out string? res)
{
    int count = 0;
    for (int i = 0; i < num.Length; i++)
    {
        if (num[i] == '[') count++;
        else if (num[i] == ']') count--;
        if (count == 5)
        {
            int clInd = i, crInd = num.IndexOf(']', i);
            string LeftSide = num[..clInd], RightSide = num[(crInd+1)..];
            var sp = num[(clInd + 1)..crInd].Split(',');
            int LeftVal = int.Parse(sp[0]), RightVal = int.Parse(sp[1]);

            int a = Array.FindLastIndex(LeftSide.ToCharArray(), c => !IsDividerChar(c));
            if (a!=-1)
            {
                var temp = LeftSide[..(a + 1)];
                int lllInd = Array.FindLastIndex(temp.ToCharArray(), IsDividerChar);
                var LLL = LeftSide[..(lllInd + 1)];
                var LLV = int.Parse(LeftSide[(lllInd + 1)..(a + 1)]);
                var LLR = LeftSide[(a + 1)..];
                LLV += LeftVal;
                LeftSide = $"{LLL}{LLV}{LLR}";
            }
            a = Array.FindIndex(RightSide.ToCharArray(), IsDividerChar);
            
            if (a != -1)
            {
                var temp = RightSide[a..];
                int rrrInd = Array.FindIndex(temp.ToCharArray(), a, c => !IsDividerChar(c));
                var RRR = RightSide[rrrInd..];
                var pog = temp[(a + 1)..(rrrInd + 1)];
                var RRV = int.Parse(pog);
                var RRL = RightSide[..a];
                RRV += RightVal;
                RightSide = $"{RRL}{RRV}{RRR}";
            }



            Console.WriteLine($"{LeftSide}0{RightSide}");
            res = num;
            return true;
        }
    }
    res = null;
    return false;
}
bool IsDividerChar(char c) => c == ',' || c == ']' || c == '[';
bool TrySplit(ref string num)
{
    return true;
}