#include <bits/stdc++.h>
using namespace std;
typedef long long ll;

struct monkey {
    vector<ll> items{};
    function<ll(ll)> op{};
    int divTest{ 0 };
    int targets[2]{};
    ll inspCnt;
};

void readInfo(vector<monkey>& monkeys) {
    ifstream f("input.txt");
    string ds;
    for (int i = 0; getline(f, ds); i++) {
        auto& cm = monkeys.emplace_back();
        getline(f, ds);
        stringstream ss1(ds.substr(18));
        while (getline(ss1, ds, ',')) cm.items.push_back(stoi(ds));
        getline(f, ds);
        ds = ds.substr(23);
        if (ds == "* old") cm.op = [](ll x) { return x * x; };
        else {
            char oc = ds[0];
            int v = stoi(ds.substr(2));
            if (oc == '*') cm.op = [v](ll x) { return x * v; };
            else cm.op = [v](ll x) { return x + v; };
        }
        getline(f, ds);
        cm.divTest = stoi(ds.substr(21));
        getline(f, ds);
        cm.targets[1] = stoi(ds.substr(29));
        getline(f, ds);
        cm.targets[0] = stoi(ds.substr(30));
        f >> ws;
    }
}
ll solve(vector<monkey> monkeys, int r, function<ll(ll)> itemTr) {
    ll tlcm = 1;
    for (auto& cm : monkeys) tlcm = lcm(tlcm, cm.divTest);
    while (r--) {
        for (auto& cm : monkeys) {
            for (auto item : cm.items) {
                ll newItem = itemTr(cm.op(item));
                int trg = cm.targets[newItem % cm.divTest == 0];
                monkeys[trg].items.push_back(newItem);
            }
            cm.inspCnt += cm.items.size();
            cm.items.clear();
        }
    }
    sort(monkeys.begin(), monkeys.end(), [](auto& a, auto& b) { return a.inspCnt > b.inspCnt; });
    return monkeys[0].inspCnt * monkeys[1].inspCnt;
}

int main() {
    vector<monkey> monkeys;
    readInfo(monkeys);
    ll tlcm = 1;
    for (auto& cm : monkeys) tlcm = lcm(tlcm, cm.divTest);
    cout << solve(monkeys, 20, [](ll a) { return a / 3; }) << endl;
    cout << solve(monkeys, 10000, [=](ll a) { return a % tlcm; });
}
