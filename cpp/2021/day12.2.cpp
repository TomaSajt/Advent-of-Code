#include <bits/stdc++.h>
using namespace std;
map<string, vector<string>> g;
set<string> vis;
bool used = false;
int res = 0;
void dfs(string u) {
    vis.insert(u);
    if (u == "end") {
        res++;
        vis.erase(u);
        return;
    }
    for (auto& v : g[u]) {
        if (v[0] <= 'a' || vis.find(v) == vis.end()) {
            dfs(v);
        }
        else if (v != "start" && v != "end" && !used) {
            used = true;
            dfs(v);
            vis.insert(v);
            used = false;
        }
    }
    vis.erase(u);
}
int main() {
    ifstream f(".input.txt");
    string l;
    while (f >> l) {
        int p = l.find('-');
        string u = l.substr(0, p), v = l.substr(p + 1);
        g[u].push_back(v);
        g[v].push_back(u);
    }
    f.close();
    dfs("start");
    cout << res;
}

