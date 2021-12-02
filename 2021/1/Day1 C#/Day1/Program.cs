
//var prev = int.MaxValue;
//int c = 0;
//foreach (var item in File.ReadAllLines("a.txt").Select(int.Parse))
//{
//    if (item > prev) c++;
//    prev = item;
//}
//Console.WriteLine(c);



var data = File.ReadAllLines("a.txt").Select(int.Parse).ToArray();
int sum = data[0] + data[1] + data[2];
var prev = sum;
int c = 0;
for (int i = 3; i < data.Length; i++)
{
    sum += data[i];
    sum -= data[i - 3];
    if (sum > prev) c++;
    prev = sum;
}
Console.WriteLine(c);