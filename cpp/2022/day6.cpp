#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    string s;
    f >> s;
    int n = s.size();
    int sol1 = -1;
    for (int i = 0; i < n; i++) {
        set<char> se1, se2;
        for (int j = 0; j < 4; j++) {
            se1.insert(s[i + j]);
        }
        for (int j = 0; j < 14; j++) {
            se2.insert(s[i + j]);
        }
        if (sol1 == -1 && se1.size() == 4) {
            sol1 = i + 4;
        }
        if (se2.size() == 14) {
            cout << sol1 << ' ' << i + 14 << endl;
            return 0;
        }
    }
}