#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    string st;
    f >> st;
    int r1 = -1;
    for (int i = 0; i < st.size(); i++) {
        set<char> s1, s2;
        for (int j = 0; j < 4; j++) s1.insert(st[i + j]);
        for (int j = 0; j < 14; j++) s2.insert(st[i + j]);
        if (r1 == -1 && s1.size() == 4) r1 = i + 4;
        if (s2.size() == 14) {
            cout << r1 << ' ' << i + 14 << endl;
            return 0;
        }
    }
}