#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    string op;
    int res = 0, x = 1, c = 0;
    while (f >> op) {
        int rep = op == "addx" ? 2 : 1;
        while (rep--) {
            c++;
            if (c % 40 == 20) res += c * x;
            cout << " #"[abs(x - (c - 1) % 40) <= 1];
            if (c % 40 == 0) cout << '\n';
        }
        if (op == "addx") {
            int v; f >> v;
            x += v;
        }
    }
    cout << res;
}
