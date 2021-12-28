var input = File.ReadAllLines("input.txt");
int h = input.Length, w = input[0].Length;
var board = new char[h, w];
for (int i = 0; i < h; ++i)
    for (int j = 0; j < w; ++j)
        board[i, j] = input[i][j];
int steps = 1;
while (Iterate()) steps++;
Console.WriteLine(steps);
bool Iterate()
{
    bool a = false;
    var old = board;
    var moved = new bool[h, w];
    board = new char[h, w];
    for (int i = 0; i < h; i++)
    {
        for (int j = 0; j < w; j++)
        {
            if (moved[i, j]) continue;
            int nx = (j + 1) % w;
            if (old[i, j] != '>' || old[i, nx] != '.')
            {
                board[i, j] = old[i, j];
                continue;
            }
            board[i, j] = '.';
            board[i, nx] = '>';
            moved[i, nx] = true;
            a = true;
        }
    }
    old = board;
    moved = new bool[h, w];
    board = new char[h, w];
    for (int i = 0; i < h; i++)
    {
        for (int j = 0; j < w; j++)
        {
            if (moved[i, j]) continue;
            int ny = (i + 1) % h;
            if (old[i, j] != 'v' || old[ny, j] != '.')
            {
                board[i, j] = old[i, j];
                continue;
            }
            board[i, j] = '.';
            board[ny, j] = 'v';
            moved[ny, j] = true;
            a = true;
        }
    }
    return a;
}