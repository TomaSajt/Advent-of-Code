#include <bits/stdc++.h>
using namespace std;
int main() {
    ifstream f("input.txt");
    int a, b, c, d, answer = 0;
    f >> a >> b >> c;
    while (f >> d) {
        if (b + c + d > a + b + c) {
            ++answer;
        }
        a = b;
        b = c;
        c = d;
    }
    f.close();
    cout << answer << '\n';
}