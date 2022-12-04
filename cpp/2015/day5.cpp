#include <bits/stdc++.h>
#define speed ios::sync_with_stdio(0);cin.tie(0)
using namespace std;

set<char> vowels{ 'a', 'e', 'i', 'o', 'u' };
bool good1(const string& str) {
    int n = str.length();
    for (int i = 0; i < n - 1; i++) {
        if (str[i] == 'a' && str[i + 1] == 'b') return 0;
        if (str[i] == 'c' && str[i + 1] == 'd') return 0;
        if (str[i] == 'p' && str[i + 1] == 'q') return 0;
        if (str[i] == 'x' && str[i + 1] == 'y') return 0;
    }
    int vc = count_if(str.begin(), str.end(), [&](char ch) { return vowels.count(ch); });
    if (vc < 3) return 0;
    for (int i = 0; i < n - 1; i++) {
        if (str[i] == str[i + 1]) return 1;
    }
    return 0;
}

bool good2(const string& str) {
    int n = str.length();
    map<string, vector<int>> pos;
    for (int i = 0; i < n - 1; i++) {
        pos[str.substr(i, 2)].push_back(i);
    }
    bool ok = 0;
    for (auto& [k, v] : pos) {
        if (v.size() > 2) {
            ok = 1;
            break;
        }
        if (v.size() == 2 && v[0] + 1 != v[1]) {
            ok = 1;
            break;
        }
    }
    if (!ok) return 0;
    for (int i = 1; i < n - 1; i++) {
        if (str[i - 1] == str[i + 1]) return 1;
    }
    return 0;
}

int main() {
    speed;
    ifstream file("input.txt");
    string str;
    int cnt1 = 0;
    int cnt2 = 0;
    while (file >> str) {
        cnt1 += good1(str);
        cnt2 += good2(str);
    }
    cout << cnt1 << '\n' << cnt2;

}