#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    char ca, cb;
    int s1 = 0, s2 = 0;
    while (f >> ca >> cb) {
        int a = ca - 'A', b = cb - 'X';
        s1 += b + 1 + 3 * ((b - a + 4) % 3);
        s2 += (a + b + 2) % 3 + 1 + 3 * b;
    }
    cout << s1 << ' ' << s2;
}