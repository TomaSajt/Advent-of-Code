// part 1 is 80 instead of 256

var sp = File.ReadAllText("input.txt").Split(',').Select(long.Parse);
var feesh = new long[9];
foreach (var f in sp) feesh[f]++;
for (int i = 0; i < 256; i++) {
  long tmp = feesh[0];
  for (int j = 0; j <= 7; j++) feesh[j] = feesh[j + 1];
  feesh[8] = tmp;
  feesh[6] += tmp;
}
Console.WriteLine(feesh.Sum());