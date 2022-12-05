#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    vector<string> v;
    string str;
    while (f >> str) v.push_back(str);
    int as = 0, bs = 0;
    for (auto& str : v) {
        map<char, int> cnts;
        for (char c : str) cnts[c]++;
        bool a = 0, b = 0;
        for (auto [c, cnt] : cnts) {
            if (cnt == 2) a = 1;
            if (cnt == 3) b = 1;
        }
        as += a;
        bs += b;
    }
    cout << as * bs << endl;
    for (auto& s1 : v) {
        for (auto& s2 : v) {
            int cnt = 0;
            int mmi = -1;
            for (int i = 0; i < s1.size(); i++) {
                if (s1[i] != s2[i]) {
                    cnt++;
                    mmi = i;
                }
            }
            if (cnt == 1) {
                for (int i = 0; i < s1.size(); i++) {
                    if (i != mmi) cout << s1[i];
                }
                return 0;
            }
        }
    }

}