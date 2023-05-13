#include <bits/stdc++.h>
using namespace std;

int decoded_length(const string &s) {
  int i = 0, len = 0;
  while (i < s.size()) {
    if (s[i] == '\\') {
      i++;
      if (s[i] == 'x')
        i += 2;
    }
    len++;
    i++;
  }
  return len - 2;
}

int encoded_length(const string &s) {
  int extra = count_if(s.begin(), s.end(),
                       [](char ch) { return ch == '"' || ch == '\\'; });
  return s.size() + extra + 2;
}

int main() {
  string line;
  int sol1 = 0, sol2 = 0;
  while (getline(cin, line)) {
    sol1 += line.size() - decoded_length(line);
    sol2 += encoded_length(line) - line.size();
  }
  cout << sol1 << ' ' << sol2 << '\n';
}
