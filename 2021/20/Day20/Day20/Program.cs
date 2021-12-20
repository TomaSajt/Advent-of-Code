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
    var newImage = new bool[h + 4, w + 4];
    for (int i = -2; i < h + 2; i++)
        for (int j = -2; j < w + 2; j++)
            newImage[i + 2, j + 2] = applyKernel(i, j);
    image = newImage;
    w += 4;
    h += 4;
    bg = bg ? algo[511] : algo[0];
}