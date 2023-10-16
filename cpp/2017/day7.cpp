#include <bits/stdc++.h>
using namespace std;

map<string, int> weights;
map<string, vector<string>> g;

set<string> vis;
vector<string> order;

map<string, int> subtree_weights;

int sol2 = -1;

void dfs1(const string &u) {
  if (vis.count(u))
    return;
  vis.insert(u);
  int subtree_weight = weights[u];
  map<int, int> nei_subtree_weight_counts;
  for (string &v : g[u]) {
    dfs1(v);
    subtree_weight += subtree_weights[v];
    nei_subtree_weight_counts[subtree_weights[v]]++;
  }
  if (sol2 == -1 && nei_subtree_weight_counts.size() >= 2) {
    cout << nei_subtree_weight_counts.size() << '\n';
    cout << g[u].size() << '\n';
    int wanted = nei_subtree_weight_counts.begin()->second == 1
                     ? nei_subtree_weight_counts.rbegin()->first
                     : nei_subtree_weight_counts.begin()->first;
    string invalid_id = "";
    for (string &v : g[u]) {
      if (subtree_weights[v] != wanted) {
        invalid_id = v;
        break;
      }
    }
    sol2 = wanted - subtree_weights[invalid_id] + weights[invalid_id];
  }

  subtree_weights[u] = subtree_weight;
  order.push_back(u);
}

int main() {
  fstream inp("input.txt");
  string line;
  while (getline(inp, line) && !line.empty()) {
    stringstream line_ss(line);
    string id;
    line_ss >> id;
    line_ss.ignore(2);
    int w;
    line_ss >> w;
    weights[id] = w;
    if (!line_ss.ignore(5))
      continue;
    g[id] = {};
    string nei;
    while (getline(line_ss, nei, ',')) {
      line_ss.ignore(1);
      g[id].push_back(nei);
    }
  }
  for (auto &[u, _] : g)
    dfs1(u);
  cout << order.back() << '\n';
  cout << sol2;
}
