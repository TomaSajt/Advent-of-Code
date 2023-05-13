#include <bits/stdc++.h>
using namespace std;

set<string> vis;
map<string, vector<pair<string, int>>> g;
int len = 0;

int sol1 = INT_MAX, sol2 = 0;

void dfs(const string &u) {
  if (vis.size() == g.size()) {
    sol1 = min(sol1, len);
    sol2 = max(sol2, len);
    return;
  }
  for (auto &[v, l] : g[u]) {
    if (vis.count(v))
      continue;
    vis.insert(v);
    len += l;
    dfs(v);
    len -= l;
    vis.erase(v);
  }
}

int main() {
  string u, v, d;
  int l;
  while (cin >> u >> d >> v >> d >> l) {
    g[u].push_back({v, l});
    g[v].push_back({u, l});
  }
  for (auto &[u, _] : g) {
    vis.insert(u);
    dfs(u);
    vis.erase(u);
  }
  cout << sol1 << ' ' << sol2 << '\n';
}
