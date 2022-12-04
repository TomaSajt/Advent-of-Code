var input = File.ReadAllLines("input.txt").Select(x => x.ToCharArray()).ToArray();
int h = input.Length, w = input[0].Length;
var moved = new int[h, w];
int m = 0;
int steps = 0;
bool a;
do
{
    a = false;
    m++;
    for (int i = 0; i < h; i++)
    {
        for (int j = 0; j < w; j++)
        {
            int nx = (j + 1) % w;
            if (moved[i, j] == m || moved[i, nx] == m || input[i][j] != '>' || input[i][nx] != '.') continue;
            input[i][j] = '.';
            input[i][nx] = '>';
            moved[i, j] = moved[i, nx] = m;
            a = true;
        }
    }
    m++;
    for (int i = 0; i < h; i++)
    {
        for (int j = 0; j < w; j++)
        {
            int ny = (i + 1) % h;
            if (moved[i, j] == m || moved[ny, j] == m || input[i][j] != 'v' || input[ny][j] != '.') continue;
            input[i][j] = '.';
            input[ny][j] = 'v';
            moved[i, j] = moved[ny, j] = m;
            a = true;
        }
    }
    steps++;
} while (a);
Console.WriteLine(steps);