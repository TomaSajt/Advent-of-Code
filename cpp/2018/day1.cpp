#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    int a, res = 0;
    set<int> s;
    vector<int> v;
    while (f >> a) v.push_back(a);
    int sum = 0;
    for (int a : v) sum += a;
    cout << sum << endl;
    int i = 0;
    while (1) {
        res += v[i];
        if (!s.insert(res).second) {
            cout << res;
            return 0;
        }
        (++i) %= v.size();
    }
}