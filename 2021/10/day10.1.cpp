#include <bits/stdc++.h>
using namespace std;
int main() {
    ifstream f("input.txt");
    string l;
    int res = 0;
    while (f >> l) {
        stack<char> s;
        for (char c : l) {
            if (c == '(' || c == '[' || c == '{' || c == '<') s.push(c);
            else {
                char ch = s.top(); s.pop();
                if (c == ')' && ch != '(') res += 3;
                else if (c == ']' && ch != '[') res += 57;
                else if (c == '}' && ch != '{') res += 1197;
                else if (c == '>' && ch != '<') res += 25137;
                else continue;
                break;
            }
        }
    }
    f.close();
    cout << res;
}