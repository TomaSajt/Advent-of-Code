#include <bits/stdc++.h>
#include "./day4-md5.h"
#define speed ios::sync_with_stdio(0);cin.tie(0)
using namespace std;

int main() {
    speed;
    cout << "Secret key: " << flush;
    string s; cin >> s;
    cout << "Number of 0s: " << flush;
    int n; cin >> n;
    for (int i = 1;; i++) {
        string res = md5(s + to_string(i));
        if (res.substr(0, n) == string(n, '0')) {
            cout << i;
            return 0;
        }
    }
}