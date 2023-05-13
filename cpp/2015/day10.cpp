#include <bits/stdc++.h>
using namespace std;

string process(const string &s) {
  int i = 0;
  string res = "";
  while (i < s.size()) {
    int cnt = 1;
    char ch = s[i];
    i++;
    while (i < s.size() && s[i] == ch) {
      cnt++;
      i++;
    }
    res += to_string(cnt) + ch;
  }
  return res;
}

int main() {
  string s;
  cin >> s;
  for (int i = 1; i <= 50; i++) {
    s = process(s);
    if (i == 40 || i == 50)
      cout << s.size() << '\n';
  }
}
