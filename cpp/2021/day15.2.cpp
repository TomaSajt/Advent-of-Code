#include <bits/stdc++.h>
using namespace std;
vector<vector<int>> board;
vector<vector<int>> dist;
int n;

int brd(int x, int y) {
    return (board[x % n][y % n] + x / n + y / n - 1) % 9 + 1;
}
int main() {
    ifstream f("input.txt");
    string l;
    while (f >> l) {
        board.push_back(vector<int>(l.size()));
        for (int i = 0; i < l.size(); i++) {
            board[board.size() - 1][i] = l[i] - '0';
        }
    }
    f.close();
    n = board.size();
    dist.assign(5 * n, vector<int>(5 * n, INT_MAX / 2));
    dist[0][0] = 0;
    priority_queue<pair<int, pair<int, int>>, vector<pair<int, pair<int, int>>>, greater<pair<int, pair<int, int>>>> pq;
    pq.push({ 0,{0, 0} });
    while (!pq.empty()) {
        auto cur = pq.top();
        pq.pop();
        int x = cur.second.first;
        int y = cur.second.second;
        if (x == 5 * n - 1 && y == 5 * n - 1) {
            cout << dist[x][y] << endl;
            return 0;
        }
        if (x + 1 < 5 * n && dist[x + 1][y] > dist[x][y] + brd(x + 1, y)) {
            dist[x + 1][y] = dist[x][y] + brd(x + 1, y);
            pq.push({ dist[x + 1][y], { x + 1, y } });
        }
        if (y + 1 < 5 * n && dist[x][y + 1] > dist[x][y] + brd(x, y + 1)) {
            dist[x][y + 1] = dist[x][y] + brd(x, y + 1);
            pq.push({ dist[x][y + 1], { x, y + 1 } });
        }
        if (x - 1 >= 0 && dist[x - 1][y] > dist[x][y] + brd(x - 1, y)) {
            dist[x - 1][y] = dist[x][y] + brd(x - 1, y);
            pq.push({ dist[x - 1][y], { x - 1, y } });
        }
        if (y - 1 >= 0 && dist[x][y - 1] > dist[x][y] + brd(x, y - 1)) {
            dist[x][y - 1] = dist[x][y] + brd(x, y - 1);
            pq.push({ dist[x][y - 1], { x, y - 1 } });
        }
    }
}