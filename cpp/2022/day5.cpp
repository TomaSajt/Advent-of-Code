 #include <bits/stdc++.h>
using namespace std;

void solve1(vector<stack<char>> stc, const vector<array<int, 3>>& reqs) {
    for (auto [n, u, v] : reqs) {
        while (n--) stc[v].push(stc[u].top()), stc[u].pop();
    }
    for (int i = 1; i <= 9; i++) cout << stc[i].top();
    cout << '\n';
}

void solve2(vector<stack<char>> stc, const vector<array<int, 3>>& reqs) {
    for (auto [n, u, v] : reqs) {
        stack<char> temp;
        while (n--) temp.push(stc[u].top()), stc[u].pop();
        while (!temp.empty()) stc[v].push(temp.top()), temp.pop();
    }
    for (int i = 1; i <= 9; i++) cout << stc[i].top();
    cout << '\n';
}

int main() {
    vector<stack<char>> stcr(10), stc(10);
    ifstream f("input.txt");
    string str;
    while (getline(f, str) && !str.empty()) {
        for (int i = 1; i <= 9; i++) {
            char c = str[i * 4 - 3];
            if ('A' <= c && c <= 'Z') stcr[i].push(c);
        }
    }
    for (int i = 1; i <= 9; i++) {
        while (!stcr[i].empty()) stc[i].push(stcr[i].top()), stcr[i].pop();
    }
    vector<array<int, 3>> reqs;
    while (getline(f, str)) {
        stringstream ss(str);
        auto& [n, u, v] = reqs.emplace_back();
        ss >> str >> n >> str >> u >> str >> v;
    }
    solve1(stc, reqs);
    solve2(stc, reqs);
}