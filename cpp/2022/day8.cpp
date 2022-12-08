#include <bits/stdc++.h>
using namespace std;

vector<vector<int>> hg;
vector<vector<bool>> vi;
int n;

void look1(int x, int y, int dx, int dy) {
    int m = -1;
    for (int i = x, j = y; i >= 0 && j >= 0 && i < n && j < n; i += dx, j += dy) {
        if (m >= hg[i][j]) continue;
        vi[i][j] = 1;
        m = hg[i][j];
    }
}

int look2(int x, int y, int dx, int dy) {
    int h = hg[x][y], c = 0;
    for (int i = x + dx, j = y + dy; i >= 0 && j >= 0 && i < n && j < n; i += dx, j += dy) {
        c++;
        if (h <= hg[i][j]) break;
    }
    return c;
}

int main() {
    ifstream f("input.txt");
    string str;
    for (int i = 0; getline(f, str); i++) {
        hg.resize(str.size());
        hg[i].resize(str.size());
        for (int j = 0; j < str.size(); j++) hg[i][j] = str[j] - '0';
    }
    n = hg.size();
    vi.resize(n, vector<bool>(n));
    for (int i = 0; i < n; i++) {
        look1(i, 0, 0, 1);
        look1(i, n - 1, 0, -1);
        look1(0, i, 1, 0);
        look1(n - 1, i, -1, 0);
    }
    int s = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            s += vi[i][j];
        }
    }
    int ma = 0;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < n; j++) {
            ma = max(ma, look2(i, j, 0, 1) * look2(i, j, 1, 0) * look2(i, j, 0, -1) * look2(i, j, -1, 0));
        }
    }
    cout << s << endl << ma;
}