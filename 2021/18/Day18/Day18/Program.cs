// *TODO* Actually do this


{

    string num1 = "[[[42012,[4,3]],4],[7,[[8,4],9]]]";
    string num2 = "[1,1]";
    Console.WriteLine(Add(num1, num2));
}

string Add(string num1, string num2)
{
    string num = $"[{num1},{num2}]";
    TryExplode(ref num);
    return num;
    /*
while (true)
{
    if (TryExplode(ref num)) continue;
    if (TrySplit(ref num)) continue;
    break;
}*/

}
bool TryExplode(ref string num)
{
    int i = 0;
    int count = 0;
    while (true)
    {
        if (num[i] == '[') count++;
        else if (num[i] == ']') count--;
        if (count == 5)
        {
            int l = i, r = num.IndexOf(']', i);
            var sp = num[(l + 1)..r].Split(',');
            int leftVal = int.Parse(sp[0]), rightVal = int.Parse(sp[1]);
            for (int j = l - 1; j >= 0; j--)
            {
                if (char.IsDigit(num[j]))
                {
                    int k;
                    for (k = j - 1; k >= 0 && char.IsDigit(num[k]); k--) ;
                    k++;
                    int number
                    Console.WriteLine(num[k..(j+1)]);
                    break;
                }
            }
            Console.WriteLine(num[l..(r + 1)]);
            break;
        }
        i++;
    }
    return true;
}
bool TrySplit(ref string num)
{
    return true;
}