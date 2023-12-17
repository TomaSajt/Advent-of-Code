#include <bits/stdc++.h>
using namespace std;
using v2d = array<int, 2>;
using state = array<int, 5>; // dist, y, x, dy, dx, dn

vector<v2d> dirs = {{1, 0}, {-1, 0}, {0, 1}, {0, -1}};

// dijkstra's algorithm
int solve(const vector<vector<int>>& board, int min_dn, int max_dn) {
  int n = board.size(), m = board[0].size();
  state start = {0, 0, 0, 0, min_dn};
  map<state, int> dist;
  dist[start] = 0;
  priority_queue<pair<int, state>, vector<pair<int, state>>, greater<pair<int, state>>> pq;
  pq.push({0, start});
  while (!pq.empty()) {
    state curr_state = pq.top().second;
    auto [y, x, pdy, pdx, pdn] = curr_state;
    pq.pop();
    if (y == n - 1 && x == m - 1) return dist[curr_state];
    for (auto [dy, dx] : dirs) {
      if (dy == -pdy && dx == -pdx) continue;
      int ny = y + dy, nx = x + dx;
      bool same = pdy == dy && pdx == dx;
      if (!same && pdn < min_dn) continue;
      int dn = same ? pdn + 1 : 1;
      if (dn > max_dn) continue;
      if (ny < 0 || ny >= n || nx < 0 || nx >= m) continue;
      state new_state = {ny, nx, dy, dx, dn};
      int d = dist[curr_state] + board[ny][nx];
      if (!dist.count(new_state) || dist[new_state] > d) {
        dist[new_state] = d;
        pq.push({d, new_state});
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
  cout << solve(board, 1, 3) << endl;
  cout << solve(board, 4, 10) << endl;
}
