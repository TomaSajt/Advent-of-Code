#include <bits/stdc++.h>
using namespace std;
ifstream inp("input.txt");
ofstream outp("path.txt");

int n, m;
vector<string> board;

bool is_r(char c) { return c == 'L' || c == 'F' || c == '-'; }
bool is_l(char c) { return c == 'J' || c == '7' || c == '-'; }
bool is_d(char c) { return c == '7' || c == 'F' || c == '|'; }
bool is_u(char c) { return c == 'J' || c == 'L' || c == '|'; }

vector<pair<int, int>> neighbours(int y, int x) {
  vector<pair<int, int>> res;
  if (x < n - 1 && is_r(board[y][x]) && is_l(board[y][x + 1])) res.push_back({y, x + 1});
  if (y < n - 1 && is_d(board[y][x]) && is_u(board[y + 1][x])) res.push_back({y + 1, x});
  if (x > 0 && is_l(board[y][x]) && is_r(board[y][x - 1])) res.push_back({y, x - 1});
  if (y > 0 && is_u(board[y][x]) && is_d(board[y - 1][x])) res.push_back({y - 1, x});
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
  char c;
  bool su = is_d(board[sy - 1][sx]);
  bool sl = is_r(board[sy][sx - 1]);
  bool sd = is_u(board[sy + 1][sx]);
  bool sr = is_l(board[sy][sx + 1]);
  if (su && sl) c = 'J';
  if (su && sr) c = 'L';
  if (su && sd) c = '|';
  if (sd && sl) c = '7';
  if (sd && sr) c = 'L';
  if (sl && sr) c = '-';
  board[sy][sx] = c;

  queue<pair<int, int>> q;
  map<pair<int, int>, int> dist;
  dist[{sy, sx}] = 0;
  int max_dist = 0;
  q.push({sy, sx});

  while (!q.empty()) {
    auto [y, x] = q.front();
    q.pop();
    for (auto nei : neighbours(y, x)) {
      if (dist.count(nei)) continue;
      max_dist = dist[nei] = dist[{y, x}] + 1;
      q.push(nei);
    }
  }
  for (int i = 0; i < n; i++) {
    for (int j = 0; j < m; j++) {
      outp << (dist.count({i, j}) ? board[i][j] : '.');
    }
    outp << '\n';
  }

  cout << max_dist << '\n';
}
