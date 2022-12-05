#include <bits/stdc++.h>
using namespace std;

int board[1001][1001];
int main() {
    ifstream f("input.txt");
    char ch;
    vector<array<int, 5>> v;
    while (1) {
        auto& [id, x, y, w, h] = v.emplace_back();
        if (f >> ch >> id >> ch >> x >> ch >> y >> ch >> w >> ch >> h) continue;
        break;
    }
    v.pop_back();
    for (auto [id, x, y, w, h] : v) {
        for (int i = x; i < x + w; i++) {
            for (int j = y; j < y + h; j++) {
                board[i][j]++;
            }
        }
    }
    int cnt = 0;
    for (int i = 0; i <= 1000; i++) {
        for (int j = 0; j <= 1000; j++) {
            if (board[i][j] >= 2) cnt++;
        }
    }
    cout << cnt << endl;
    for (auto [id, x, y, w, h] : v) {
        int cnt = 0;
        for (int i = x; i < x + w; i++) {
            for (int j = y; j < y + h; j++) {
                cnt += board[i][j];
            }
        }
        if (cnt == w * h) {
            cout << id;
        }
    }
}