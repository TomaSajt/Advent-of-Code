#include <bits/stdc++.h>
using namespace std;
using ll = long long;
using intv = pair<ll, ll>;

fstream inp("input.txt");
vector<vector<pair<pair<ll, ll>, ll>>> mappings(7);

vector<ll> parse_line() {
  string line;
  getline(inp, line);
  stringstream ss(line);
  vector<ll> nums;
  ll num;
  while (ss >> num) nums.push_back(num);
  return nums;
}

vector<intv> map_intervals(vector<intv>& intervals,
                           vector<pair<intv, ll>>& mapping) {
  vector<intv> result;
  for (intv& interval : intervals) {
    for (pair<intv, ll>& sub_mapping : mapping) {
      auto& [sm_interval, offset] = sub_mapping;
      intv res = {max(interval.first, sm_interval.first) + offset, min(interval.second, sm_interval.second) + offset};
      if (res.first > res.second) continue;
      result.push_back(res);
    }
  }
  return result;
}

int solve(vector<intv> intervals) {
  for (auto& mapping : mappings) intervals = map_intervals(intervals, mapping);
  return min_element(intervals.begin(), intervals.end())->first;
}

int main() {
  inp.ignore(7);
  vector<ll> first_nums = parse_line();

  vector<intv> part1, part2;
  for (ll& x : first_nums) part1.push_back({x, x});
  for (ll i = 0; i < first_nums.size(); i += 2) part2.push_back({first_nums[i], first_nums[i] + first_nums[i + 1] - 1});

  parse_line();
  for (auto& mapping : mappings) {
    parse_line();
    while (true) {
      vector<ll> nums = parse_line();
      if (nums.size() == 0) break;
      mapping.push_back({{nums[1], nums[1] + nums[2] - 1}, nums[0] - nums[1]}); // {{l, r}, offset}
    }
    sort(mapping.begin(), mapping.end());
    // Fill in unmapped regions
    ll sz = mapping.size();
    for (ll i = 0; i <= sz; i++) {
      ll l = i == 0 ? LLONG_MIN : mapping[i - 1].first.second + 1;
      ll r = i == sz ? LLONG_MAX : mapping[i].first.first - 1;
      if (l > r) continue;
      mapping.push_back({{l, r}, 0});
    }
  }

  cout << solve(part1) << endl;
  cout << solve(part2);
}
