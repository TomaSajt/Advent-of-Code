using System.Diagnostics;

var sw = Stopwatch.StartNew();
var input = File.ReadAllText("input.txt").Trim().Split("\r\n\r\n");
var algo = input[0].Select(c => c == '#').ToArray();
var spImage = input[1].Split("\r\n");
int h = spImage.Length;
int w = spImage[0].Length;
var image = new bool[h, w];
var bg = false;
for (int i = 0; i < h; i++)
    for (int j = 0; j < w; j++)
        image[i, j] = spImage[i][j] == '#';
for (int i = 0; i < 50; i++) Enhance();
Console.WriteLine(image.Cast<bool>().Count(b => b));
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);
bool getAt(int i, int j) => i >= 0 && i < h && j >= 0 && j < w ? image[i, j] : bg;
bool applyKernel(int i, int j)
{
    int res = 0;
    for (int k = -1; k <= 1; k++)
        for (int l = -1; l <= 1; l++)
        {
            res <<= 1;
            if (getAt(i + k, j + l)) res++;
        }
    return algo[res];
}
void Enhance()
{
    var newImage = new bool[h + 2, w + 2];
    for (int i = -1; i < h + 1; i++)
        for (int j = -1; j < w + 1; j++)
            newImage[i + 1, j + 1] = applyKernel(i, j);
    image = newImage;
    w += 2;
    h += 2;
    bg = bg ? algo[511] : algo[0];
}