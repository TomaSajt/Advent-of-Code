#include <bits/stdc++.h>
#define speed ios::sync_with_stdio(0);cin.tie(0)
using namespace std;
typedef array<int, 3> point;

set<point> board, vis;
point dirs[] = { {0,0,1},{0,0,-1},{0,1,0},{0,-1,0},{1,0,0},{-1,0,0} };
point operator+(const point& a, const point& b) { return { a[0] + b[0], a[1] + b[1], a[2] + b[2] }; }
bool inBounds(const point& p) { return all_of(p.begin(), p.end(), [](auto& c) { return -1 <= c && c <= 21; }); }
int sol2 = 0;
void dfs(const point& p) {
    vis.insert(p);
    for (auto& dir : dirs) {
        auto nei = p + dir;
        if (!inBounds(nei) || vis.count(nei)) continue;
        if (board.count(nei)) sol2++;
        else dfs(nei);
    }
}
int main() {
    ifstream f("input.txt");
    string s;
    int sol1 = 0;
    while (f >> s) {
        stringstream ss(s);
        point p;
        for (int i = 0; getline(ss, s, ','); i++) p[i] = stoi(s);
        sol1 += 6;
        for (auto& dir : dirs) {
            if (board.count(p + dir)) sol1 -= 2;
        }
        board.insert(p);
    }
    dfs({ -1,-1,-1 });
    cout << sol1 << ' ' << sol2;
}