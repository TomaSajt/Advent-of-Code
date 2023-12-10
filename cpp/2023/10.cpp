#include <bits/stdc++.h>
using namespace std;
fstream inp("input.txt");

int n, m;
vector<string> board;

bool is_right(char c) { return c == 'L' || c == 'F' || c == '-' || c == 'S'; }
bool is_left(char c) { return c == 'J' || c == '7' || c == '-' || c == 'S'; }
bool is_down(char c) { return c == '7' || c == 'F' || c == '|' || c == 'S'; }
bool is_up(char c) { return c == 'J' || c == 'L' || c == '|' || c == 'S'; }

vector<pair<int, int>> neighbours(int y, int x) {
  vector<pair<int, int>> res;
  if (x < n - 1 && is_right(board[y][x]) && is_left(board[y][x + 1])) res.push_back({y, x + 1});
  if (y < n - 1 && is_down(board[y][x]) && is_up(board[y + 1][x])) res.push_back({y + 1, x});
  if (x > 0 && is_left(board[y][x]) && is_right(board[y][x - 1])) res.push_back({y, x - 1});
  if (y > 0 && is_up(board[y][x]) && is_down(board[y - 1][x])) res.push_back({y - 1, x});
  return res;
}

int main() {
  string line;
  while (inp >> line) board.push_back(line);
  n = board.size(), m = board[0].size();

  int sy = -1, sx = -1;
  for (int i = 0; i < n; i++) {
    for (int j = 0; j < m; j++) {
      if (board[i][j] == 'S') sy = i, sx = j;
    }
  }
  queue<pair<int, int>> q;
  map<pair<int, int>, int> dist;
  dist[{sy, sx}] = 0;
  int max_dist = 0;
  q.push({sy, sx});

  while (!q.empty()) {
    auto [y, x] = q.front();
    q.pop();
    cout << y << ' ' << x << endl;
    for (auto nei : neighbours(y, x)) {
      if (dist.count(nei)) continue;
      max_dist = dist[nei] = dist[{y, x}] + 1;
      q.push(nei);
    }
  }

  cout << max_dist;
}
