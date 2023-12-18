#include <bits/stdc++.h>
using namespace std;
using v2d = array<int, 2>;

int n, m;
vector<string> board;
vector<vector<set<v2d>>> entered_from;

void visit(v2d pos, v2d dir) {
  if (pos[0] < 0 || pos[0] >= n || pos[1] < 0 || pos[1] >= m) return;
  auto& s = entered_from[pos[0]][pos[1]];
  if (s.count(dir)) return;
  s.insert(dir);
  char c = board[pos[0]][pos[1]];
  vector<v2d> dirs;
  bool split = (c == '|' && dir[1] != 0) || (c == '-' && dir[0] != 0);
  if (split || c == '\\') dirs.push_back({dir[1], dir[0]});
  if (split || c == '/') dirs.push_back({-dir[1], -dir[0]});
  if (dirs.empty()) dirs.push_back(dir);
  for (v2d& new_dir : dirs) visit({pos[0] + new_dir[0], pos[1] + new_dir[1]}, new_dir);
}

int solve(v2d pos, v2d dir) {
  entered_from.assign(n, vector<set<v2d>>(m));
  visit(pos, dir);
  int res = 0;
  for (auto& l : entered_from) {
    for (auto& s : l) res += s.size() > 0;
  }
  return res;
}

int main() {
  ifstream inp("input.txt");
  string line;
  while (getline(inp, line)) board.push_back(line);
  n = board.size(), m = board[0].size();

  cout << solve({0, 0}, {0, 1}) << endl;

  int sol2 = 0;
  for (int i = 0; i < n; i++) sol2 = max({sol2, solve({i, 0}, {0, 1}), solve({i, m - 1}, {0, -1})});
  for (int j = 0; j < m; j++) sol2 = max({sol2, solve({0, j}, {1, 0}), solve({n - 1, j}, {-1, 0})});
  cout << sol2;
}
