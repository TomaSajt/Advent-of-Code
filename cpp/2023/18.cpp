#include <bits/stdc++.h>
using namespace std;
using ll = long long;

ll solve(const vector<pair<char, ll>>& data) {
  ll area = 0, inner_perimeter = 0, ypos = 0;
  for (auto [dir, num] : data) {
    if (dir == 'U') ypos += num;
    else if (dir == 'D') ypos -= num;
    else if (dir == 'R') area += ypos * num;
    else if (dir == 'L') area -= ypos * num;
    inner_perimeter += num;
  }
  area += inner_perimeter / 2 + 1;
  return area;
}

int main() {
  ifstream inp("input.txt");
  vector<pair<char, ll>> part1_in, part2_in;
  char dir1;
  ll num1;
  string hex;
  while (inp >> dir1 >> num1 >> hex) {
    char dir2 = "RDLU"[hex[7] - '0'];
    ll num2 = 0;
    for (int i = 2; i < 7; i++) {
      num2 *= 16;
      num2 += hex[i] >= 'a' ? hex[i] - 'a' + 10 : hex[i] - '0';
    }
    part1_in.push_back({dir1, num1});
    part2_in.push_back({dir2, num2});
  }

  cout << solve(part1_in) << endl;
  cout << solve(part2_in) << endl;
}
