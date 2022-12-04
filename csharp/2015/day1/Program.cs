var input = File.ReadAllText("input.txt");
int n = 0;
int m = -1;
for (int i = 0; i < input.Length; i++)
{
    if (input[i] == '(') n++;
    else if (input[i] == ')') n--;
    if (m == -1 && n < 0) m = i;
}
Console.WriteLine($"{n}\n{m+1}");