#include <bits/stdc++.h>
using namespace std;

int main() {
    ifstream f("input.txt");
    string s;
    int cals = 0;
    priority_queue<int> pq;
    while (getline(f, s)) {
        if (s.empty()) {
            pq.push(cals);
            cals = 0;
            continue;
        }
        int a = stoi(s);
        cals += a;
    }
    pq.push(cals);
    cout << pq.top() << '\n';
    int tot = 0;
    for (int i = 0; i < 3; i++) {
        tot += pq.top(); pq.pop();
    }
    cout << tot;
}