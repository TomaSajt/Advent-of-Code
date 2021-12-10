#include <bits/stdc++.h>
typedef long long ll;
using namespace std;
int main() {
    ifstream f("input.txt");
    string l;
    vector<ll> v;
    while (f >> l) {
        bool bad = false;
        stack<char> s;
        for (char c : l) {
            if (c == '(' || c == '[' || c == '{' || c == '<') s.push(c);
            else {
                char ch = s.top(); s.pop();
                if ((c == ')' && ch != '(') ||
                    (c == ']' && ch != '[') ||
                    (c == '}' && ch != '{') ||
                    (c == '>' && ch != '<')) {
                    bad = true;
                    break;
                }
            }
        }
        if (bad) continue;
        ll res = 0;
        while (!s.empty()) {
            char c = s.top(); s.pop();
            res *= 5;
            res += c == '(' ? 1 : c == '[' ? 2 : c == '{' ? 3 : 4;
        }
        v.push_back(res);
    }
    f.close();
    sort(v.begin(), v.end());
    cout << v[v.size() / 2] << endl;
}