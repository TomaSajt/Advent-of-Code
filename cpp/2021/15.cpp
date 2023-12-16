#include <bits/stdc++.h>
using namespace std;
using v2d = array<int, 2>;

vector<v2d> dirs = {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};

int solve(const vector<vector<int>>& board, int n) {
  vector<vector<int>> dist(n, vector<int>(n, INT_MAX / 2));
  dist[0][0] = 0;
  priority_queue<pair<int, v2d>, vector<pair<int, v2d>>, greater<pair<int, v2d>>> pq;
  pq.push({0, {0, 0}});
  while (!pq.empty()) {
    auto [x, y] = pq.top().second;
    pq.pop();
    if (x == n - 1 && y == n - 1) return dist[x][y];
    for (auto [dx, dy] : dirs) {
      int nx = x + dx, ny = y + dy;
      if (nx < 0 || nx >= n || ny < 0 || ny >= n) continue;
      int d = dist[x][y] + board[nx][ny];
      if (dist[nx][ny] > d) {
        dist[nx][ny] = d;
        pq.push({d, {nx, ny}});
      }
    }
  }
  return -1;
}

int main() {
  ifstream f("input.txt");
  vector<vector<int>> board;
  string l;
  while (f >> l) {
    board.push_back(vector<int>(l.size()));
    for (int i = 0; i < l.size(); i++) {
      board.back()[i] = l[i] - '0';
    }
  }
  int n = board.size();
  board.resize(5 * n);
  for (int i = 0; i < 5 * n; i++) {
    board[i].resize(5 * n);
    for (int j = 0; j < 5 * n; j++) {
      board[i][j] = (board[i % n][j % n] + i / n + j / n - 1) % 9 + 1;
    }
  }
  cout << "asd" << endl;

  cout << solve(board, n) << endl;
  cout << solve(board, 5 * n);
}
