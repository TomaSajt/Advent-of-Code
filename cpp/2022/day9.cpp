#include <bits/stdc++.h>
using namespace std;
#define L 10

int sign(int a) { return (a > 0) - (a < 0); }

int main() {
    ifstream f("input.txt");
    char op;
    int d;
    set<pair<int, int>> tailsPosSet;
    vector<pair<int, int>> rope(L);
    tailsPosSet.insert(rope[0]);
    while (f >> op >> d) {
        while (d--) {
            if (op == 'R') rope[0].first++;
            if (op == 'L') rope[0].first--;
            if (op == 'U') rope[0].second++;
            if (op == 'D') rope[0].second--;
            for (int j = 1; j < L; j++) {
                auto [px, py] = rope[j - 1];
                auto& [cx, cy] = rope[j];
                int sx = sign(px - cx), sy = sign(py - cy);
                int dx = abs(px - cx), dy = abs(py - cy);
                if (dx > 1 || dy > 1) cx += sx, cy += sy;
            }
            tailsPosSet.insert(rope.back());
        }
    }
    cout << tailsPosSet.size();
}