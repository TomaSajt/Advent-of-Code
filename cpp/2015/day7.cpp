#include <bits/stdc++.h>
using namespace std;

map<string, int> mem;
map<string, vector<string>> calc;

int get_value(const string &s) {
  if (s[0] >= '0' && s[0] <= '9')
    return stoi(s);
  if (mem.count(s))
    return mem[s];
  auto &vec = calc[s];
  if (vec.size() == 1)
    return mem[s] = get_value(vec[0]);
  if (vec.size() == 2 && vec[0] == "NOT")
    return mem[s] = ~get_value(vec[1]);
  int av = get_value(vec[0]), bv = get_value(vec[2]);
  if (vec[1] == "OR")
    return mem[s] = av | bv;
  if (vec[1] == "AND")
    return mem[s] = av & bv;
  if (vec[1] == "RSHIFT")
    return mem[s] = av >> bv;
  if (vec[1] == "LSHIFT")
    return mem[s] = av << bv;
  return 1 / 0;
}

int main() {
  string l, r, p;
  while (getline(cin, l, '>')) {
    cin.ignore();
    getline(cin, r);
    l.resize(l.size() - 2);
    stringstream ss(l);
    vector<string> vec;
    while (getline(ss, p, ' '))
      vec.push_back(p);
    calc[r] = vec;
  }
  int res = get_value("a");
  mem.clear();
  mem["b"] = res;
  cout << res << ' ' << get_value("a") << '\n';
}
