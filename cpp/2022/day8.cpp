#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    string str;
    vector<vector<int>> hg;
    vector<vector<bool>> vi;
    for (int i = 0; getline(f, str); i++) {
        hg.resize(str.size());
        hg[i].resize(str.size());
        for (int j = 0; j < str.size(); j++) hg[i][j] = str[j] - '0';
    }
    int n = hg.size();
    vi.resize(n, vector<bool>(n));
    for (int i = 0; i < n; i++) {
        int m = -1;
        for (int j = 0; j < n; j++) {
            if (m >= hg[i][j]) continue;
            vi[i][j] = 1;
            m = hg[i][j];
        }
        m = -1;
        for (int j = n - 1; j >= 0; j--) {
            if (m >= hg[i][j]) continue;
            vi[i][j] = 1;
            m = hg[i][j];
        }
        m = -1;
        for (int j = 0; j < n; j++) {
            if (m >= hg[j][i]) continue;
            vi[j][i] = 1;
            m = hg[j][i];
        }
        m = -1;
        for (int j = n - 1; j >= 0; j--) {
            if (m < hg[j][i]) continue;
            vi[j][i] = 1;
            m = hg[j][i];
        }
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
            int h = hg[i][j], ca = 0, cb = 0, cc = 0, cd = 0;
            for (int u = i - 1; u >= 0; u--) {
                ca++;
                if (h <= hg[u][j]) break;
            }
            for (int u = i + 1; u < n; u++) {
                cb++;
                if (h <= hg[u][j]) break;
            }
            for (int v = j - 1; v >= 0; v--) {
                cc++;
                if (h <= hg[i][v]) break;
            }
            for (int v = j + 1; v < n; v++) {
                cd++;
                if (h <= hg[i][v]) break;
            }
            ma = max(ma, ca * cb * cc * cd);
        }
    }
    cout << s << endl << ma;
}