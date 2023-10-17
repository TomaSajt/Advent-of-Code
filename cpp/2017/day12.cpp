#include <bits/stdc++.h>
using namespace std;

map<int, vector<int>> g;
set<int> vis;

void dfs(int u) {
  if (vis.count(u))
    return;
  vis.insert(u);
  for (int v : g[u]) {
    dfs(v);
  }
}

int main() {
  fstream inp("input.txt");

  string line;
  while (getline(inp, line)) {
    stringstream ss(line);
    int u;
    ss >> u;
    ss.ignore(5);
    int v;
    while (ss >> v) {
      ss.ignore(2);
      g[u].push_back(v);
    }
  }
  dfs(0);
  cout << vis.size() << '\n';

  int cnt = 1;
  for (auto &[u, _] : g) {
    if (vis.count(u))
      continue;
    dfs(u);
    cnt++;
  }
  cout << cnt;
}
