#include <bits/stdc++.h>
using namespace std;
using ll = long long;

map<array<int, 3>, ll> mem;
ll backtrack(const string& pat, int pat_i, vector<int>& nums, int num_i, bool in_progress) {
  array<int, 3> id = {pat_i, num_i, num_i < nums.size() ? nums[num_i] : 0};
  if (mem.count(id)) return mem[id];
  if (nums.back() == 0) {
    for (int i = pat_i; i < pat.size(); i++) {
      if (pat[i] == '#') return mem[id] = 0;
    }
    return mem[id] = 1;
  }
  if (pat_i >= pat.size()) return mem[id] = 0;
  ll res = 0;
  if (pat[pat_i] == '.' || pat[pat_i] == '?') {
    if (in_progress) {
      if (nums[num_i] == 0) {
        res += backtrack(pat, pat_i + 1, nums, num_i + 1, false);
      }
    }
    else {
      res += backtrack(pat, pat_i + 1, nums, num_i, false);
    }
  }
  if (pat[pat_i] == '#' || pat[pat_i] == '?') {
    if (nums[num_i] > 0) {
      nums[num_i] -= 1;
      res += backtrack(pat, pat_i + 1, nums, num_i, true);
      nums[num_i] += 1;
    }
  }
  return mem[id] = res;
}

int main() {
  ll part1 = 0, part2 = 0;
  ifstream inp("input.txt");
  string line;
  while (getline(inp, line)) {
    stringstream ss(line);
    string pat;
    ss >> pat;
    vector<int> nums;
    string s;
    while (getline(ss, s, ',')) nums.push_back(stoi(s));

    mem.clear();
    part1 += backtrack(pat, 0, nums, 0, false);

    string beeg_pat;
    vector<int> beeg_nums;
    for (int i = 0; i < 5; i++) {
      beeg_pat += pat + (i == 4 ? "" : "?");
      for (int num : nums) beeg_nums.push_back(num);
    }
    mem.clear();
    ll res = backtrack(beeg_pat, 0, beeg_nums, 0, false);
    part2 += res;
  }
  cout << part1 << endl;
  cout << part2 << endl;
}
