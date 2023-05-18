#include <bits/stdc++.h>
using namespace std;
typedef long long ll;
struct state {
  int pos;
  int time;
  int acc;
  bitset<64> open;
};

map<string, int> str_to_id;
map<int, vector<int>> g;
map<int, int> rates;
vector<vector<int>> dist_mat;

int n = 0;

int get_id_from_str(const string &str) {
  if (str_to_id.count(str))
    return str_to_id[str];
  return str_to_id[str] = n++;
}

vector<state> next_states(state &st) {
  vector<state> vec;
  int u = st.pos;
  for (int v = 0; v < n; v++) {
    if (rates[v] == 0)
      continue;
    if (st.open.test(v))
      continue;
    int dist = dist_mat[u][v];
    if (dist >= st.time)
      continue;
    vec.push_back(st);
    state &nxt = vec.back();
    nxt.pos = v;
    nxt.open.set(v);
    nxt.time -= dist + 1;
    nxt.acc += rates[v] * nxt.time;
  }
  return vec;
}

int main() {
  string line;
  while (getline(cin, line)) {
    stringstream ss{line};
    string dump, id;
    int rate;
    ss.ignore(6);
    ss >> id;
    ss.ignore(15);
    ss >> rate >> dump >> dump;
    ss.ignore(16);
    rates[get_id_from_str(id)] = rate;
    string nei;
    while (getline(ss, nei, ',')) {
      g[get_id_from_str(id)].push_back(get_id_from_str(nei));
      ss.ignore(1);
    }
  }
  dist_mat.resize(n, vector<int>(n, INT_MAX / 2));
  for (int u = 0; u < n; u++) {
    for (int &v : g[u]) {
      dist_mat[u][v] = 1;
    }
  }

  for (int i = 0; i < n; i++) {
    for (int j = 0; j < n; j++) {
      for (int k = 0; k < n; k++) {
        dist_mat[i][j] = min(dist_mat[i][j], dist_mat[i][k] + dist_mat[k][j]);
      }
    }
  }

  int best_acc = 0;
  queue<state> q;
  q.push({get_id_from_str("AA"), 30, 0, 0});
  while (!q.empty()) {
    state st = q.front();
    cout << st.time << ' ' << st.pos << '\n';
    best_acc = max(best_acc, st.acc);
    for (auto &next_st : next_states(st)) {
      q.push(next_st);
    }
    q.pop();
  }
  cout << best_acc;
}
