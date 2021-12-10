{
    var board = File.ReadAllLines("input.txt").Select(x => x.Select(c => c - '0').ToArray()).ToArray();
    bool InBound(int x, int y) => x >= 0 && y >= 0 && x < board.Length && y < board[x].Length;
    int risk = 0;
    for (int i = 0; i < board.Length; i++)
    {
        for (int j = 0; j < board[i].Length; j++)
        {
            if (InBound(i + 1, j) && board[i + 1][j] <= board[i][j]) continue;
            if (InBound(i - 1, j) && board[i - 1][j] <= board[i][j]) continue;
            if (InBound(i, j + 1) && board[i][j + 1] <= board[i][j]) continue;
            if (InBound(i, j - 1) && board[i][j - 1] <= board[i][j]) continue;
            risk += 1 + board[i][j];
        }
    }
    Console.WriteLine(risk);
}

{
    var board = File.ReadAllLines("input.txt").Select(x => x.Select(c => c - '0').ToArray()).ToArray();
    var offsets = new List<(int dx, int dy)>() { (1, 0), (0, 1), (-1, 0), (0, -1) };
    bool InBounds(int x, int y) => x >= 0 && y >= 0 && x < board.Length && y < board[x].Length;
    var lows = new List<(int x, int y)>();
    for (int i = 0; i < board.Length; i++)
    {
        for (int j = 0; j < board[i].Length; j++)
        {
            int n = 0;
            foreach (var (dx, dy) in offsets)
            {
                if (InBounds(i + dx, j + dy) && board[i + dx][j + dy] <= board[i][j]) break;
                n++;
            }
            if (n == 4) lows.Add((i, j));
        }
    }
    var sizes = new List<int>();
    foreach (var (sx, sy) in lows)
    {
        int size = 0;
        var visited = new bool[board.Length, board[0].Length];
        var q = new Queue<(int, int)>();
        q.Enqueue((sx, sy));
        visited[sx, sy] = true;
        while (q.Count > 0)
        {
            size++;
            var (x, y) = q.Dequeue();
            foreach (var (dx, dy) in offsets)
            {
                int nx = x + dx, ny = y + dy;
                if (!InBounds(nx, ny) || board[nx][ny] == 9 || visited[nx, ny]) continue;
                visited[nx, ny] = true;
                q.Enqueue((nx, ny));
            }
        }
        sizes.Add(size);
    }

    sizes.Sort((a, b) => b.CompareTo(a));
    Console.WriteLine(sizes[0] * sizes[1] * sizes[2]);
}