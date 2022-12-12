#include <bits/stdc++.h>
using namespace std;

pair<int, int> d[] = { {0,1},{0,-1},{1,0},{-1,0} };
vector<string> hgt;
int n, m;

int bfs(int sx, int sy, function<bool(int, int, int, int)> predStep, function<bool(int, int)> predTo) {
    queue<pair<int, int>> q;
    vector<vector<int>> dist(n, vector<int>(m, -1));
    q.push({ sx,sy });
    dist[sx][sy] = 0;
    while (!q.empty()) {
        auto [cx, cy] = q.front(); q.pop();
        if (predTo(cx, cy)) return dist[cx][cy];
        for (auto [dx, dy] : d) {
            int nx = cx + dx;
            int ny = cy + dy;
            if (nx < 0 || nx >= n || ny < 0 || ny >= m) continue;
            if (dist[nx][ny] != -1) continue;
            if (!predStep(cx, cy, nx, ny)) continue;
            q.push({ nx,ny });
            dist[nx][ny] = dist[cx][cy] + 1;
        }
    }
    return -1;
}

int main() {
    ifstream f("input.txt");
    string s;
    while (f >> s) hgt.push_back(s);
    n = hgt.size();
    m = hgt[0].size();
    int ex, ey, sx, sy;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            if (hgt[i][j] == 'S') sx = i, sy = j;
            if (hgt[i][j] == 'E') ex = i, ey = j;
        }
    }
    hgt[sx][sy] = 'a';
    hgt[ex][ey] = 'z';
    cout << bfs(sx, sy, [&](int cx, int cy, int nx, int ny) { return hgt[nx][ny] - hgt[cx][cy] <= 1; }, [&](int x, int y) { return x == ex && y == ey; }) << endl
        << bfs(ex, ey, [&](int cx, int cy, int nx, int ny) { return hgt[cx][cy] - hgt[nx][ny] <= 1; }, [&](int x, int y) { return hgt[x][y] == 'a'; });
}