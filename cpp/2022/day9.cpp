#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    char op; int d;
    set<pair<int, int>> tailsPosSet;
    vector<pair<int, int>> rope(10);
    tailsPosSet.insert({});
    while (f >> op >> d) {
        while (d--) {
            auto& [hx, hy] = rope[0];
            if (op == 'R') hx++;
            if (op == 'L') hx--;
            if (op == 'U') hy++;
            if (op == 'D') hy--;
            for (int j = 1; j < 10; j++) {
                auto [px, py] = rope[j - 1];
                auto& [cx, cy] = rope[j];
                if (abs(px - cx) > 1 || abs(py - cy) > 1) cx += (px > cx) - (px < cx), cy += (py > cy) - (py < cy);
            }
            tailsPosSet.insert(rope.back());
        }
    }
    cout << tailsPosSet.size();
}