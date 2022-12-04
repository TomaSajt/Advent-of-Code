#include <bits/stdc++.h>
using namespace std;

int main() {
    int a;
    vector<int> vec;
    ifstream stream("input.txt");
    while (stream >> a) vec.push_back(a);
    vec.push_back(0);
    sort(vec.begin(), vec.end());
    int devJolts = vec.back() + 3;
    vec.push_back(devJolts);
    int c3 = 0;
    for (int i = 1; i < vec.size(); ++i) {
        if (vec[i] - vec[i - 1] == 3) c3++;
    }
    cout << (vec.size() - c3 - 1) * c3 << endl;
    vector<long long> ways(devJolts + 1);
    ways[0] = 1;
    for (int& jolts : vec) {
        for (int i = 1; i <= 3; i++) {
            if (jolts >= i) ways[jolts] += ways[jolts - i];
        }
    }
    cout << ways[devJolts] << endl;
}