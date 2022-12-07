#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    string str;
    vector<string> path;
    map<string, int> sizes;
    while (f >> str) {
        if (str == "$") {
            string cmd; f >> cmd;
            if (cmd == "ls") continue;
            string dir; f >> dir;
            if (dir == "..") path.pop_back();
            else if (dir == "/") path.clear();
            else path.push_back(dir);
        }
        else {
            string dmy;
            getline(f, dmy);
            if (str == "dir") continue;
            int sz = stoi(str);
            string crp;
            for (auto& s : path) {
                sizes[crp] += sz;
                crp += "/" + s;
            }
            sizes[crp] += sz;
        }
    }
    int ftot = 0;
    for (auto [k, v] : sizes) {
        if (v <= 100000) ftot += v;
    }
    int tot = sizes[""];
    int sp = 70000000 - tot;
    int trg = 30000000;
    int best = INT_MAX;
    for (auto [k, v] : sizes) {
        if (sp + v >= trg && best > v) best = v;
    }
    cout << ftot << '\n' << best;
}