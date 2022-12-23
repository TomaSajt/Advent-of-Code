#include <bits/stdc++.h>
using namespace std;
typedef long long ll;
const ll UNSET = LLONG_MIN;

struct Monkey {
    ll value{ UNSET };
    bool cons{ 0 };
    string s{}, a{}, b{};
    char op{};
    bool dep_humn{ 0 };
    ll get_value(map<string, Monkey>& mm) {
        return value != UNSET ? value : value = do_op(mm[a].get_value(mm), mm[b].get_value(mm));
    }
    ll do_op(ll va, ll vb) {
        switch (op) {
        case '+': return va + vb;
        case '-': return va - vb;
        case '*': return va * vb;
        default: return va / vb;
        }
    }
    void calc_humn_dep(map<string, Monkey>& mm) {
        if (s == "humn") {
            dep_humn = 1;
            return;
        }
        if (cons) return;
        mm[a].calc_humn_dep(mm), mm[b].calc_humn_dep(mm);
        dep_humn = mm[a].dep_humn || mm[b].dep_humn;
    }
    string display(map<string, Monkey>& mm) {
        if (s == "humn") return "x";
        if (!dep_humn) return to_string(value);
        return "(" + mm[a].display(mm) + ")" + string(1, op) + "(" + mm[b].display(mm) + ")";
    }
};

int main() {
    map<string, Monkey> mmap;
    ifstream f("input.txt");
    string s;
    while (getline(f, s)) {
        stringstream ss{ s };
        vector<string> v;
        while (getline(ss, s, ' ')) v.push_back(s);
        string curr = v[0].substr(0, v[0].size() - 1);
        mmap[curr] = v.size() == 2 ? Monkey{ .value = stoi(v[1]), .cons = 1, .s = curr } : Monkey{ .s = curr, .a = v[1], .b = v[3], .op = v[2][0] };
    }
    auto& root = mmap["root"];
    cout << root.get_value(mmap) << endl;
    root.op = '=';
    root.calc_humn_dep(mmap);
    cout << mmap["root"].display(mmap);
}